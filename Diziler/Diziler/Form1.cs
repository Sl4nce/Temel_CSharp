using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diziler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int i = 0;
        int[] sayılar = new int[10];
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                sayılar[i] = Convert.ToInt16(textBox1.Text);
                listBox1.Items.Add(sayılar[i]);
                i++;
            }
            catch (Exception hata)
            {

                MessageBox.Show(Convert.ToString(hata));
            }
            



        }
        int toplam = 0;
        int sayac= 0;
        private void button2_Click(object sender, EventArgs e)
        {
            foreach(int x in sayılar)
            {
                if(x%4 == 0)
                {
                    listBox2.Items.Add(x);
                    toplam = toplam + x;
                    sayac++;
                }
            }
            label1.Text=Convert.ToString(toplam);
            label2.Text=Convert.ToString(sayac);

        }
    }
}
