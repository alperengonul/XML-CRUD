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
using System.Xml.Linq;
using System.Windows.Forms;

namespace xml_vize
{
    public partial class Form1 : Form
    {

       public const string havadurumu_link = "https://www.mgm.gov.tr/FTPDATA/analiz/sonSOA.xml";

        public Form1()
        {
            InitializeComponent();
        }


        public void Form1_Load(object sender, EventArgs e)
        {
            XmlDocument doc1 = new XmlDocument();
            doc1.Load(havadurumu_link);
            comboBox1.Items.Add("istanbul");
            comboBox1.Items.Add("kocaeli");
            comboBox1.Items.Add("çanakkale");
            comboBox1.Items.Add("izmir");


            /*   XmlElement root = doc1.DocumentElement;
               XmlNodeList nodes = root.SelectNodes("sehirler");
            */

          /*  XDocument deneme = XDocument.Load(havadurumu_link);



            string istanbul = deneme.Descendants("ili").ElementAt(0).Value;
            string sic = deneme.Descendants("Mak").ElementAt(0).Value;
            label2.Text = istanbul;
            label3.Text = sic;*/



          /*  foreach (XmlNode node in nodes)
            {

               // string iller = node["ili"].InnerText.ElementAt().ToString();
                string ili = node["ili"].InnerText;
                string durum = node["Durum"].InnerText;
                string max = node["Mak"].InnerText;
                string min = node["Min"].InnerText;


             //   listView1.Items.Add(iller);
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
                if (Convert.ToString(row.Cells["Durum"].Value) == "Parçalı ve az bulutlu")
                {
                    Image imag12;
                    imag12 = Image.FromFile(@"C:\Users\Alperen\Desktop\ntp deneme\xml vize\xml vize\foto\azbulut.png");

                    row.Cells[4].Value = imag12;

                }
                if (Convert.ToString(row.Cells["Durum"].Value) == "Parçalı ve çok bulutlu, sabah saatlerinden itibaren sağanak ve gök gürültülü sağanak yağışlı, ")
                {
                    Image imag13, imag14;
                    imag13 = Image.FromFile(@"C:\Users\Alperen\Desktop\ntp deneme\xml vize\xml vize\foto\çok bulut.png");
                    imag14 = Image.FromFile(@"C:\Users\Alperen\Desktop\ntp deneme\xml vize\xml vize\foto\gökg.png");
                    row.Cells[4].Value = imag13;
                    row.Cells[5].Value = imag14;
                }

                if (Convert.ToString(row.Cells["Durum"].Value) == "Parçalı ve çok bulutlu, gece saatlerinden itibaren sağanak ve gök gürültülü sağanak yağışlı, ")
                {
                    Image imag15, imag16;
                    imag15 = Image.FromFile(@"C:\Users\Alperen\Desktop\ntp deneme\xml vize\xml vize\foto\çok bulut.png");
                    imag16 = Image.FromFile(@"C:\Users\Alperen\Desktop\ntp deneme\xml vize\xml vize\foto\gökg.png");
                    row.Cells[4].Value = imag15;
                    row.Cells[5].Value = imag16;
                }*/
              
               
                


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            XDocument deneme = XDocument.Load(havadurumu_link);
            




           /* if (comboBox1.Text == "istanbul")
            {
                label4.Text = istanbul;
                label3.Text = istmax + "°";
                label2.Text = istmin + "°";
                label5.Text = istdurum;

            }
            else if (comboBox1.Text=="kocaeli")
            {
                label4.Text = kocaeli;
                label3.Text = kocmax + "°";
                label2.Text = kocmin + "°";
                label5.Text = kocdurum;
            }
            else if (true)
            {

            }*/
            

            
        }

       

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            XDocument deneme = XDocument.Load(havadurumu_link);

            //ist
            string istanbul = deneme.Descendants("ili").ElementAt(0).Value;
            string istmax = deneme.Descendants("Mak").ElementAt(0).Value;
            string istmin = deneme.Descendants("Min").ElementAt(0).Value;
            string istdurum = deneme.Descendants("Durum").ElementAt(0).Value;


            MessageBox.Show(istmax + "°" + "/"  + istmin + "°" + "\n" + istdurum, "İstanbul");
        }

        private void pictureBox2_Click(object sender, EventArgs e)   
        {
            XDocument deneme = XDocument.Load(havadurumu_link);
            //kocaeli

            string kocaeli = deneme.Descendants("ili").ElementAt(1).Value;
            string kocmax = deneme.Descendants("Mak").ElementAt(1).Value;
            string kocmin = deneme.Descendants("Min").ElementAt(1).Value;
            string kocdurum = deneme.Descendants("Durum").ElementAt(1).Value;
            MessageBox.Show(kocmax + "°" +"/ "+ kocmin + "°" + "" + "\n" + kocdurum, "Kocaeli");

            string manisa = deneme.Descendants("ili").ElementAt(29).Value;
            MessageBox.Show(manisa);
        }
    }

}





