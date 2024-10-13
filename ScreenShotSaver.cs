using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace TanothClicker
{
    class ScreenShotSaver
    {
        // Clipboard API from user32.dll
        [DllImport("user32.dll")]
        public static extern bool OpenClipboard(IntPtr hWndNewOwner);

        [DllImport("user32.dll")]
        public static extern bool CloseClipboard();

        [DllImport("user32.dll")]
        public static extern IntPtr GetClipboardData(uint uFormat);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CopyImage(IntPtr h, uint type, int cx, int cy, uint flags);

        private const uint CF_BITMAP = 2;

        public void SaveScreenshotFromClipboard(string filePath)
        {
            try
            {
                // Open the clipboard
                if (OpenClipboard(IntPtr.Zero))
                {
                    // Get the handle to the bitmap
                    IntPtr hBitmap = GetClipboardData(CF_BITMAP);

                    if (hBitmap != IntPtr.Zero)
                    {
                        // Convert the handle to a .NET Bitmap
                        Bitmap bitmap = Image.FromHbitmap(hBitmap);

                        // Save the bitmap to the specified file path
                        bitmap.Save(filePath, ImageFormat.Png);

                        Console.WriteLine("Screenshot saved to: " + filePath);
                    }
                    else
                    {
                        Console.WriteLine("No image found in clipboard.");
                    }

                    // Close the clipboard
                    CloseClipboard();
                }
                else
                {
                    Console.WriteLine("Unable to open clipboard.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving screenshot: " + ex.Message);
            }
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
