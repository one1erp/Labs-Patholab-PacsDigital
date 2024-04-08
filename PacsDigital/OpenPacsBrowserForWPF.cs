using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Patholab_DAL_V1;
using System.Security.Cryptography;
using System.Web;
using System.Diagnostics;
using Patholab_Common;

namespace PacsDigital
{
    public partial class OpenPacsBrowserForWPF : UserControl
    {
        private SDG _sdg;
        PHRASE_HEADER _InterfaceParams;
        private string url, browser;
        private List<string> hashParams;
        private string pat_id, acc_no, exam_id, allow_pat_change, systemPass, key;
        CLIENT client;
        public static string NautConStr;
        private bool isSectraOpen;
        private string userName = "one";
        public string closeUrl
        {
            get;
            set;
        }

        public OpenPacsBrowserForWPF()
        {
            InitializeComponent();
            isSectraOpen = false;
        }

        public void InitializeData(SDG sdg, PHRASE_HEADER phrase)
        {
            _InterfaceParams = phrase;
            _sdg = sdg;
        }

        public void InitializeData(SDG sdg, PHRASE_HEADER phrase, string _userName)
        {
            userName = _userName + @"@asuta.co.il";
            InitializeData(sdg, phrase);

            deleteUserNamePrefix();
        }

        // the prefix that need to be deleted is: OPS$ASUTA\
        private void deleteUserNamePrefix()
        {
            int index = userName.IndexOf(@"\");
            if (index != -1)
            {
                userName = userName.Substring(index + 1);
            }
        }

        private string BuildUrl()
        {
            pat_id = client.NAME;
            acc_no = _sdg.SDG_USER.U_PATHOLAB_NUMBER;
            exam_id = "0";

            if (acc_no == null)
            {
                return "patholab error";
            }
            acc_no = acc_no.Replace("/", "-");
            exam_id = exam_id.Replace("/", "-");
            allow_pat_change = "1";
            systemPass = "Assuta@2020";

            TimeSpan t = (DateTime.Now - new DateTime(1970, 1, 1));
            long time = (long)t.TotalSeconds;
            var timeString = time.ToString();

            hashParams = new List<string>();
            hashParams.Add(EscapeString(userName));

            hashParams.Add(EscapeString(timeString));
            if (!url.Contains("ids7"))
            {
                hashParams.Add(EscapeString("show_images"));
            }
            hashParams.Add(EscapeString(pat_id));
            hashParams.Add(EscapeString(acc_no));
            hashParams.Add(EscapeString(exam_id));
            if (!url.Contains("ids7"))
            {
                hashParams.Add(EscapeString("AssutaPID"));
                hashParams.Add(EscapeString("AssutaACC"));
            }
            hashParams.Add(EscapeString(allow_pat_change));
            hashParams.Add(systemPass);
            key = GetAccessControlKey(hashParams);
            if (!url.Contains("ids7"))
            {
                url += "user_id=" + hashParams[0] + "&time=" + hashParams[1] + "&uniview_cmd=show_images&pat_id=" + hashParams[3] + "&acc_no=" + hashParams[4] + "&exam_id=" + hashParams[5] +
                "&mrn_integration_id=AssutaPID&acc_no_integration_id=AssutaACC&allow_pat_change=1&key=" + key + "&close_popup=1";
            }
            else
            {
                url += "user_id=" + hashParams[0] + "&time=" + hashParams[1] + "&pat_id=" + hashParams[2] + "&acc_no=" + hashParams[3] + "&exam_id=" + hashParams[4] +
                "&allow_pat_change=1&key=" + key + "&close_popup=1";
            }

            return url;
        }

        #region Building Key Functions

        private static byte[] GetUtf8Bytes(string parameters)
        {
            return Encoding.UTF8.GetBytes(parameters);
        }

        private static byte[] ComputeSHA1Hash(byte[] utf8bytes)
        {
            SHA1Managed hasher = new SHA1Managed();
            return hasher.ComputeHash(utf8bytes);
        }

        private static string ByteArrayToHexString(byte[] sha1Hash)
        {
            StringBuilder hexString = new StringBuilder();
            foreach (byte hashByte in sha1Hash)
            {
                hexString.Append(hashByte.ToString("x2"));
            }
            return hexString.ToString();
        }

        private string EscapeString(string str)
        {
            return HttpUtility.UrlEncode(str);
        }
        private string GetAccessControlKey(IEnumerable<string> hashParameters)
        {
            if (hashParameters == null)
            {
                return String.Empty;
            }
            StringBuilder concatenatedParams = new StringBuilder();
            foreach (string param in hashParameters)
            {
                concatenatedParams.Append(param);
            }
            // The three steps from string of params to hexadecimal
            // string of SHA1 hash bytes.
            byte[] utf8Bytes = GetUtf8Bytes(concatenatedParams.ToString());
            byte[] sha1Hash = ComputeSHA1Hash(utf8Bytes);
            string accessControlKey = ByteArrayToHexString(sha1Hash);
            return accessControlKey;
        }

        #endregion

        private async void pacsDigitalForWPF_Click(object sender, EventArgs e)
        {
            try
            {
                browser = _InterfaceParams.PhraseEntriesDictonary["browser"];
                Kill_IE(browser);
                //Refresh_Sectra();
                url = _InterfaceParams.PhraseEntriesDictonary["beginUrl"];

                if (_sdg != null)
                {
                    if (_sdg.SDG_USER.CLIENT == null)
                    {
                        MessageBox.Show("לא קיים פציינט למקרה");
                    }
                    client = _sdg.SDG_USER.CLIENT;
                    url = BuildUrl();
                    if (url.Equals("patholab error"))
                    {
                        MessageBox.Show("לא קיים מספר פתולאב למקרה");
                    }
                    else
                    {
                        Logger.WriteLogFile($"pacsDigitalForWPF_Click \n {url}");

                        System.Diagnostics.Process.Start(browser, url);
                        isSectraOpen = true;
                    }
                }

                
            }
            catch
            {
                MessageBox.Show("לא הוכנס מספר מקרה.");
            }
        }

        public void Refresh_Sectra()
        {
            if (isSectraOpen)
            {
                Kill_IE(browser);
                closeUrl = _InterfaceParams.PhraseEntriesDictonary["clearUrl"];
                closeUrl = BuildRefreshUrl();
                Logger.WriteLogFile($"Refresh_Sectra \n {closeUrl}");

                Process.Start(browser, closeUrl);
            }
        }

        private string BuildRefreshUrl()
        {
            pat_id = "-1";
            acc_no = "-1";
            exam_id = "-1";
            allow_pat_change = "1";
            systemPass = "Assuta@2020";

            TimeSpan t = (DateTime.Now - new DateTime(1970, 1, 1));
            long time = (long)t.TotalSeconds;
            var timeString = time.ToString();

            hashParams = new List<string>();
            hashParams.Add(EscapeString(userName));
            //hashParams.Add(EscapeString(_username));
            hashParams.Add(EscapeString(timeString));
            if (!url.Contains("ids7"))
            {
                hashParams.Add(EscapeString("show_images"));
            }
            hashParams.Add(EscapeString(pat_id));
            hashParams.Add(EscapeString(acc_no));
            hashParams.Add(EscapeString(exam_id));
            if (!url.Contains("ids7"))
            {
                hashParams.Add(EscapeString("AssutaPID"));
                hashParams.Add(EscapeString("AssutaACC"));
            }
            hashParams.Add(EscapeString(allow_pat_change));
            hashParams.Add(systemPass);
            key = GetAccessControlKey(hashParams);
            if (!url.Contains("ids7"))
            {
                closeUrl += "user_id=" + hashParams[0] + "&time=" + hashParams[1] + "&uniview_cmd=show_images&pat_id=" + hashParams[3] + "&acc_no=" + hashParams[4] + "&exam_id=" + hashParams[5] +
                "&mrn_integration_id=AssutaPID&acc_no_integration_id=AssutaACC&allow_pat_change=1&key=" + key + "&close_popup=1";
            }
            else
            {
                closeUrl += "user_id=" + hashParams[0] + "&time=" + hashParams[1] + "&pat_id=" + hashParams[2] + "&acc_no=" + hashParams[3] + "&exam_id=" + hashParams[4] +
                "&allow_pat_change=1&key=" + key + "&close_popup=1";
            }

            return closeUrl;
        }

        public void Kill_IE(string processName)
        {
            Process[] ps = Process.GetProcessesByName(processName);

            foreach (Process p in ps)
            {
                try
                {
                    if (!p.HasExited)
                    {
                        Logger.WriteLogFile($"kill proccess {p.ToString()}");
                        p.Kill();
                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLogFile($"Unable to kill process {p.ToString()}, exception: {ex.ToString()}");
                }
            }
        }

        public static void openInWpf(SDG sdg, PHRASE_HEADER phrase)
        {
            OpenPacsBrowserForWPF pacs = new OpenPacsBrowserForWPF();
            pacs.Refresh_Sectra();
            pacs.InitializeData(sdg, phrase);
            pacs.pacsDigitalForWPF_Click(null, null);
        }

        public static void openInWpf(SDG sdg, PHRASE_HEADER phrase, string _userName)
        {
            OpenPacsBrowserForWPF pacs = new OpenPacsBrowserForWPF();
            pacs.Refresh_Sectra();
            pacs.InitializeData(sdg, phrase, _userName);
            pacs.pacsDigitalForWPF_Click(null, null);
        }


    }
}
