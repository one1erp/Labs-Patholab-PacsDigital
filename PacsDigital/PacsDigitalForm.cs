using LSSERVICEPROVIDERLib;
using Microsoft.Win32;
using Patholab_DAL_V1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace PacsDigital
{
    public partial class PacsDigitalForm : Form
    {
        private CLIENT _client;
        private string _username;
        string _url;
        PHRASE_HEADER _InterfaceParams;
        List<string> hashParams;
        float firstWidth;
        float firstHeight;
        TimeSpan t;

        string pat_id, acc_no, exam_id, allow_pat_change, systemPass,key;

        public PacsDigitalForm(CLIENT client, string username, PHRASE_HEADER InterfaceParams)
        {
            InitializeComponent();

            firstWidth = this.Size.Width;
            firstHeight = this.Size.Height;

            this._client = client;
            this._username = username;
            _InterfaceParams = InterfaceParams;
            _url = InterfaceParams.PhraseEntriesDictonary["beginUrl"];
            //t = (DateTime.UtcNow - new DateTime(1970, 1, 1));
            //Test to check wheter it is working with this function
            t = (DateTime.Now - new DateTime(1970, 1, 1));
            hashParams = new List<string>();
            _url = BuildUrl(_url);
            OpenURLInBrowser();
        }

        private string BuildUrl(string url)
        {
            //for testing 
            if (_client == null)
            {
                pat_id = "B131388-20";
                acc_no = "B131388-20";
                exam_id = "B131388-20";
            }
            else
            {
                pat_id = _client.NAME;
                acc_no = _client.SDG_USER.FirstOrDefault().U_PATHOLAB_NUMBER;
                exam_id = _client.SDG_USER.FirstOrDefault().U_PATHOLAB_NUMBER;

            }
            
            allow_pat_change = "1";
            systemPass = "Assuta@2020";


            //t = (DateTime.UtcNow - new DateTime(1970, 1, 1));
            //Test to check wheter it is working with this function
            t = (DateTime.Now - new DateTime(1970, 1, 1));
            long time = (long)t.TotalSeconds;

            //long time = 1615800214;
            var timeString = time.ToString();

            hashParams = new List<string>();
            
            hashParams.Add(EscapeString(_username));
            hashParams.Add(EscapeString(timeString));
            if (!_url.Contains("ids7"))
            {
                hashParams.Add(EscapeString("show_images"));
            }

            hashParams.Add(EscapeString(pat_id));
            hashParams.Add(EscapeString(acc_no));
            hashParams.Add(EscapeString(exam_id));
            if (!_url.Contains("ids7"))
            {
                hashParams.Add(EscapeString("AssutaPID"));
                hashParams.Add(EscapeString("AssutaACC"));
            }
            hashParams.Add(EscapeString(allow_pat_change));
            hashParams.Add(systemPass);
            key = GetAccessControlKey(hashParams);

            if (!_url.Contains("ids7"))
            {
                url += "user_id=" + hashParams[0] + "&time=" + hashParams[1] + "&uniview_cmd=show_images&pat_id=" + hashParams[3] + "&acc_no=" + hashParams[4] + "&exam_id=" + hashParams[5] +
                "&mrn_integration_id=AssutaPID&acc_no_integration_id=AssutaACC&allow_pat_change=1&key=" + key;
            }
            else
            {
                url += "user_id=" + hashParams[0] + "&time=" + hashParams[1] + "&pat_id=" + hashParams[3] + "&acc_no=" + hashParams[4] + "&exam_id=" + hashParams[4] +
                "&allow_pat_change=1&key=" + key;
            }

            URLTestLabel.Text = url;
            return url;
        }
        private void OpenURLInBrowser()
        {
            try
            {
                //IEAutoDetectProxy(false);
                webBrowser1.Navigate(new Uri(_url));
            }
            catch (System.UriFormatException)
            {
                return;
            } 
        }

        /// <summary>
        /// Checks or unchecks the IE Options Connection setting of "Automatically detect Proxy"
        /// </summary>
        /// <param name="set">Provide 'true' if you want to check the 'Automatically detect Proxy' check box. To uncheck, pass 'false'</param>
        //public void IEAutoDetectProxy(bool set)
        //{
        //    // Setting Proxy information for IE Settings.
        //    RegistryKey RegKey = Registry.CurrentUser.OpenSubKey(@"Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\\Connections", true);
        //    byte[] defConnection = (byte[])RegKey.GetValue("DefaultConnectionSettings");
        //    byte[] savedLegacySetting = (byte[])RegKey.GetValue("SavedLegacySettings");
        //    if (set)
        //    {
        //        defConnection[8] = Convert.ToByte(9);
        //        savedLegacySetting[8] = Convert.ToByte(9);
        //    }
        //    else
        //    {
        //        defConnection[8] = Convert.ToByte(1);
        //        savedLegacySetting[8] = Convert.ToByte(1);
        //    }
        //    RegKey.SetValue("DefaultConnectionSettings", defConnection);
        //    RegKey.SetValue("SavedLegacySettings", savedLegacySetting);
        //    RegKey.SetValue("ProxyEnabled", 0);
        //}

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


        private void clearUrl_Click(object sender, EventArgs e)
        {
            _url = _InterfaceParams.PhraseEntriesDictonary["clearUrl"];
            URLTestLabel.Text = _url;
            OpenURLInBrowser();
        }

        private void closeUrl_Click(object sender, EventArgs e)
        {
            _url = _InterfaceParams.PhraseEntriesDictonary["openIDS7"];
            _url = BuildUrl(_url);
            URLTestLabel.Text = _url;
            OpenURLInBrowser();
        }

        private void testUrl_Click(object sender, EventArgs e)
        {
            _url = _InterfaceParams.PhraseEntriesDictonary["openUniView"];
            _url = BuildUrl(_url);
            URLTestLabel.Text = _url;
            OpenURLInBrowser();
        }

        private void PacsDigitalForm_SizeChanged(object sender, EventArgs e)
        {
            float size1 = this.Size.Width / firstWidth;
            float size2 = this.Size.Height / firstHeight;

            SizeF scale = new SizeF(size1, size2);
            firstWidth = this.Size.Width;
            firstHeight = this.Size.Height;

            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    control.Scale(scale);
                    continue;
                }
                control.Font = new Font(control.Font.FontFamily, control.Font.Size * ((size1 + size2) / 2));

                control.Scale(scale);

            }
        }
    }
}
