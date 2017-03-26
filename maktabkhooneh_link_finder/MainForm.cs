using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace maktabkhooneh_link_finder
{
    public partial class MainForm : Form
    {
        private class RESULT_CODE
        {
            public const int SUCCESS = 0;
            public const int BLANK_URL = -1;
            public const int INVALID_URL_STRUCTURE = -2;
            public const int NO_CONNECTION = -3;
            public const int NO_SUCH_URL = -4;
            public const int UNKNOWN_ERROR = -5;
        }

        private string coursePageContent;
        private List<string> urlList;

        public MainForm()
        {
            InitializeComponent();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://maktabkhooneh.org/course/golshani40");
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            setUiState(true);
            start();
            setUiState(false);
        }
        private void setUiState(bool isBusy)
        {
            if (isBusy)
            {
                txtInputURL.Enabled = false;
                btnStart.Text = "Please Wait...";
                btnStart.Enabled = false;
                radHq.Enabled = false;
                radLq.Enabled = false;
                Cursor.Current = Cursors.WaitCursor;
            }
            else
            {
                txtInputURL.Enabled = true;
                btnStart.Text = "Start";
                btnStart.Enabled = true;
                radHq.Enabled = true;
                radLq.Enabled = true;
                Cursor.Current = Cursors.Default;
            }
        }

        private void start()
        {
            coursePageContent = null;
            urlList = new List<string>();
            int resultCode;
            if ((resultCode = validateUrlStructure()) != 0)
            {
                showError(resultCode);
                return;
            }
            if ((resultCode = loadCoursePageContent()) != 0)
            {
                showError(resultCode);
                return;
            }
            if ((resultCode = fetchUrls()) != 0)
            {
                showError(resultCode);
                return;
            }
        }
        private int validateUrlStructure()
        {
            string url = txtInputURL.Text;
            if (url == "")
                return RESULT_CODE.BLANK_URL;
            if (!url.Contains(@"maktabkhooneh.org/course/"))
                return RESULT_CODE.INVALID_URL_STRUCTURE;
            var splittedArray = url.Split(new string[] { "course" }, StringSplitOptions.None);
            if (splittedArray[1].Length <= 1)
                return RESULT_CODE.INVALID_URL_STRUCTURE;
            string courseId = splittedArray[1].Substring(1);
            url = @"https://maktabkhooneh.org/course/" + courseId;
            txtInputURL.Text = url;
            return 0;
        }
        private int loadCoursePageContent()
        {
            try {
                WebRequest request = WebRequest.Create(txtInputURL.Text);
                WebResponse response = request.GetResponse();
                Stream data = response.GetResponseStream();
                string html = String.Empty;
                using (StreamReader sr = new StreamReader(data))
                {
                    html = sr.ReadToEnd();
                }
                coursePageContent = html;
                if (!isCoursePage(html))
                    return RESULT_CODE.NO_SUCH_URL;
                return 0;
            }
            catch
            {
                return RESULT_CODE.NO_CONNECTION;
            }
        }
        private int fetchUrls()
        {
            List<string> videoPages = new List<string>();
            var allLinks = coursePageContent.Split(new string[] { "href=\"" }, StringSplitOptions.None);
            for (int i = 0; i < allLinks.Length; i++)
            {
                allLinks[i] = allLinks[i].Split('\"')[0];
                if (isVideoPageAddress(allLinks[i]))
                    videoPages.Add("https://maktabkhooneh.org"+allLinks[i]); //because links are stored as /video/xxxxx, not full address.
            }
            //video pages loaded.
            if(txtOutputURLs.Text!="")
                txtOutputURLs.AppendText("\r\n");
            bool isHq = radHq.Checked;
            try {
                foreach (string videoPage in videoPages)
                {
                    urlList.Add(findDirectLink(videoPage, isHq));
                    //add last link to the output
                    txtOutputURLs.AppendText(urlList[urlList.Count - 1] + "\r\n");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return RESULT_CODE.UNKNOWN_ERROR;
            }
            return 0;
        }

        private bool isCoursePage(string html)
        {
            int n = html.Split('\n').Length;
            return n <= 1 ? false : true;
        }
        private bool isVideoPageAddress(string url)
        {
            if (url.Length <= 7)
                return false;
            if (url.Substring(0, 7) == @"/video/")
                return true;
            return false;
        }
        private string findDirectLink(string videoPageUrl, bool isHq)
        {
            string videoPageContent = "";
            WebRequest request = WebRequest.Create(videoPageUrl);
            WebResponse response = request.GetResponse();
            Stream data = response.GetResponseStream();
            using (StreamReader sr = new StreamReader(data))
            {
                videoPageContent = sr.ReadToEnd();
            }
            string hqId = videoPageContent.Split(new string[] { @"/videos/hq" }, StringSplitOptions.None)[1].Split('\"')[0];
            string GeneralId = isHq ? hqId : hqId.Remove(hqId.LastIndexOf("hq"), 3);
            string GeneralUrl = "http://cdnmaktab.takhtesefid.org/videos/" + (isHq?"hq":"") + GeneralId;
            return GeneralUrl;
        }

        private void showError(int errorCode)
        {
            string errorText;
            if (errorCode == RESULT_CODE.BLANK_URL)
                errorText = "Page Url is empty.";
            else if (errorCode == RESULT_CODE.INVALID_URL_STRUCTURE)
                errorText = "I can't understand this adress.\nMake sure your address structure matches the example.";
            else if (errorCode == RESULT_CODE.NO_CONNECTION)
                errorText = "Cannot connect to the page.\nPlease check your internet connection and try again.";
            else if (errorCode == RESULT_CODE.NO_SUCH_URL)
                errorText = "This address does not refer to a course page.\nPlease check the URL address.";
            else
                errorText = "Unknown Error. We're sorry.";
            MessageBox.Show(errorText, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtOutputURLs.Text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtOutputURLs.Clear();
        }

        private void btnTotalSize_Click(object sender, EventArgs e)
        {
            try {
                setUiState(true);
                string videoUrl = txtOutputURLs.Lines[1]; //second line as a sample
                int fileSize = (int)(getFileSize(videoUrl) / 1048576);
                int n = 0;
                foreach (var line in txtOutputURLs.Lines)
                    if (line != "")
                        n++;
                int estimatedTotalSize = fileSize * n;
                string text = "Sample File Size: " + fileSize + " MB\n" +
                    "Number of Files in the list: " + n + "\n" +
                    "Estimated Total Download Size: " + estimatedTotalSize + " MB";
                setUiState(false);
                MessageBox.Show(text, "Estimated Total Size", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                setUiState(false);
                showError(RESULT_CODE.UNKNOWN_ERROR);
            }
        }
        long getFileSize(string url)
        {
            WebRequest request = WebRequest.Create(url);
            request.Method = "HEAD";
            WebResponse response = request.GetResponse();
            long size = 0;
            long.TryParse(response.Headers.Get("Content-Length"), out size);
            return size;
        }
    }
}
