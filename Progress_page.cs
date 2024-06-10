﻿using System;
using System.Windows.Forms;

namespace Prasanna_Bhavan_Residency
{
    public partial class Progress_page : Form
    {
        public Progress_page()
        {
            InitializeComponent();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (circularProgressBar1.Value < 100)
            {
                circularProgressBar1.Value += 3;
                label1.Text = circularProgressBar1.Value.ToString() + "%";

            }
            else
            {
                timer3.Stop();
                Welcome_page welcomePage = new Welcome_page();
                welcomePage.Show();
                this.Hide();
            }
        }

        private void Progress_page_Load(object sender, EventArgs e)
        {

            timer3.Start();

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
