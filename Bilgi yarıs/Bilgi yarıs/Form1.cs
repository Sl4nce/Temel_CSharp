using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bilgi_yarıs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        int dogru = 0, yanlıs = 0, soruno = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            button5.Enabled = true;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            label8.Text = button2.Text;
            if (label8.Text == label7.Text)
            {
                dogru++;
                label5.Text = dogru.ToString();
                pictureBox1.Visible = true;
            }
            else
            {
                yanlıs++;
                label6.Text = yanlıs.ToString();
                pictureBox2.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = true;
            label8.Text = button3.Text;
            if (label8.Text == label7.Text)
            {
                dogru++;
                label5.Text = dogru.ToString();
                pictureBox1.Visible = true;
            }
            else
            {
                yanlıs++;
                label6.Text = yanlıs.ToString();
                pictureBox2.Visible = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = true;
            label8.Text = button4.Text;
            if (label8.Text == label7.Text)
            {
                dogru++;
                label5.Text = dogru.ToString();
                pictureBox1.Visible = true;
            }
            else
            {
                yanlıs++;
                label6.Text = yanlıs.ToString();
                pictureBox2.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = true;
            label8.Text = button1.Text;
            if (label8.Text ==label7.Text)
            {
                dogru++;
                label5.Text=dogru.ToString();
                pictureBox1.Visible = true;
            }
            else
            {
                yanlıs++;
                label6.Text = yanlıs.ToString();
                pictureBox2.Visible = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
           soruno++;
            label4.Text=soruno.ToString();
            
            if (soruno==1)
            {
                button5.Text = "Sonraki";
                richTextBox1.Text = "Cumhuriyet kaç yılında kurulmuştur?";
                button1.Text = "1920";
                button2.Text = "1925";
                button3.Text = "1923";
                button4.Text = "1926";
                label7.Text = "1923";
                

            } 
            if (soruno==2)
            {
                button5.Text = "Sonraki";
                richTextBox1.Text = "1950'li yılların sonlarında tahılları yedikleri gerekçesiyle ülkesindeki tüm serçelerin öldürülmesini emreden ünlü dikdatör kimdir?";
                button1.Text = "Josef Stalin";
                button2.Text = "Adolf Hitler";
                button3.Text = "Mao ZeDong";
                button4.Text = "İsmet İnonu";
                label7.Text = "Mao ZeDong";
            }
            if (soruno == 3)
            {
                richTextBox1.Text = "1972’de Apollo 17 uzay aracı mürettebatınca çekilen ve yerküreyi bütün olarak gösteren ünlü fotoğrafın adı nedir?";
                button1.Text = "Mavi Cisim";
                button2.Text = "Mavi Gezegen";
                button3.Text = "Mavi Bilye";
                button4.Text = "Mavi Boncuk";
                label7.Text = "Mavi Bilye";
                button5.Text = "Sonuçlar";
            }
            if(soruno==4)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
               
                MessageBox.Show("Dogru Sayısı: " + dogru+"\n"+ "Yanlıs Sayısı: "+ yanlıs);
                
                
            }
            button5.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }
    }
}
