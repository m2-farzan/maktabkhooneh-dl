<div dir="rtl">
  <h1>اسکریپت دانلود از مکتبخونه</h1>
  <p>آیا تا بحال شده که بخواهید تمام ویدیوهای یک درس مکتبخونه رو دانلود کنین ولی بخاطر اینکه لینک ویدیوها الگوی خاصی ندارد، وقت زیادی را از دست داده باشید؟</p>
  <p>اگر شما نیز این مشکل را داشته اید، این پروژه برای شماست.</p>
  <p>کافیست لینک صفحه درس را به این اسکریپت بدهید تا تمام جلسات را برای شما دانلود کند.</p>
  <h2>مثال</h2>
  <div dir="ltr">
    <pre><code>maktabkhooneh-dl cookies.txt https://maktabkhooneh.org/course/هواشناسی-mk201/</code></pre>
  </div>
  <p><i>توجه: </i>دلیل وجود فایل <code>cookies.txt</code> این است که مکتبخونه اجازه دانلود بدون لاگین را نمی‌دهد. پایین‌تر درباره نحوه به دست آوردن این فایل صحبت شده است.</p>
  <h2>نصب</h2>
  <p>ابتدا پیش‌نیازها را نصب کنید:</p>
  <div dir="ltr">
    <pre><code>sudo pip install beautifulsoup4 coloredlogs requests tqdm</code></pre>
  </div>
  <p>سپس نرم‌افزار را به یک پوشه در PATH دانلود کنید. برای مثال:</p>
  <div dir="ltr">
    <pre><code>sudo wget -O /usr/local/bin/maktabkhooneh-dl https://raw.githubusercontent.com/m2-farzan/maktabkhooneh-dl/master/maktabkhooneh-dl</code></pre>
  </div>
  <p>و در نهایت به نرم‌افزار اجازهٔ اجرا بدهید:</p>
  <div dir="ltr">
    <pre><code>sudo chmod +x /usr/local/bin/maktabkhooneh-dl</code></pre>
  </div>
  همین!
  <h2>به دست آوردن فایل <code>cookies.txt</code></h2>
  <p>با مرورگر خود وارد حساب کاربری خود در مکتبخونه شوید و با استفاده از یکی از افزونه‌های زیر، فایل <code>cookies.txt</code> خود را بدست آورید:</p>
  <ul>
    <li><a href="https://addons.mozilla.org/en-US/firefox/addon/cookies-txt/">افزونه برای فایرفاکس</a></li>
    <li><a href="https://chrome.google.com/webstore/detail/get-cookiestxt/bgaddhkoddajcdgocldbbfleckgcbcid/related?hl=en">افزونه برای کروم</a></li>
  </ul>
  <h2>راهنمای کامل</h2>
  <div dir="ltr">
    <pre><code>$ ./maktabkhooneh-dl --help
usage: maktabkhooneh-dl [-h] [-L] [--mp3] [--range RANGE]
                        cookies_file course_url

This is a batch download utility for maktabkhooneh.org

positional arguments:
  cookies_file
  course_url

optional arguments:
  -h, --help         show this help message and exit
  -L, --low-quality
  --mp3
  --range RANGE      Only download a subset. Specify as `start:end` (inclusive) e.g. `--range=1:5`

Don't be cruel to their servers!
Only download what you really want to watch.

Example: maktabkhooneh-dl cookies.txt https://maktabkhooneh.org/course/foo/
    </pre></code>
  </div>
</div>
