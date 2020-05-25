using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Temp
{
    public partial class Form1 : Form
    {
        string cleanMe(TextBox obj) 
        { 
            return obj.Text.Trim().Replace(",", ""); 
        }

        static string[] types = { "Farenheit", "Celsius", "Kelvin" };

        public Form1()
        {
            InitializeComponent();
        }

        static string[] conversions = { "Farenheit", "Celsius", "Kelvin" };
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string type in conversions) { comboBox1.Items.Add(type); }
            comboBox1.SelectedIndex = 0;

            foreach (string type in conversions) { comboBox2.Items.Add(type); }
            comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int value; 
            try 
            { 
                value = Convert.ToInt32(cleanMe(textBox1)); 
            } 
            catch 
            { 
                MessageBox.Show("The input value is in error."); 
                return; 
            }

            if(comboBox1.SelectedIndex == comboBox2.SelectedIndex)
            {
                label1.Text = String.Format("{0}", textBox1.Text);
            }
            else if (comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex == 1)
            {
                double ans = ((value - 32) * 5 / 9) + 0.00;
                label1.Text = String.Format("{0}", ans);
            }
            else if (comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex == 2)
            {
                double ans = ((value - 32) * 5 / 9) + 273.15;
                label1.Text = String.Format("{0}", ans);
            }
            else if (comboBox1.SelectedIndex == 1 && comboBox2.SelectedIndex == 0)
            {
                double ans = (((value * 9) / 5 ) + 32) + 0.00;
                label1.Text = String.Format("{0}", ans);
            }
            else if (comboBox1.SelectedIndex == 1 && comboBox2.SelectedIndex == 2)
            {
                double ans = value + 273.15;
                label1.Text = String.Format("{0}", ans);
            }
            else if (comboBox1.SelectedIndex == 2 && comboBox2.SelectedIndex == 0)
            {
                double ans = ((( (value - 273.15) * 9) / 5) + 32) + 0.00;
                label1.Text = String.Format("{0}", ans);
            }
            else if (comboBox1.SelectedIndex == 2 && comboBox2.SelectedIndex == 1)
            {
                double ans = value - 273.15;
                label1.Text = String.Format("{0}", ans);
            }
            else
            {
                return;
            }

            textBox1.Text = String.Empty; // same as ""
        }
    }
}
