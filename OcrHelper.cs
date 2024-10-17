using Tesseract;

namespace TanothClicker
{
    public class OcrHelper
    {
        private readonly string tessDataPath;

        public OcrHelper(string tessDataPath)
        {
            this.tessDataPath = tessDataPath;
        }

        // Method to extract text from an image using language OCR
        public string ExtractTextFromImage(string imagePath)
        {
            try
            {
                using (var engine = new TesseractEngine(tessDataPath, "eng", EngineMode.Default))
                {
                    engine.SetVariable("tessedit_char_whitelist", "0123456789");
                    using (var img = Pix.LoadFromFile(imagePath))
                    {
                        using (var page = engine.Process(img))
                        {
                            string text = page.GetText();
                            return text;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error during OCR processing: {ex.Message}";
            }
        }
    }
}
