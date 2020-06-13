using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1_Semestr_2
{
    enum Operation
    {
        Plus,
        Minus,
        Multiply,
        Devide
    }
    public partial class Form1 : Form
    {
        double n1 = 0;
        double n2 = 0;
        Operation operation;
        public Form1()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_Number_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += (sender as Button).Text;
        }

        private void Clean_Button_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
        }

        private void Plus_Button_Click(object sender, EventArgs e)
        {
            this.operation = Operation.Plus;
            this.n1 = double.Parse(this.textBox1.Text);
            this.textBox1.Text = "";
        }
        private void Minus_Button_Click(object sender, EventArgs e)
        {
            this.operation = Operation.Minus;
            this.n1 = double.Parse(this.textBox1.Text);
            this.textBox1.Text = "";
        }
        private void Multiply_Button_Click(object sender, EventArgs e)
        {
            this.operation = Operation.Multiply;
            this.n1 = double.Parse(this.textBox1.Text);
            this.textBox1.Text = "";
        }
        private void Devide_Button_Click(object sender, EventArgs e)
        {
            this.operation = Operation.Devide;
            this.n1 = double.Parse(this.textBox1.Text);
            this.textBox1.Text = "";
        }

        private void Equal_Button_Click(object sender, EventArgs e)
        {
            this.n2 = double.Parse(this.textBox1.Text);
            switch (this.operation)
            {
                case Operation.Plus:
                    this.textBox1.Text = (n1 + n2).ToString();
                    break;
                case Operation.Minus:
                    this.textBox1.Text = (n1 - n2).ToString();
                    break;
                case Operation.Multiply:
                    this.textBox1.Text = (n1 * n2).ToString();
                    break;
                case Operation.Devide:
                    this.textBox1.Text = (n1 / n2).ToString();
                    break;
                default:
                    break;
            }
        }
    }
}