using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jovo
{
    public partial class formSettings : Form
    {
        ModuleHandler module;

        public formSettings(ModuleHandler _module)
        {
            module = _module;
            InitializeComponent();
        }

        private void formSettings_Load(object sender, EventArgs e)
        {
            //rgb(245, 246, 250)
            Panel def = new Panel();
            def.Size = new Size(48, 48);
            def.Location = new Point(8, 8);
            def.BackColor = Color.FromArgb(236, 236, 236);
            def.BackgroundImage = Properties.Resources.settings;
            def.BackgroundImageLayout = ImageLayout.Center;
            def.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(def);

            int y = 8;
            foreach (ModuleData data in module.Modules)
            {
                y += 47;
                Panel pnl = new Panel();
                pnl.Size = new Size(48, 48);
                pnl.Location = new Point(8, y);
                pnl.BackColor = Color.FromArgb(218, 223, 225);
                pnl.BackgroundImage = ResizeImage(Image.FromFile(data.Path + "\\" + data.Icon), 25, 25);
                pnl.BackgroundImageLayout = ImageLayout.Center;
                pnl.BorderStyle = BorderStyle.FixedSingle;
                this.Controls.Add(pnl);
            }

            Panel settings = new Panel();
            settings.Size = new Size(this.ClientSize.Width - 63, this.ClientSize.Height - 16);
            settings.Location = new Point(55, 8);
            settings.BackColor = Color.FromArgb(236, 236, 236);
            settings.BackgroundImage = Properties.Resources.settings;
            settings.BackgroundImageLayout = ImageLayout.Center;
            settings.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(settings);

        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}
