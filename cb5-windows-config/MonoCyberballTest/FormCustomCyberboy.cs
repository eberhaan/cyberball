using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace MonoCyberball
{
    public partial class FormCustomCyberboy : Form
    {
        public string ballImagePath;
        public string cyberguyImagesFolder;
        private string tempGuyFolder;
        private string p;

        public FormCustomCyberboy(string customBallImage, string customBoyImages)
        {
            this.ballImagePath = p=customBallImage;
            this.cyberguyImagesFolder = tempGuyFolder= customBoyImages;
            InitializeComponent();
        }

        private void btnChangeBallImage_Click(object sender, EventArgs e)
        {
            if (ballImageDialog.ShowDialog() == DialogResult.OK)
            {
                p = ballImageDialog.FileName;
                LoadImageToBox(p);
            }
        }

        private void LoadImageToBox(string filePath)
        {
            ballPicBox.Image = Image.FromFile(filePath);
            ballPicBox.Refresh();
        }

        private void btnSelectCyberguyFolder_Click(object sender, EventArgs e)
        {
            if (cyberguyDialog.ShowDialog() == DialogResult.OK)
            {
                tempGuyFolder = cyberguyDialog.SelectedPath;
                SetCustomPicture(pbIdle, "idle.png");
                SetCustomPicture(pbCatch, "catch.png");
                SetCustomPicture(pbThrow1, "throw-1.png");
                SetCustomPicture(pbThrow2, "throw-2.png");
                SetCustomPicture(pbThrow3, "throw-3.png");
                SetCustomPicture(pbThrow4, "throw-4.png");
            }
        }

        private void SetCustomPicture(PictureBox pb, string fileName)
        {
            var file = Path.Combine(tempGuyFolder, fileName);
            if (File.Exists(file))
            {
                pb.Image = Image.FromFile(file);
                pb.Refresh();
            }
        }

        private void FormCustomCyberboy_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.ballImagePath) && File.Exists(this.ballImagePath))
            {
                LoadImageToBox(this.ballImagePath);
            }

            if (!string.IsNullOrEmpty(this.cyberguyImagesFolder) && Directory.Exists(this.cyberguyImagesFolder))
            {

                SetCustomPicture(pbIdle, "idle.png");
                SetCustomPicture(pbCatch, "catch.png");
                SetCustomPicture(pbThrow1, "throw-1.png");
                SetCustomPicture(pbThrow2, "throw-2.png");
                SetCustomPicture(pbThrow3, "throw-3.png");
                SetCustomPicture(pbThrow4, "throw-4.png");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(p))
            {
                var i=Bitmap.FromFile(p);
                var resizedImage = ResizeImage(i, 78, 78);
                p= Path.GetDirectoryName(p) +@"/" + Path.GetFileNameWithoutExtension(p) + "_78" + Path.GetExtension(p);
                resizedImage.Save(p);
                this.ballImagePath = p;
            }
            this.cyberguyImagesFolder = tempGuyFolder;
            this.DialogResult = DialogResult.OK;
            this.Close();
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
