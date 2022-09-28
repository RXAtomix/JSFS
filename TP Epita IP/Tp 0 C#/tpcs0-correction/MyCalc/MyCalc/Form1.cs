using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "+")
                label1.Text = (nb1.Value + nb2.Value).ToString();
            else if (comboBox1.Text == "-")
                label1.Text = (nb1.Value - nb2.Value).ToString();
            else if (comboBox1.Text == "*")
                label1.Text = (nb1.Value * nb2.Value).ToString();
            else if (comboBox1.Text == "/")
                if (nb2.Value == 0)
                    label1.Text = "Undefined";
                else
                    label1.Text = (nb1.Value / nb2.Value).ToString();
            else if (comboBox1.Text == "%")
                if (nb2.Value == 0)
                    label1.Text = "Undefined";
                else
                    label1.Text = (nb1.Value % nb2.Value).ToString();
            else
                label1.Text = "Undefined";
        }
    }
}