using System.Windows.Forms;

namespace lab7_2
{
    public partial class Form1 : Form
    {
        private Bitmap originalImage;
        private Bitmap processedImage;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image files (*.bmp;*.jpg;*.jpeg;*.png)|*.bmp;*.jpg;*.jpeg;*.png"; if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                originalImage = new Bitmap(openFileDialog1.FileName);
                processedImage = new Bitmap(originalImage);
                pictureBox.Image = originalImage;
            }
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            if (processedImage != null)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "BMP files (*.bmp)|*.bmp|JPEG files (*.jpg)|*.jpg|PNG files (*.png)|*.png";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        processedImage.Save(saveFileDialog.FileName);
                    }
                }
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (originalImage != null)
            {
                processedImage = new Bitmap(originalImage);
                for (int y = 0; y < processedImage.Height; y++)
                {
                    for (int x = 0; x < processedImage.Width; x++)
                    {
                        Color pixelColor = processedImage.GetPixel(x, y);
                        Color newColor;
                        if (rbFullInversion.Checked)
                        {
                            newColor = Color.FromArgb(255 - pixelColor.R, 255 - pixelColor.G, 255 - pixelColor.B);
                        }
                        else if (rbRedInversion.Checked)
                        {
                            newColor = Color.FromArgb(255 - pixelColor.R, pixelColor.G, pixelColor.B);
                        }
                        else if (rbGreenInversion.Checked)
                        {
                            newColor = Color.FromArgb(pixelColor.R, 255 - pixelColor.G, pixelColor.B);
                        }
                        else // rbBlueInversion.Checked
                        {
                            newColor = Color.FromArgb(pixelColor.R, pixelColor.G, 255 - pixelColor.B);
                        }
                        processedImage.SetPixel(x, y, newColor);
                    }
                }
                pictureBox.Image = processedImage;
            }
        }
    }
}
