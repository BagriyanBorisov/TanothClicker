using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing.Imaging;
using static TanothClicker.Constants;

namespace TanothClicker.Core
{
    public class ImageProcessor
    {
        public void ProcessScreenScreenshot(string filePath)
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
                List<Rectangle> cropRects = CutRectangles();

                // Ensure the cropping rectangle is within the screen bounds.
                if (screenRect.Contains(cropRects[0]))
                {
                    // Crop the region from the Mat.
                    Mat minRegion = new Mat(mat, cropRects[0]);
                    Mat goldRegion = new Mat(mat, cropRects[1]);
                    Mat expRegion = new Mat(mat, cropRects[2]);

                    // Convert the cropped region to an Emgu CV image and save it.
                    Image<Bgr, byte> croppedMinImage = minRegion.ToImage<Bgr, byte>();
                    croppedMinImage.Save(filePath + "Minutes.png");

                    Image<Bgr, byte> croppedGoldImage = goldRegion.ToImage<Bgr, byte>();
                    croppedGoldImage.Save(filePath + "Gold.png");

                    Image<Bgr, byte> croppedExpImage = expRegion.ToImage<Bgr, byte>();
                    croppedExpImage.Save(filePath + "Exp.png");

                    Console.WriteLine($"Cropped regions saved to: {filePath}");
                }
                else
                {
                    Console.WriteLine("The cropping rectangle is outside the screen bounds.");
                }
            }
        }


        private List<Rectangle> CutRectangles()
        {
            return new List<Rectangle>
            {
                new Rectangle(CutImgMinutesXUpCoord, CutImgMinutesYUpCoord, CutImgMinutesXWidth, CutImgMinutesYHeight),
                new Rectangle(CutImgGoldXUpCoord, CutImgGoldYUpCoord, CutImgGoldXWidth, CutImgGoldYHeight),
                new Rectangle(CutImgExpXUpCoord, CutImgExpYUpCoord, CutImgExpXWidth, CutImgExpYHeight)
            };
        }

        internal void DeleteAllScreenshots(string folderPath)
        {
            try
            {
                // Check if the folder exists
                if (Directory.Exists(folderPath))
                {
                    // Get all files in the directory
                    string[] files = Directory.GetFiles(folderPath);

                    foreach (string file in files)
                    {
                        // Delete each file
                        File.Delete(file);
                        Console.WriteLine($"Deleted file: {file}");
                    }

                    Console.WriteLine("All files deleted successfully.");
                }
                else
                {
                    Console.WriteLine("The specified folder does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting files: " + ex.Message);
            }
        }
    }
}
