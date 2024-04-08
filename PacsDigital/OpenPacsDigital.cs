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
using LSSERVICEPROVIDERLib;
using Patholab_Common;
using System.Configuration;

namespace PacsDigital
{
    public partial class OpenPacsDigital : UserControl
    {
        private SDG _sdg;
        private DataLayer _dal;
        //INautilusDBConnection _ntlsCon;
        //NautilusServiceProvider _sp;
        PHRASE_HEADER _InterfaceParams;
        string _username;
        string _sdgId;
        long id;


        public OpenPacsDigital()
        {
            InitializeComponent();

            //_sp = new NautilusServiceProvider();
            //_ntlsCon = Utils.GetNtlsCon(_sp);

        }

        public void OpenPacs(PHRASE_HEADER InterfaceParams, DataLayer dal, string username)
        {
             this._InterfaceParams = InterfaceParams;
            this._dal = dal;
            this._username = username;
        }

        public void UpdateSDG(string id)
        {
            this._sdgId = id;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            //for testing
            if (_sdgId!=null && _sdgId.ToLower() != "test")
            {
                id = long.Parse(_sdgId);
                _sdg = _dal.FindBy<SDG>(x => x.SDG_ID == id).FirstOrDefault();
                try
                {
                    if (_sdg == null)
                    {
                        MessageBox.Show("Client is not defined");

                        //return;
                    }
                    CLIENT clientTest =_sdg.SDG_USER.CLIENT;


                    var form = new PacsDigitalForm(clientTest, _username, _InterfaceParams);
                    form.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: " + ex.Message);
                }
            }
            else
            {
                CLIENT clientTest = null;
                var form = new PacsDigitalForm(clientTest, _username, _InterfaceParams);
                form.ShowDialog();
            }
            

            //_sdg = _dal.FindBy<SDG>(x => x.SDG_ID == _sdgId).FirstOrDefault();

           
        }


        //public void button1_Click(object sender, EventArgs e)
        //{
        //    //sdg id is from the assuta test server
        //    //SDG sdgTest = _dal.FindBy<SDG>(x => x.SDG_ID == 682938).FirstOrDefault();
        //    CLIENT client = sdg.SDG_USER.CLIENT; //_dal.FindBy<CLIENT>(x => x.CLIENT_ID == 180027).FirstOrDefault();

        //    if (sdg == null)
        //    {
        //        MessageBox.Show("Client is not defined - Test");

        //        return;
        //    }
        //    string username = " ";
        //    username = _ntlsCon.GetUsername();

        //    InterfaceParams = _dal.GetPhraseByName("PacsDigital");
        //    //string url = InterfaceParams.PhraseEntriesDictonary["beginUrl"];

        //    var form = new PacsDigitalForm(client, username, InterfaceParams);
        //    form.ShowDialog();
        //}


    }
}
