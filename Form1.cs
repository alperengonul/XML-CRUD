using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace xml_vize
{
    public partial class Form1 : Form
    {   
        
        string havadurumu_link = "https://www.mgm.gov.tr/FTPDATA/analiz/sonSOA.xml";
        
        public  Form1()
        {
            InitializeComponent();

        }

        

        

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument doc1 = new XmlDocument();
            doc1.Load(havadurumu_link);
            XmlElement root = doc1.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("sehirler");

            foreach (XmlNode node in nodes)
            {
                string ili = node["ili"].InnerText;
                string durum = node["Durum"].InnerText;
                string max = node["Mak"].InnerText;
                string min = node["Min"].InnerText;


                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();

                row.Cells[0].Value = ili;
                row.Cells[1].Value = durum;
                row.Cells[2].Value = max;
                row.Cells[3].Value = min;
                dataGridView1.Rows.Add(row);
                
            }

        }
    }
}
