using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintProgram
{
    public partial class Form1 : Form
    {
        bool mouseDown = false;
        Bitmap myBitmap;
        public Form1()
        {
            myBitmap = new Bitmap(640, 480);
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown == false)
                return;
            Graphics g = Graphics.FromImage(myBitmap);
            Pen p = new Pen(Color.Red, 2);
            g.DrawLine(p, e.X, e.Y, e.X + 1, e.Y + 1);
            p.Dispose();
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(myBitmap, 0, 0);
        }
    }
}
