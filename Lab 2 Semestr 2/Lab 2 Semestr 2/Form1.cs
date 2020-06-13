using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_2_Semestr_2
{
    public partial class Form1 : Form
    {
        int w = 75;
        int h = 41;
        int counter = 0;
        Timer timer = new Timer();
        int i = 0;
        public Form1()
        {
            InitializeComponent();
            Text = " ";
            this.MouseMove += TimerForm_MouseMove;
            this.ok.MouseEnter += Ok_MouseEnter;

            if (timer.Enabled)
            {
                timer.Enabled = false;
            }
            else
            {
                timer.Interval = 1000;
                timer.Tick += new EventHandler(timer_Tick);
                timer.Start();
            }
        }
        private void Ok_MouseEnter(object sender, EventArgs e)
        {
            Random rand = new Random();
            int x = this.ok.Location.X;
            int y = this.ok.Location.Y;
            int delta = rand.Next(50, 100);
            x = (x < this.Size.Width / 2 ? x -= delta : x += delta);
            y = (y < this.Size.Height / 2 ? y -= delta : y += delta);

            this.ok.Location = new System.Drawing.Point(x, y);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            i++;
            if (Text == " ")
            {
                Text = "Нажмите кнопку “Ок”!!!";
            }
            else if (Text == "Нажмите кнопку “Ок”!!!")
            {
                Text = " ";
            }
            if (i == 15)
            {
                timer.Stop();
            }

        }
        private void TimerForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (ok.Size.Width < 1 || ok.Size.Height < 1)
                this.Text = "Кнопка “Ок” не может быть нажата!";
            float foreSize = ok.Font.Size;
            int bX = ok.Location.X;
            int bY = ok.Location.Y;
            int delta = 30;
            int speed = 2;
            bool b = false;

            bool XLimit = e.X > bX - delta && e.X < bX;
            bool YLimit = e.Y > bY - delta && e.Y < bY;
            bool XLimitPlusSize = e.X > bX - delta + 100 && e.X < bX + 100;
            bool YLimitPlusSize = e.Y > bY - delta + 50 && e.Y < bY + 50;
            bool XRev = e.X > bX && e.X < bX - delta + 100;
            bool YRev = e.Y > bY && e.Y < bY - delta + 50;
            if (XLimit && YLimit)
            {
                this.ok.Location = new System.Drawing.Point(bX + speed, bY + speed);
                b = true; counter++;
            }
            else if (XLimitPlusSize && YLimitPlusSize)
            {
                this.ok.Location = new System.Drawing.Point(bX - speed, bY - speed);
                b = true; counter++;
            }
            else if (XLimit && YLimitPlusSize)
            {
                this.ok.Location = new System.Drawing.Point(bX + speed, bY - speed);
                b = true; counter++;
            }
            else if (XLimitPlusSize && YLimit)
            {
                this.ok.Location = new System.Drawing.Point(bX - speed, bY + speed);
                b = true; counter++;
            }
            else if (XRev && YLimit)
            {
                this.ok.Location = new System.Drawing.Point(bX, bY + speed);
                b = true; counter++;
            }
            else if (XRev && YLimitPlusSize)
            {
                this.ok.Location = new System.Drawing.Point(bX, bY - speed);
                b = true; counter++;
            }
            else if (XLimitPlusSize && YRev)
            {
                this.ok.Location = new System.Drawing.Point(bX - speed, bY);
                b = true; counter++;
            }
            else if (XLimit && YRev)
            {
                this.ok.Location = new System.Drawing.Point(bX + speed, bY);
                b = true; counter++;
            }

            int x = this.ok.Location.X;
            int y = this.ok.Location.Y;
         
            delta = 150;
            if (ok.Location.X > this.Size.Width - 80)
                x -= delta;
            else if (ok.Location.Y > this.Size.Height - 80)
                y -= delta;
            else if (ok.Location.Y < 0)
                y += delta;
            else if (ok.Location.X < 0)
                x += delta;
            this.ok.Location = new System.Drawing.Point(x, y);
            
            if (b && counter % 10 == 0)
            {
                if (ok.Size.Width > 10 || ok.Size.Height > 10)
                    this.ok.Font = new Font(ok.Font.FontFamily, foreSize -= (float)0.7);
                w -= 2;
                this.ok.Size = new System.Drawing.Size(w, --h);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}