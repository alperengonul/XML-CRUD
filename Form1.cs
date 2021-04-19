using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Forms;

namespace xml_vize
{
    public partial class Form1 : Form
    {
        public  Form1()
        {
            InitializeComponent();

        }

       string xmluznt = "https://www.mgm.gov.tr/FTPDATA/analiz/sonSOA.xml";





        private void Form1_Load(object sender, EventArgs e)
        {
            XmlDocument hvdrm = new XmlDocument();
            hvdrm.Load(xmluznt);
            XmlElement root = hvdrm.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("sehirler");

            foreach (XmlNode node in nodes)
            {
                string ili = node["ili"].InnerText;
                string durum = node["Durum"].InnerText;
                string maks = node["Mak"].InnerText;
                string min = node["Min"].InnerText;
               
                   
                if (ili == "İstanbul")
                {
                    MessageBox.Show("durumu'{}'",durum);
                }
            
            }
        
        }
    }
}
