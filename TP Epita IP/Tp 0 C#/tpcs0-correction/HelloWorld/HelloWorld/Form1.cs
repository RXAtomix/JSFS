using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloWorld
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.BackColor == Color.Green)
            {
                button1.BackColor = Color.Yellow;
                button1.ForeColor = Color.Blue;
                button1.Text = "The code is the law.";
            }
            else
            {
                button1.BackColor = Color.Green;
                button1.ForeColor = Color.Red;
                if (textBox1.Text == "")
                    button1.Text = "Hello World!";
                else
                    button1.Text = "Hello " + textBox1.Text + "!";
            }
        }
    }
}