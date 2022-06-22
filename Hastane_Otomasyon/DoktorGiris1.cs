﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hastane_Otomasyon
{
    public partial class DoktorGiris1 : Form
    {
        public DoktorGiris1()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Tablo_Doktor1 where DoktorTc=@p1 and DoktorSifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTcNo.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                DoktorDetay1 frm = new DoktorDetay1();
                frm.tcno = mskTcNo.Text;
                frm.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Hatalı şifre veya Tc girdiniz.");
            }
            bgl.baglanti().Close();
        }
    }
}
