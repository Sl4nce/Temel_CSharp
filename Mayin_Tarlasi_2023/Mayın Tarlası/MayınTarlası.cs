using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.OleDb;
using System.Data.Common;

namespace Mayın_Tarlası
{
    public partial class MayınTarlası : Form
    {
        public MayınTarlası()
        {
            InitializeComponent();
        }
       
        
        private void Yenile()
        {
            string baglantiyolu = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\Puanlar.mdb";
            string sorgu = "SELECT * FROM puan_tablosu";

            using (OleDbConnection baglanti = new OleDbConnection(baglantiyolu))
            {
                baglanti.Open();
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(sorgu, baglanti))
                {
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "puan_tablosu");
                    dataGridView1.DataSource = dataSet.Tables["puan_tablosu"];
                }
                baglanti.Close();
            }
        }


        static string baglantiyolu = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\Puanlar.mdb";
        
        public OleDbConnection baglanti = new OleDbConnection(baglantiyolu);
       public string sorgu = "SELECT * FROM puan_tablosu";


        private void MayınTarlası_Load(object sender, EventArgs e)
        {
            
            timer1.Start();
            this.Icon = new Icon(Application.StartupPath + "\\selcuk.ico");
            
            Yenile();


        }
        

        Random rnd = new Random();
        List<int> mayın = new List<int>();
        int puan, dmayınkutusu = 0, mayinsayisi = 0, box = 0;


        public void Başla(string mod)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen isim giriniz.");
                return;
            }
            flowLayoutPanel1.Controls.Clear();
            mayın.Clear();
            dmayınkutusu = 0;
            mayinsayisi = 0;
            box = 0;
            puan = 0;
            label4.Text = "PUAN: 0";

            flowLayoutPanel1.Size = new Size(470, 470);
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;

            if (mod == "Kolay") mayinsayisi = 10;
            else if (mod == "Orta") mayinsayisi = 25;
            else if (mod == "Zor") mayinsayisi = 40;

            for (int i = 0; i < 10; i++)
            {
                for (int x = 0; x < 10; x++)
                {
                    Button btn = new Button();
                    btn.BackColor = Color.Blue;
                    btn.Size = new Size(40, 40);
                    btn.Name = box.ToString();
                    flowLayoutPanel1.Controls.Add(btn);
                    box++;
                }
            }

            int randomsayi;
            for (int i = 0; i < mayinsayisi; i++)
            {
                do
                {
                    randomsayi = rnd.Next(0, 100);

                } while (mayın.Contains(randomsayi));

                mayın.Add(randomsayi);
            }

            ButtonClickAyarla();
        }

        private void ButtonClickAyarla()
        {
            foreach (Control ctl in flowLayoutPanel1.Controls)
            {
                ctl.MouseClick += new MouseEventHandler(FlowLayoutPanel_MouseClick);
            }
        }

        void FlowLayoutPanel_MouseClick(object sender, MouseEventArgs e)
        {
            Event(sender);
        }

        public void Event(object sender)
        {
            if (sender.GetType().Name == "Button")
            {
                Button mayınkutusu = (Button)sender;
                if (mayınkutusu.BackColor != Color.Green && mayınkutusu.BackColor != Color.Red)
                {
                    string isim = mayınkutusu.Name;
                    if (mayın.IndexOf(Convert.ToInt32(isim)) != -1) // Yandın
                    {
                        string sorgu = "INSERT INTO puan_tablosu ( Tarih,Ad , Puan) VALUES (@Tarih, @Ad, @Puan)";
                        OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
                        string ad = textBox1.Text;
                        DateTime tarih = DateTime.Today;




                        komut.Parameters.AddWithValue("@Tarih", tarih);
                        komut.Parameters.AddWithValue("@Ad", ad);
                        komut.Parameters.AddWithValue("@Puan", puan);



                        baglanti.Open();
                        komut.ExecuteNonQuery();
                        baglanti.Close();


                        
                        mayınkutusu.BackColor = Color.Red;
                        mayınkutusu.Image = Image.FromFile(Application.StartupPath+ "\\mayin.png");
                        HepsiniAc();
                        MessageBox.Show("Kaybettiniz. \nToplam Puan: " + puan);
                        Yenile();

                        






                    }
                    else // Kazandın
                    {

                        mayınkutusu.BackColor = Color.Green;
                        int tikpuan = 0;
                        if (radioButton1.Checked)
                        {
                            tikpuan = 1;
                        }
                        else if (radioButton2.Checked)
                        {
                            tikpuan = 3;
                        }
                        else if (radioButton3.Checked)
                        {
                            tikpuan = 5;
                        }

                        puan += tikpuan;
                        mayınkutusu.Text = tikpuan.ToString();
                        label4.Text = "PUAN: " + puan.ToString();

                        int adjacentMineCount = 0;
                        int index = flowLayoutPanel1.Controls.IndexOf(mayınkutusu);
                        int row = index / 10;
                        int col = index % 10;

                        for (int i = Math.Max(row - 1, 0); i <= Math.Min(row + 1, 9); i++)
                        {
                            for (int j = Math.Max(col - 1, 0); j <= Math.Min(col + 1, 9); j++)
                            {
                                int buttonIndex = i * 10 + j;
                                Control control = flowLayoutPanel1.Controls[buttonIndex];
                                if (control != null && control.GetType().Name == "Button")
                                {
                                    Button adjacentButton = (Button)control;
                                    if (mayın.IndexOf(buttonIndex) != -1)
                                    {
                                        adjacentMineCount++;
                                    }
                                }
                            }
                        }

                        mayınkutusu.Text = adjacentMineCount.ToString();
                        toolStripProgressBar1.Maximum = 100 - mayinsayisi;
                        toolStripProgressBar1.Value = dmayınkutusu;

                        if (dmayınkutusu == 100 - mayinsayisi)
                        {
                            HepsiniAc();
                            MessageBox.Show("Kazandınız \nToplam Puan: " + puan);
                        }
                        else
                        {
                            dmayınkutusu++;
                        }
                    }
                }
            }
        }

        private void HepsiniAc()
        {
            for (int i = 0; i < 100; i++)
            {
                Button buton = (Button)flowLayoutPanel1.Controls[i];
                if (mayın.IndexOf(i) != -1)
                {
                    buton.BackColor = Color.Red;
                    buton.BackgroundImageLayout = ImageLayout.Stretch;
                    buton.BackgroundImage = Image.FromFile(Application.StartupPath + "\\mayin.png");
                }
                else
                {
                    buton.BackColor = Color.Green;
                }
            }
        }





        private void btn_oyna_Click(object sender, EventArgs e)
        {
            
            if (radioButton1.Checked == true)
                Başla("Kolay");
            else if (radioButton2.Checked == true)
                Başla("Orta");
            else if (radioButton3.Checked == true)
                Başla("Zor");
            else
                MessageBox.Show("Zorluk Seçin");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string saat =DateTime.Now.ToLongTimeString();
            string saniye=DateTime.Now.Second.ToString();
            
            toolStripStatusLabel2.Text = "Saat : "+saat;
        }

        

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                label1.Text = "Mayın Sayısı=10";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
                label1.Text = "Mayın Sayısı=25";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
                label1.Text = "Mayın Sayısı=40";
        }
        
    }
}
