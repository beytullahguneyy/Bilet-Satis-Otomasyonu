using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bilet_Satış
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Data.DataTable_Yolcular();
            duzenkur();
        }


        void duzenkur()
        {
            int sayi = 0;
            panel1.Controls.Clear();
            int yolcu = 38;
            for (int i = 0; i < textBox1.Lines.Count(); i++)
            {
                for (int j = 0; j < textBox1.Lines[i].Count(); j++)
                {
                    string satir = textBox1.Lines[i];
                    if (satir[j] == '*')
                    {
                        Button b = new Button();
                        b.Text = (++sayi).ToString();
                        b.Name = "buton_" + b.Text;
                        b.BackColor = Color.Gray;
                        b.Width = b.Height = 40;
                        b.Left = yolcu * j;
                        b.Top = yolcu * i;
                        panel1.Controls.Add(b);
                        b.Click += ButtonClick;

                    }
                }
            }

        }
        private void ButtonClick(object sender, EventArgs e)
        {
            string ddurum = " ";
            Button btn = (Button)sender;

            islem_yap fonk = new islem_yap();
            fonk.koltuk_no.Text = btn.Name.Split('_')[1];
            fonk.ShowDialog();

            int durum = fonk.comboBox2.SelectedIndex + 1;
            string cinsiyet = fonk.comboBox1.Text;

            if (durum == 1)
            {
                 ddurum = "Satıldı";
            }
            else
            {
                 ddurum = "İade";
            }
            
            if (fonk.doğrula == 1)
            {
                
                Data.DataTable_Yolcular_Insert (Convert.ToInt32(fonk.koltuk_no.Text),ddurum,fonk.textBox1.Text,cinsiyet,fonk.islem_yapan.Text);
                switch (durum)
                {
                    case 1:
                        if (cinsiyet == "Erkek ")
                        {
                            btn.BackColor = Color.Aqua;
                            break;
                        }
                        else
                        {
                            btn.BackColor = Color.Pink;
                            break;
                        }
                    case 2:
                        btn.BackColor = Color.Red;
                        break;
                }
                dgv_update();
            }

        }
        private void dgv_update()
        {
            dataGridView1.DataSource = Data.table;
        }

    }
}
