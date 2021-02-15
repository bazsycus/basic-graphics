using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _12_grafika_bevezeto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Color szinAlap;
        //Color szin osztály
        Graphics rajzlap;
        //grafikai elem, rá tudunk rajzolni
        private void Form1_Load(object sender, EventArgs e)
        {
            szinAlap = Color.Black;
            panel1.BackColor = szinAlap;
            rajzlap = this.CreateGraphics();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            int iR, iG, iB;
            iR = trackBar1.Value;
            iB = trackBar2.Value;
            iG = trackBar3.Value;
            szinAlap = Color.FromArgb(iR,iG,iB);
            panel1.BackColor = szinAlap;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog()==DialogResult.OK)
            {
                szinAlap = cd.Color;
                panel1.BackColor = cd.Color;
                trackBar1.Value = cd.Color.R;
                trackBar2.Value = cd.Color.B;
                trackBar3.Value = cd.Color.G;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int iP1, iP2, iP3, iP4;
            iP1 = int.Parse(textBox1.Text);
            iP2 = int.Parse(textBox2.Text);
            iP3 = int.Parse(textBox3.Text);
            iP4 = int.Parse(textBox4.Text);

            Pen tollVekony = new Pen(szinAlap,2);//szín, vastagság (px)
            SolidBrush ecsetKozos = new SolidBrush(szinAlap);
            
            Point pontP12 = new Point(iP1, iP2);
            Point pontP34 = new Point(iP3, iP4);
            Rectangle teglalapP1234 = new Rectangle(iP1, iP2, iP3,iP4);
            if (radioButton1.Checked)//==true
            {
                rajzlap.DrawLine(tollVekony,iP1, iP2, iP3, iP4);//kezdőpont x-y, végpont x-y
              //  rajzlap.DrawLine(tollVekony, pontP12, pontP34);//toll, kezdőpont végpont
            }
            if (radioButton2.Checked)
            {
                rajzlap.DrawRectangle(tollVekony, iP1, iP2, iP3, iP4);
                //toll;balfelső X, balfelső Y, szélesség, magasság
                //rajzlap.DrawRectangle(tollVekony, teglalapP1234);
            }
            if (radioButton3.Checked)
            {
                rajzlap.DrawEllipse(tollVekony, iP1, iP2, iP3, iP4);
                //toll;balfelső X, balfelső Y, szélesség, magasság
            }
            if (radioButton4.Checked)
            {
                rajzlap.FillRectangle(ecsetKozos, iP1, iP2, iP3, iP4);
                
            }
            if (radioButton5.Checked)
            {
                rajzlap.FillEllipse(ecsetKozos, iP1, iP2, iP3, iP4);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rajzlap.Clear(DefaultBackColor);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //hsz felvétele
            Point[] pontaHsz = new Point[3];
            pontaHsz[0] = new Point(500, 500);
            pontaHsz[1] = new Point(700, 500);
            pontaHsz[2] = new Point(600, 267);
            //kp felvétele
            Point pontUtolso = new Point(600, 443);

            //Kirajzolni a pontokat
            SolidBrush ecsetKi = new SolidBrush(szinAlap);

            for (int i = 0; i <3; i++)
            {
                rajzlap.FillEllipse(ecsetKi, pontaHsz[i].X - 2, pontaHsz[i].Y - 2, 4, 4);
            }
            rajzlap.FillEllipse(ecsetKi, pontUtolso.X - 2, pontUtolso.Y - 2, 4, 4);

            Random rnd = new Random();

            for (int i = 0; i < 10000; i++)//10000 pont generálása :)
            {
                int iGeneralt = rnd.Next(0, 3);
                pontUtolso = new Point((int)((pontaHsz[iGeneralt].X + pontUtolso.X) / 2),
                    (int)((pontaHsz[iGeneralt].Y + pontUtolso.Y) / 2));
                rajzlap.FillEllipse(ecsetKi, pontUtolso.X - 2, pontUtolso.Y - 2, 4, 4);
            }













        }
    }
}
