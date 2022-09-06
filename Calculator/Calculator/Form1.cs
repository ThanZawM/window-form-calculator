using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        double result = 0;
        string operation = "";
        bool operationPerformed = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || operationPerformed)
                textBox1.Clear();

            operationPerformed = false;

            Button btn = (Button)sender;
            
            if(btn.Text == ".")
            {
                if (!textBox1.Text.Contains("."))
                    textBox1.Text += btn.Text;
            }
            else
                textBox1.Text += btn.Text;
        }

        private void backspace_click(object sender, EventArgs e)
        {
            string str = textBox1.Text;

            if(str.Length > 0 && str != "0" && !operationPerformed)
            {
                if (str.Length == 1)
                    textBox1.Text = "0";
                else
                    textBox1.Text = str.Remove(str.Length - 1);
            }
        }

        private void button_clear(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            label1.Text = "";
            result = 0;
            operation = "";
        }

        private void oprator_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if(result != 0)
            {
                button16.PerformClick();
                operationPerformed = true;
                operation = btn.Text;
                label1.Text = result + " " + operation + " ";
            }
            else
            {
                operationPerformed = true;
                operation = btn.Text;
                result = Convert.ToDouble(textBox1.Text);
                label1.Text = result + " " + operation + " ";
            }
        }

        private void equal_click(object sender, EventArgs e)
        {
            label1.Text += textBox1.Text;

            switch (operation)
            {
                case "+":
                    textBox1.Text = (result + Convert.ToDouble(textBox1.Text)).ToString();
                    break;
                case "-":
                    textBox1.Text = (result - Convert.ToDouble(textBox1.Text)).ToString();
                    break;
                case "*":
                    textBox1.Text = (result * Convert.ToDouble(textBox1.Text)).ToString();
                    break;
                case "/":
                    textBox1.Text = (result / Convert.ToDouble(textBox1.Text)).ToString();
                    break;
                case "%":
                    textBox1.Text = (result % Convert.ToDouble(textBox1.Text)).ToString();
                    break;
                default:
                    break;
            }

            result = Convert.ToDouble(textBox1.Text);
        }

        private void pow_2(object sender, EventArgs e)
        {
            result = Math.Pow(Convert.ToDouble(textBox1.Text), 2);
            label1.Text = textBox1.Text + " pow 2";
            textBox1.Text = result.ToString();
        }

        private void pow_3(object sender, EventArgs e)
        {
            result = Math.Pow(Convert.ToDouble(textBox1.Text), 3);
            label1.Text = textBox1.Text + " pow 3";
            textBox1.Text = result.ToString();
        }

        private void sqrt_root(object sender, EventArgs e)
        {
            result = Math.Sqrt(Convert.ToDouble(textBox1.Text));
            label1.Text = "sqrt root of " + textBox1.Text;
            textBox1.Text = result.ToString();
        }

        private void cube_root(object sender, EventArgs e)
        {
            result = Math.Pow(Convert.ToDouble(textBox1.Text), (1.0/3.0));
            label1.Text = "cube root of " + textBox1.Text;
            textBox1.Text = result.ToString();
        }
    }
}
