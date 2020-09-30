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
            myBitmap = new Bitmap(640, 480); //create off screen bitmap
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true; //flag mouse button down
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false; //flag mouse button up
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown == false)
                return; //mouse not down so nothing to do
            Graphics g = Graphics.FromImage(myBitmap); //get graphics contex of off screen bitmap
            Pen p = new Pen(Color.Red, 2);
            g.DrawLine(p, e.X, e.Y, e.X + 1, e.Y + 1); //draw a point on off screen bitmap
            p.Dispose();
            Refresh(); //signify that something has been draw and windowing system should update the display
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics; //get graphics context of form (which is being displayed)
            g.DrawImageUnscaled(myBitmap, 0, 0); //put the off screen bitmap on the form
        }
    }
}
