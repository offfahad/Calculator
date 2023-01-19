using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorTask
{
    public partial class Calculator : Form
    {
        Stack<double> mystack = new Stack<double>();
        double resultValue = 0;
        String opPerformed = "";
        bool isOpPerformed = false;
        String firstnum, secondnum;
        public Calculator()
        {
            InitializeComponent();
        }

        private void num_click(object sender, EventArgs e)
        {

            if (textBox1.Text == "0" || (isOpPerformed))
                textBox1.Text = "";
            isOpPerformed = false;
            Button num = (Button)sender;
            if (num.Text == ".")
            {
                if (!textBox1.Text.Contains("."))
                    textBox1.Text = textBox1.Text + num.Text;
            }
            else
                textBox1.Text = textBox1.Text + num.Text;
        }

        private void op_click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && textBox1.Text != ".")
            {
                Button op = (Button)sender;
                opPerformed = op.Text;
                resultValue = Double.Parse(textBox1.Text);
                label1.Text = resultValue + " " + opPerformed;
                isOpPerformed = true;
            }
            firstnum = label1.Text;
        }


        private void BtnC_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            label1.Text = null;

        }

        private void BtnEq_Click(object sender, EventArgs e)
        {
            secondnum = textBox1.Text;
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && textBox1.Text != ".")
            {
                switch (opPerformed)
                {
                    case "+":
                        textBox1.Text = (resultValue + Double.Parse(textBox1.Text)).ToString();
                    
                        break;
                    case "-":
                        textBox1.Text = (resultValue - Double.Parse(textBox1.Text)).ToString();
                   
                        break;
                    case "*":
                        textBox1.Text = (resultValue * Double.Parse(textBox1.Text)).ToString();
                   
                        break;
                    case "/":
                        textBox1.Text = (resultValue / Double.Parse(textBox1.Text)).ToString();
                        
                        break;
                    case "%":
                        textBox1.Text = (resultValue % Double.Parse(textBox1.Text)).ToString();
                      
                        break;
                    default:
                        break;
                }
                mystack.Push(resultValue);
                resultValue = Double.Parse(textBox1.Text);
                clearHistory.Visible = true;
                DisplayHistory.AppendText(firstnum + " " + secondnum + " = " + textBox1.Text + "\n");
                label2.Text = "";
            }
        }

        private void BtnCe_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
            if (textBox1.Text == "")
            {
                textBox1.Text = "0";
            }
        }

        private void ClearHistory_Click_1(object sender, EventArgs e)
        {
            DisplayHistory.Clear();
            if (label2.Text == "")
            {
                label2.Text = "No History Yet!";
            }
            DisplayHistory.Visible = true;
            DisplayHistory.ScrollBars = 0;
        }

        private void BtnMr_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = (resultValue).ToString();
            }
        }
    }
}
