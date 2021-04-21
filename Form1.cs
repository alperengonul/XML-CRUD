using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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

        public Form1()
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

                foreach  (DataGridViewRow secili in dataGridView1.Rows)
                {
                    if (Convert.ToString(secili.Cells[1].Value)== "Parçalı ve az bulutlu")
                    {
                        Image img1;
                        img1 = Image.FromFile(@"C:\Users\Alperen\Desktop\ntp deneme\foto\partly_cloudy.png");

                        row.Cells[4].Value = img1;
                        if (Convert.ToString(secili.Cells[1].Value) == "Parçalı ve çok bulutlu ")
                        {
                            Image img2;
                            img2 = Image.FromFile(@"C:\Users\Alperen\Desktop\ntp deneme\xml vize\xml vize\foto\çok bulut.png");
                            row.Cells[4].Value = img2;
                        }
                    }
                    else if (Convert.ToString(secili.Cells[1].Value) == "Parçalı ve çok bulutlu " )
                    {
                        Image img2;
                            img2 = Image.FromFile(@"C:\Users\Alperen\Desktop\ntp deneme\xml vize\xml vize\foto\çok bulut.png");
                          row.Cells[4].Value = img2;
                    }
                    else if (Convert.ToString(secili.Cells[1].Value) == "Gökgürültülü Sağanak Yağışlı")
                    {
                        Image img3;
                        img3 = Image.FromFile(@"C:\Users\Alperen\Desktop\ntp deneme\xml vize\xml vize\foto\gökg.png");
                        row.Cells[4].Value = img3;

                    }
                    else if (Convert.ToString(secili.Cells[1].Value) == " Parçalı, bu akşam saatlerinde yer yer çok bulutlu")
                    {
                        Image img4;
                        img4 = Image.FromFile(@"C:\Users\Alperen\Desktop\ntp deneme\xml vize\xml vize\foto\çok bulut.png");
                        row.Cells[4].Value = img4;
                    }

                    else if (Convert.ToString(secili.Cells[1].Value) == " Güneşli")
                    {
                        Image img5;
                        img5 = Image.FromFile(@"C:\Users\Alperen\Desktop\ntp deneme\xml vize\xml vize\foto\güneşli.png");
                        row.Cells[4].Value = img5;
                    }

                }

            }

        }

        
    }
}
