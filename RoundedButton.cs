using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plug_and_Play
{
    public class RoundedButton : Button
    {
        // Fileds
        private int borderSize = 5;
        private int borderRadius = 50;
        private Color borderColor = Color.DimGray;

        //Properties
        [Category("Yuvarlak Köşeli Butonlar")]
        public int BorderSize
        {
            get => borderSize;
            set
            {
                borderSize = value;
                this.Invalidate();
            }

        }
        [Category("Yuvarlak Köşeli Butonlar")]
        public int BorderRadius
        {
            get => borderRadius;
            set
            {
                if (value <= this.Height)
                    borderRadius = value;
                else
                    borderRadius = this.Height;
                this.Invalidate();
            }
        }
        [Category("Yuvarlak Köşeli Butonlar")]
        public Color BorderColor
        {
            get => borderColor;
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }
        [Category("Yuvarlak Köşeli Butonlar")]
        public Color BackgroundColor
        {
            get { return this.BackColor; }
            set { this.BackColor = value; }
        }
        [Category("Yuvarlak Köşeli Butonlar")]
        public Color TextColor
        {
            get { return this.ForeColor; }
            set { this.ForeColor = value; }
        }

        //Constructor Methodu
        public RoundedButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(90, 90);
            this.BackColor = Color.CornflowerBlue;
            this.ForeColor = Color.White;
            this.Resize += new EventHandler(Button_Resize);
        }

        // Eğer butonun köşesi için verilmiş çapı butonun yüksekliğinden büyük ise kenar çapını butonun yüksekliğine eşitliyor
        private void Button_Resize(object sender, EventArgs e)
        {
            if (borderRadius > this.Height)
                borderRadius = this.Height;
        }

        // Girilen çapı butonun atrafına yaylar çizmesi için önce yol belirleniyor
        private GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            return path;
        }

        // Butonun çizdirilmesi durumunda butonun yolu (Path'i) belirlendikten sonra yazıdırılma methodu
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF rectBorder = new RectangleF(1, 1, this.Width - 0.8F, this.Height - 1);

            if (borderRadius > 2) // Rounded button
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - 1F))
                using (Pen penSurface = new Pen(this.Parent.BackColor, 2))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    // Button surface
                    this.Region = new Region(pathSurface);
                    // Draw surface border for HD result
                    pevent.Graphics.DrawPath(penSurface, pathSurface);

                    // Button border
                    if (borderSize >= 1)
                        // Draw control border
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                }
            }
            else // Normal button
            {
                this.Region = new Region(rectSurface);
                if (borderSize >= 1)
                {
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }

        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            if (this.DesignMode)
                this.Invalidate();
        }

    }
}
