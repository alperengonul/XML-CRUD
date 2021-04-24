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
             MessageBox.Show("Sıcaklığını ve durumunu öğrenmek istediğiniz ilin üzerindeki raptiye fotğrafına tıklayınız");
            MessageBox.Show("Sıcaklık ve durum değerlendirmeleri hergün saat 18:00 ve 06:00'da güncellenmektedir");
            
            timer1.Start();
            timer2.Start();
           
           
            
        }
        
        public void program()
        {
            
            timer2.Interval = 1800000;
            timer2.Enabled = true;
           
            XDocument deneme = XDocument.Load(havadurumu_link);
            

           
            string zaman = deneme.Descendants("Tarih").ElementAt(0).Value;
            string istanbul = deneme.Descendants("ili").ElementAt(0).Value;
            string istmax = deneme.Descendants("Mak").ElementAt(0).Value;
            string istmin = deneme.Descendants("Min").ElementAt(0).Value;
            string kocmax = deneme.Descendants("Mak").ElementAt(1).Value;
            string kocmin = deneme.Descendants("Min").ElementAt(1).Value;
            string canmax = deneme.Descendants("Mak").ElementAt(2).Value;
            string canmin = deneme.Descendants("Min").ElementAt(2).Value;
            string manmax = deneme.Descendants("Mak").ElementAt(29).Value;
            string manmin = deneme.Descendants("Min").ElementAt(29).Value;
            string izmax = deneme.Descendants("Mak").ElementAt(3).Value;
            string izmin = deneme.Descendants("Min").ElementAt(3).Value;
            string mugmax = deneme.Descendants("Mak").ElementAt(5).Value;
            string mugmin = deneme.Descendants("Min").ElementAt(5).Value;

            FileStream kayit2 = new FileStream(@"C:\Users\Alperen\Desktop\ntp deneme\xml vize\xml vize\bilgikayit.txt", FileMode.Append, FileAccess.Write, FileShare.Write);
            StreamWriter kayded = new StreamWriter(kayit2);
            string saat = DateTime.Now.ToLongTimeString();
            kayded.WriteLine("---------------------------------------------------------------------------");
            kayded.WriteLine(" ");
            kayded.WriteLine("TARİH:  " + zaman + "     SAAT:  " + saat);
            kayded.WriteLine("--İL------MAXSIC---MİNSIC");
            kayded.WriteLine("İstanbul   {0}°-----{1}°", istmax, istmin);
            kayded.WriteLine("Kocaeli    {0}°-----{1}°", kocmax, kocmin);
            kayded.WriteLine("Çanakkale  {0}°-----{1}°", canmax, canmin);
            kayded.WriteLine("Manisa     {0}°-----{1}°", manmax, manmin);
            kayded.WriteLine("İzmir      {0}°-----{1}°", izmax, izmin);
            kayded.WriteLine("Muğla      {0}°-----{1}°", mugmax, mugmin);

            kayded.Close();
            string manisa = deneme.Descendants("ili").ElementAt(29).Value;
           
            label2.Text = manisa;
            label3.Text = manmax + "°";
            label4.Text = manmin + "°";




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

            
        }

        private void canakkale_Click(object sender, EventArgs e)
        {
            XDocument deneme = XDocument.Load(havadurumu_link);
            string canakkale = deneme.Descendants("ili").ElementAt(2).Value;
            string canmax = deneme.Descendants("Mak").ElementAt(2).Value;
            string canmin = deneme.Descendants("Min").ElementAt(2).Value;
            string candurum = deneme.Descendants("Durum").ElementAt(2).Value;
            MessageBox.Show(canmax + "°" + "/ " + canmin + "°" + "" + "\n" + candurum, "Çanakkale");

        }

        private void manisa_Click(object sender, EventArgs e)
        {
            XDocument deneme = XDocument.Load(havadurumu_link);
            string manisa = deneme.Descendants("ili").ElementAt(29).Value;
            string manmax = deneme.Descendants("Mak").ElementAt(29).Value;
            string manmin = deneme.Descendants("Min").ElementAt(29).Value;
            string mandurum = deneme.Descendants("Durum").ElementAt(29).Value;
            MessageBox.Show(manmax + "°" + "/ " + manmin + "°" + "" + "\n" + mandurum, "Manisa");
        }

        private void izmir_Click(object sender, EventArgs e)
        {
            XDocument deneme = XDocument.Load(havadurumu_link);
            string izmir = deneme.Descendants("ili").ElementAt(3).Value;
            string izmax = deneme.Descendants("Mak").ElementAt(3).Value;
            string izmin = deneme.Descendants("Min").ElementAt(3).Value;
            string izdurum = deneme.Descendants("Durum").ElementAt(3).Value;
            MessageBox.Show(izmax + "°" + "/ " + izmin + "°" + "" + "\n" + izdurum, "İzmir");
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            XDocument deneme = XDocument.Load(havadurumu_link);
            string mugla = deneme.Descendants("ili").ElementAt(5).Value;
            string mugmax = deneme.Descendants("Mak").ElementAt(5).Value;
            string mugmin = deneme.Descendants("Min").ElementAt(5).Value;
            string mugdurum = deneme.Descendants("Durum").ElementAt(5).Value;
            MessageBox.Show(mugmax + "°" + "/ " + mugmin + "°" + "" + "\n" + mugdurum, "Muğla");
        }

        private void eskisehir_Click(object sender, EventArgs e)
        {
            XDocument deneme = XDocument.Load(havadurumu_link);
            string eskisehir = deneme.Descendants("ili").ElementAt(9).Value;
            string esmax = deneme.Descendants("Mak").ElementAt(9).Value;
            string esmin = deneme.Descendants("Min").ElementAt(9).Value;
            string esdurum = deneme.Descendants("Durum").ElementAt(9).Value;
            MessageBox.Show(esmax + "°" + "/ " + esmin + "°" + "" + "\n" + esdurum, "Eskişehir");
        }

        private void afyon_Click(object sender, EventArgs e)
        {
            XDocument deneme = XDocument.Load(havadurumu_link);
            string afyonr = deneme.Descendants("ili").ElementAt(4).Value;
            string afmax = deneme.Descendants("Mak").ElementAt(4).Value;
            string afmin = deneme.Descendants("Min").ElementAt(4).Value;
            string afdurum = deneme.Descendants("Durum").ElementAt(4).Value;
            MessageBox.Show(afmax + "°" + "/ " + afmin + "°" + "" + "\n" + afdurum, "A.karahisar");

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            XDocument deneme = XDocument.Load(havadurumu_link);
            string ankara = deneme.Descendants("ili").ElementAt(8).Value;
            string ankmax = deneme.Descendants("Mak").ElementAt(8).Value;
            string ankmin = deneme.Descendants("Min").ElementAt(8).Value;
            string ankdurum = deneme.Descendants("Durum").ElementAt(8).Value;
            MessageBox.Show(ankmax + "°" + "/ " + ankmin + "°" + "" + "\n" + ankdurum, "Ankara");
        }

        private void konya_Click(object sender, EventArgs e)
        {
            XDocument deneme = XDocument.Load(havadurumu_link);
            string konya = deneme.Descendants("ili").ElementAt(10).Value;
            string konmax = deneme.Descendants("Mak").ElementAt(10).Value;
            string konmin = deneme.Descendants("Min").ElementAt(10).Value;
            string kondurum = deneme.Descendants("Durum").ElementAt(10).Value;
            MessageBox.Show(konmax + "°" + "/ " + konmin + "°" + "" + "\n" + kondurum, "Konya");

        }

        private void antalya_Click(object sender, EventArgs e)
        {
            XDocument deneme = XDocument.Load(havadurumu_link);
            string antalya = deneme.Descendants("ili").ElementAt(6).Value;
            string antmax = deneme.Descendants("Mak").ElementAt(6).Value;
            string antmin = deneme.Descendants("Min").ElementAt(6).Value;
            string antdurum = deneme.Descendants("Durum").ElementAt(6).Value;
            MessageBox.Show(antmax + "°" + "/ " + antmin + "°" + "" + "\n" + antdurum, "Antalya");
        }

        private void kastamonu_Click(object sender, EventArgs e)
        {
            XDocument deneme = XDocument.Load(havadurumu_link);
            string kastamonu = deneme.Descendants("ili").ElementAt(13).Value;
            string kasmax = deneme.Descendants("Mak").ElementAt(13).Value;
            string kasmin = deneme.Descendants("Min").ElementAt(13).Value;
            string kasdurum = deneme.Descendants("Durum").ElementAt(13).Value;
            MessageBox.Show(kasmax + "°" + "/ " + kasmin + "°" + "" + "\n" + kasdurum, "Kastamonu");
        }

        private void adana_Click(object sender, EventArgs e)
        {

            XDocument deneme = XDocument.Load(havadurumu_link);
            string adana = deneme.Descendants("ili").ElementAt(7).Value;
            string admax = deneme.Descendants("Mak").ElementAt(7).Value;
            string admin = deneme.Descendants("Min").ElementAt(7).Value;
            string addurum = deneme.Descendants("Durum").ElementAt(7).Value;
            MessageBox.Show(admax + "°" + "/ " + admin + "°" + "" + "\n" + addurum, "Adana");
        }

        private void hatay_Click(object sender, EventArgs e)
        {
            XDocument deneme = XDocument.Load(havadurumu_link);
            string hatay = deneme.Descendants("ili").ElementAt(26).Value;
            string hatmax = deneme.Descendants("Mak").ElementAt(26).Value;
            string hatmin = deneme.Descendants("Min").ElementAt(26).Value;
            string hatdurum = deneme.Descendants("Durum").ElementAt(26).Value;
            MessageBox.Show(hatmax + "°" + "/ " + hatmin + "°" + "" + "\n" + hatdurum, "Hatay");
        }

        private void trabzon_Click(object sender, EventArgs e)
        {
            XDocument deneme = XDocument.Load(havadurumu_link);
            string trabzon = deneme.Descendants("ili").ElementAt(15).Value;
            string trmax = deneme.Descendants("Mak").ElementAt(15).Value;
            string trmin = deneme.Descendants("Min").ElementAt(15).Value;
            string trdurum = deneme.Descendants("Durum").ElementAt(15).Value;
            MessageBox.Show(trmax + "°" + "/ " + trmin + "°" + "" + "\n" + trdurum, "Trabzon");
        }

        private void artvin_Click(object sender, EventArgs e)
        {
            XDocument deneme = XDocument.Load(havadurumu_link);
            string artvin = deneme.Descendants("ili").ElementAt(16).Value;
            string artmax = deneme.Descendants("Mak").ElementAt(16).Value;
            string artmin = deneme.Descendants("Min").ElementAt(16).Value;
            string artdurum = deneme.Descendants("Durum").ElementAt(16).Value;
            MessageBox.Show(artmax + "°" + "/ " + artmin + "°" + "" + "\n" + artdurum, "Artvin");
        }

        private void erzurum_Click(object sender, EventArgs e)
        {
            XDocument deneme = XDocument.Load(havadurumu_link);
            string erzurum = deneme.Descendants("ili").ElementAt(17).Value;
            string ermax = deneme.Descendants("Mak").ElementAt(17).Value;
            string ermin = deneme.Descendants("Min").ElementAt(17).Value;
            string erdurum = deneme.Descendants("Durum").ElementAt(17).Value;
            MessageBox.Show(ermax + "°" + "/ " + ermin + "°" + "" + "\n" + erdurum, "Erzurum");
        }

        private void van_Click(object sender, EventArgs e)
        {
            XDocument deneme = XDocument.Load(havadurumu_link);
            string van = deneme.Descendants("ili").ElementAt(19).Value;
            string vanmax = deneme.Descendants("Mak").ElementAt(19).Value;
            string vanmin = deneme.Descendants("Min").ElementAt(19).Value;
            string vandurum = deneme.Descendants("Durum").ElementAt(19).Value;
            MessageBox.Show(vanmax + "°" + "/ " + vanmin + "°" + "" + "\n" + vandurum, "Van");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            
            label1.Text ="SAAT:"+ DateTime.Now.ToLongTimeString();

            if (DateTime.Now.ToLongTimeString()=="18:00:00")
            {
                MessageBox.Show("BİLGİLER GÜNCELLENDİ");
            }

            if (DateTime.Now.ToLongTimeString() == "06:00:00")
            {
                MessageBox.Show("BİLGİLER GÜNCELLENDİ");
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            program();
            MessageBox.Show("Yarım saatlik veri kontrolü gerçekleşti");
           
        }

        
    }

}





