﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tyuiu.KolchakovDR.Sprint7.Project.V3
{
    public partial class Info : Form
    {
        public Info()
        {
            InitializeComponent();
        }

        private void buttonDone_KDR_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
