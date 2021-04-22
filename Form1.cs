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


        private void Form1_Load(object sender, EventArgs e)
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
                 if (Convert.ToString(row.Cells["Durum"].Value) == "Az bulutlu ve açık")
                {
                    Image imag5, imag6;
                    imag5 = Image.FromFile(@"C:\Users\Alperen\Desktop\ntp deneme\xml vize\xml vize\foto\azbulut.png");
                    imag6 = Image.FromFile(@"C:\Users\Alperen\Desktop\ntp deneme\xml vize\xml vize\foto\güneşli.png");
                    row.Cells[4].Value = imag5;
                    row.Cells[5].Value = imag6;
                }
                if (Convert.ToString(row.Cells["Durum"].Value) == "Parçalı bulutlu")
                {
                    Image imag;
                    imag = Image.FromFile(@"C:\Users\Alperen\Desktop\ntp deneme\xml vize\xml vize\foto\azbulut.png");
                    row.Cells[4].Value = imag;
                }
               if (Convert.ToString(row.Cells["Durum"].Value) == "Parçalı yer yer  çok bulutlu")
                {
                    Image imag2;
                    imag2 = Image.FromFile(@"C:\Users\Alperen\Desktop\ntp deneme\xml vize\xml vize\foto\çok bulut.png");
                    row.Cells[4].Value = imag2;
                }
              if (Convert.ToString(row.Cells["Durum"].Value) == "Parçalı ve çok bulutlu, bu akşam saatlerinde yerel olmak üzere sağanak ve yer yer gök gürültülü sağanak yağışlı ")
                {
                    Image imag3,imag4;
                    imag3 = Image.FromFile(@"C:\Users\Alperen\Desktop\ntp deneme\xml vize\xml vize\foto\çok bulut.png");
                    imag4 = Image.FromFile(@"C:\Users\Alperen\Desktop\ntp deneme\xml vize\xml vize\foto\gökg.png");
                    row.Cells[4].Value = imag3;
                    row.Cells[5].Value = imag4;
                }

                if (Convert.ToString(row.Cells["Durum"].Value) == "Az bulutlu ve açık ")
                {
                    Image imag9, imag10;
                    imag9 = Image.FromFile(@"C:\Users\Alperen\Desktop\ntp deneme\xml vize\xml vize\foto\azbulut.png");
                    imag10 = Image.FromFile(@"C:\Users\Alperen\Desktop\ntp deneme\xml vize\xml vize\foto\güneşli.png");
                    row.Cells[4].Value = imag9;
                    row.Cells[5].Value = imag10;
                }
                if (Convert.ToString(row.Cells["Durum"].Value) == "Az bulutlu ve açık, zamanla parçalı bulutlu ")
                {
                      Image imag7, imag8;
                      imag7 = Image.FromFile(@"C:\Users\Alperen\Desktop\ntp deneme\xml vize\xml vize\foto\azbulut.png");
                      imag8 = Image.FromFile(@"C:\Users\Alperen\Desktop\ntp deneme\xml vize\xml vize\foto\çok bulut.png");
                      row.Cells[4].Value = imag7;
                      row.Cells[5].Value = imag8;
                }
                if (Convert.ToString(row.Cells["Durum"].Value) == "Parçalı ve az bulutlu ")
                {
                    Image imag11;
                    imag11 = Image.FromFile(@"C:\Users\Alperen\Desktop\ntp deneme\xml vize\xml vize\foto\azbulut.png");
                    
                    row.Cells[4].Value = imag11;
                    
                }

                





            }
        }

    }


}


