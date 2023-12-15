using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loginprojesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == "18781816628" && textBox1.Text == "1453")
            {
                MessageBox.Show("Hoşgeldiniz Yusuf Bayhan");

            }

            else
            {
                MessageBox.Show("Şifreniz veya Kullanıcı adınız yanlış");
            }

            
        }
    }
}
