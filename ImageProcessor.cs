using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TanothClicker
{
    public class ImageProcessor
    {
        public void ProcessScreenScreenshot()
        {
            // Get the bounds of the primary screen.
            Rectangle screenRect = Screen.PrimaryScreen.Bounds;

            // Capture the full screen into a Bitmap.
            using (Bitmap screenImage = new Bitmap(screenRect.Width, screenRect.Height, PixelFormat.Format24bppRgb))
            {
                using (Graphics g = Graphics.FromImage(screenImage))
                {
                    g.CopyFromScreen(screenRect.Location, Point.Empty, screenRect.Size);
                }

                // Convert the captured screen Bitmap to an Emgu CV Mat.
                Mat mat = screenImage.ToMat();

                // Define the cropping rectangle (adjust these coordinates as needed).
                // For example, this rectangle defines the region at (843, 690) with width 112 and height 30.
                Rectangle cropRect = new Rectangle(843, 690, 112, 30);

                // Ensure the cropping rectangle is within the screen bounds.
                if (screenRect.Contains(cropRect))
                {
                    // Crop the region from the Mat.
                    Mat region = new Mat(mat, cropRect);

                    // Convert the cropped region to an Emgu CV image and save it.
                    Image<Bgr, byte> croppedImage = region.ToImage<Bgr, byte>();
                    croppedImage.Save("C:/Users/Bagri/Desktop/region1.png");
                    Console.WriteLine("Cropped region saved to: C:/Users/Bagri/Desktop/region1.png");
                }
                else
                {
                    Console.WriteLine("The cropping rectangle is outside the screen bounds.");
                }
            }
        }
    }
}
