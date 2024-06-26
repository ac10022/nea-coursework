using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nea_prototype_full
{
    public partial class LargeImageDisplay : Form
    {
        public LargeImageDisplay(Image imageRef = null)
        {
            InitializeComponent();
            if (imageRef != null)
            {
                Image imageToDisplay = ResizeImageToWidth(imageRef, pictureBox1.Width);
                pictureBox1.Height = imageToDisplay.Height;
                pictureBox1.Image = imageToDisplay;
            }
        }

        private Image ResizeImageToWidth(Image image, int width)
        {
            double resizeRatio = image.Width / (double)width;
            return new Bitmap(image, new Size(width, (int)Math.Round(image.Height / resizeRatio)));
        }
    }
}
