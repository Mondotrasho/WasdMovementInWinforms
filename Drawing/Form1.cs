using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Drawing
{
    public partial class Form1 : Form
    {
        float M_PI = 3.14159265359f;

        public struct Vector2
        {
            public float x;
            public float y;
        }

        public Vector2 Myrot;
        public Vector2 Mypos;

        private Bitmap DahPicture;

        Vector2 Rotate(Vector2 aPoint, float aDegree)
        {
            
            float rad = aDegree * M_PI / 180;
            float s = (float) Math.Sin(aDegree);
            float c = (float) Math.Cos(aDegree);
            var returnme = new Vector2();
            returnme.x = aPoint.x * c - aPoint.y * s;
            returnme.y = aPoint.y * c + aPoint.x * s;
      
            return returnme;
        }


        public Form1()
        {
            Myrot.x = 1;
            Myrot.y = 1;
            Mypos.x = 100;
            Mypos.y = 100;

            DahPicture = new Bitmap("./Pic.jpg");

            InitializeComponent();
        }

     
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //Get the Graphics Object that we will use for drawing
            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;

            //This holds the area of the window
            Rectangle clientArea = this.ClientRectangle;
            Brush backgroundBrush = new SolidBrush(Color.LightSkyBlue);
            g.FillRectangle(backgroundBrush, clientArea);

          
            //NestledSphereExample(g);
            g.FillEllipse(new SolidBrush(Color.Gray), Mypos.x, Mypos.y, 30, 30);
            g.DrawLine(new Pen(Color.Gray), Mypos.x + 15, Mypos.y+ 15,(Myrot.x * 100) + Mypos.x, (Myrot.y * 100) + Mypos.y);

            //GDI text tutorial

            Brush redBrush = new SolidBrush(Color.Red);
            Font exampleFont = new Font("Times New Roman", 24);
            g.DrawString("x = " + MousePosition.X + "  y = " + MousePosition.Y, exampleFont, redBrush, new Point(10, 10));

            g.DrawImage(DahPicture, new Point(10, 10));

            exampleFont.Dispose();
            redBrush.Dispose();

            backgroundBrush.Dispose();
        }

        private void NestledSphereExample(Graphics g)
        {
            Brush whiteBrush = new SolidBrush(Color.White);
            Brush blackBrush = new SolidBrush(Color.Black);
            Rectangle outerArea = new Rectangle(100, 100, 300, 300);
            Rectangle innerArea = new Rectangle(150, 150, 200, 200);
            g.FillEllipse(whiteBrush, outerArea);
            g.FillEllipse(blackBrush, innerArea);
            whiteBrush.Dispose();
            blackBrush.Dispose();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //moving
            if (e.KeyCode == Keys.W)
            {
                Mypos.y -= 5f;
                this.Refresh();
            }
            if (e.KeyCode == Keys.S)
            {
                Mypos.y += 5f;
                this.Refresh();
            }
            if (e.KeyCode == Keys.A)
            {
                Mypos.x -= 5f;
                this.Refresh();
            }
            if (e.KeyCode == Keys.D)
            {
                Mypos.x += 5f;
                this.Refresh();
            }
            //aiming
            if (e.KeyCode == Keys.E)
            {
                //move aim point;
                Myrot = Rotate(Myrot, -0.1f);
                this.Refresh();
                

            }
            if (e.KeyCode == Keys.Q)
            {
                //Move aim point;
                Myrot = Rotate(Myrot, 0.1f);
                this.Refresh();
            }

        }
    }
}
