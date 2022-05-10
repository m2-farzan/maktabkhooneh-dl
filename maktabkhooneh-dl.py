#!/bin/python3
import argparse
from http.cookiejar import MozillaCookieJar
from importlib.resources import path
import logging
import os
import platform
import re
import subprocess
import sys

from bs4 import BeautifulSoup
import coloredlogs
import requests
from tqdm import tqdm


def main():
    config_logging()
    args = parse_args()

    # Load cookies
    logging.info("Loading cookies...")
    cookies = MozillaCookieJar(args.cookies_file)
    cookies.load()

    # Load course page
    logging.info("Loading course page...")
    course_page = requests.get(args.course_url, cookies=cookies)

    # Parse course page and find links to lecture pages
    logging.info("Scraping lecture pages...")
    bs = BeautifulSoup(course_page.content, 'html.parser')

    course_title = ''
    course_title_elements = bs.select('h1')
    if len(course_title_elements) > 0:
        course_title = course_title_elements[0].getText(strip=True)
        course_title = sanitize_for_filename(course_title) + os.sep
        logging.info(f'Course Title: {course_title[0:-1]}')
    else:
        logging.warning(f'Course title not found')

    lecture_page_link_elements = bs.select('.chapter__unit')
    lecture_page_urls = [(element.get('title'), element.get('href')) for element in lecture_page_link_elements]
    number_of_lectures = len(lecture_page_urls)
    logging.info(f"Found {number_of_lectures} lectures.")

    # Check download range
    if args.range:
        start, end = args.range.split(':')
        if start == '':
            start = 1
        else:
            start = int(start) - 1 # Because we start from zero
        if end == '':
            end = number_of_lectures
        else:
            end = int(end) # We still start from zero but our ending is exclusive
        download_range = range(int(start), int(end))
    else:
        download_range = range(number_of_lectures) # Download all
    folder_index = 0
    last_folder = ''
    # Download lectures
    for i in download_range:
        title, url = lecture_page_urls[i]
        if not url or len(url) == 0:
            logging.info('there is no download in this page. skipping...')
            continue

        title = sanitize_for_filename(title)
        final_extension = "mp3" if args.mp3 else "mp4"
        intermediate_file = f"{title}.mp4.incomplete"
        final_file = f"{(i+1):03d}-{title}.{final_extension}"

        # Bail if lecture is already downloaded
        if os.path.exists(final_file):
            logging.info(f"Lecture {i+1} exists. Skipping...")
            continue

        # Fetch lecture page
        print()
        logging.info(f"Loading lecture page ({i+1}/{number_of_lectures})...")
        lecture_page = requests.get(make_absolute(url), cookies=cookies)

        # Find download links
        logging.info("Scraping download link...")
        bs = BeautifulSoup(lecture_page.content, 'html.parser')
        section = bs.select('.breadcrumb__item a')

        # specifying folder
        folder = '' # no special folder
        if len(section) > 1:
            folder = section[len(section)-2].get_text(strip=True)
        elif len(section) > 0:
            folder = section[0].get_text(strip=True)

        if len(folder) > 0:
            folder = sanitize_for_filename(folder)
            if folder != last_folder:
                folder_index += 1
                last_folder = folder
            numbered_folder = f'{course_title}{folder_index:02d}-{folder}'
            if not os.path.exists(numbered_folder):
                os.makedirs(numbered_folder)
            final_file = numbered_folder + os.sep + final_file

        if os.path.exists(final_file):
            logging.info(f"Lecture {i+1} exists. Skipping...")
            continue

        all_download_links = bs.select('.unit-content--download a')
        if len(all_download_links) > 0:
            HQ_download_link = all_download_links[0].get('href') # HQ comes first in page layout
            if len(all_download_links) > 1:
                LQ_download_link = all_download_links[1].get('href') # LG comes second in page layout
                download_link = LQ_download_link if (args.low_quality or args.mp3) else HQ_download_link
            else:
                download_link = HQ_download_link
        else:
            # lets find the download urls from js video player ;)
            all_download_links = bs.select('.js-player__source')
            if len(all_download_links) > 0:
                HQ_download_link = all_download_links[0].get('src') # HQ comes first in page layout
                if len(all_download_links) > 1:
                    LQ_download_link = all_download_links[1].get('src') # LG comes second in page layout
                    download_link = LQ_download_link if (args.low_quality or args.mp3) else HQ_download_link
                else:
                    download_link = HQ_download_link
            else:
                logging.warning(f'Invalid page layout:{make_absolute(url)}')
                logging.info('Maybe the page is a quize')
                continue

        # Download
        logging.info("Downloading lecture file...")
        download(make_absolute(download_link), intermediate_file)

        # Convert/rename
        if not args.mp3:
            # No further processing needed -- just rename
            os.rename(intermediate_file, final_file)
        else:
            # Convert
            logging.info("Converting to mp3...")
            subprocess.check_output(["ffmpeg", "-i", intermediate_file, final_file]) # TODO: Make non-blocking
            os.remove(intermediate_file)
        
        logging.info("Finished lecture.")

    logging.info("Finished all.")


def parse_args():
    argument_parser = argparse.ArgumentParser(
        prog="maktabkhooneh-dl",
        description="This is a batch download utility for maktabkhooneh.org",
        epilog=\
            "Don't be cruel to their servers!\n"
            "Only download what you really want to watch.\n"
            "\n"
            "Example: maktabkhooneh-dl cookies.txt https://maktabkhooneh.org/course/foo/\n",
        formatter_class=argparse.RawTextHelpFormatter
    )
    argument_parser.add_argument("-L", "--low-quality", action="store_true")
    argument_parser.add_argument("--mp3", action="store_true")
    argument_parser.add_argument("--range", default=None, help="Only download a subset. Specify as `start:end` (inclusive) e.g. `--range=1:5`")
    argument_parser.add_argument("cookies_file")
    argument_parser.add_argument("course_url")
    return argument_parser.parse_args()


def config_logging():
    coloredlogs.install(fmt="%(levelname)s\t%(message)s", level=logging.INFO)


def make_absolute(url):
    if url[:4] == 'http':
        return url
    return 'https://maktabkhooneh.org' + url


def sanitize_for_filename(filename):
    os = platform.system()
    if os == 'Windows':
        return re.sub('[\<\>\:\"\/\\\|\?\*]', '-', re.sub('&.+?;', '-', filename))
    else:
        return re.sub('\/', '-', re.sub('&.+?;', '-', filename))


# Credit: https://gist.github.com/yanqd0/c13ed29e29432e3cf3e7c38467f42f51
def download(url: str, fname: str):
    while True:
        resp = requests.get(url, stream=True)
        total = int(resp.headers.get('content-length', 0))
        with open(fname, 'wb') as file, tqdm(
            desc="        Progress",
            total=total,
            unit='iB',
            unit_scale=True,
            unit_divisor=1024,
        ) as bar:
            for data in resp.iter_content(chunk_size=1024):
                size = file.write(data)
                bar.update(size)
        downloaded_size = os.path.getsize(fname)
        if downloaded_size == total:
            break
        else:
            os.remove(fname)
            logging.warning("downloaded file corrupted. retrying...")
    


def exception_handler(_type, value, _tb):
    logging.exception("Uncaught exception: {0}".format(str(value)))


if __name__ == "__main__":
    sys.excepthook = exception_handler
    main()
