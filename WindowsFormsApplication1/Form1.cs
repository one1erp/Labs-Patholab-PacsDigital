using LSSERVICEPROVIDERLib;
using PacsDigital;
using Patholab_Common;
using Patholab_DAL_V1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public static string NautConStr;
        private static DataLayer _dal;
        INautilusDBConnection _ntlsCon;
        NautilusServiceProvider _sp;
        string _username;
        PHRASE_HEADER _InterfaceParams;
        SDG sdg;


        public Form1()
        {
            try
            {
                InitializeComponent();
                NautConStr = ConfigurationManager.ConnectionStrings["NautConnectionString"].ConnectionString;
                _dal = new DataLayer();
                _dal.MockConnect(NautConStr);
                _InterfaceParams = _dal.GetPhraseByName("PacsDigital");
                if (_InterfaceParams == null)
                {
                    MessageBox.Show("_InterfaceParams is null");
                }

                //this will work when it will be an extention (it gives the NautilusServiceProvider that is missing)
                //_ntlsCon = Utils.GetNtlsCon(_sp);
                //string username = _ntlsCon.GetUsername();

                string _username = ConfigurationManager.AppSettings["username"];
                //MessageBox.Show("username from app.config is: " + _username);

                //_username = "nautilusadm@asuta.co.il";

                //_username += "@asuta.co.il";

                openPacsDigital1.OpenPacs(_InterfaceParams, _dal, _username);
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR: " + e.Message);
            }

        }


        private void textBoxSDG_TextChanged(object sender, EventArgs e)
        {
            openPacsDigital1.UpdateSDG(textBoxSDG.Text);
            //if (textBoxSDG.Text != "")
            //{
            //    try
            //    {
            //        long id = long.Parse(textBoxSDG.Text);
            //        openPacsDigital1.UpdateSDG(id);
            //    }
            //    catch
            //    {
            //    }
            //}
        }


    }
}
