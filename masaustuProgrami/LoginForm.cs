﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace masaustuProgrami
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void KatilRoundedButton_Click(object sender, EventArgs e)
        {
            if (KullaniciAdiTextBox.Text == "" || OdaIdTextBox.Text == "")
                return;
        

        }
    }
}
