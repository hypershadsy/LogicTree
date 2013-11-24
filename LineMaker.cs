using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LogicTree
{
    class LineMaker : UserControl
    {
        Panel pan;

        public LineMaker(Panel pan)
        {
            //Housing = container;
            //this.SuspendLayout();
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "LineMaker";
            this.pan = pan;

            //SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //SetStyle(ControlStyles.Opaque, true);
            //this.BackColor = Color.Transparent;

            //this.Parent = container;
            this.BackColor = Color.Red;
            //this.Size = Parent.Size;
            //this.Size = new System.Drawing.Size(10, 27);
            //this.Load += new System.EventHandler(this.LineMaker_Load);
            //this.ResumeLayout(false);
        }

        static Random rand = new Random();

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Pen thePen = new Pen(Color.FromArgb(rand.Next()));
            thePen.Width = 4;

            g.DrawLines(thePen, RandPoints(10, pan.Left, pan.Top,
                pan.Left + pan.Width, pan.Top + pan.Height));
        }

        protected static Point[] RandPoints(int howmany, int minX, int minY, int maxX, int maxY)
        {
            Point[] pts = new Point[howmany];

            for (int i = 0; i < pts.Length; i++)
            {
                pts[i] = new Point(rand.Next(minX, maxX), rand.Next(minY, maxY));
            }

            return pts;
        }
    }
}
