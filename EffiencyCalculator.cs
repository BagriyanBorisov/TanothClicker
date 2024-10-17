using static TanothClicker.MouseEvents;
using static TanothClicker.KeySimulator;
using static TanothClicker.Extensions;

namespace TanothClicker
{
    internal class EffiencyCalculator
    {
        public static Adventure Calculate(OcrHelper helper, ScreenShotSaver saver)
        {
            List<Adventure> adventures = new List<Adventure>();
            for (int i = 0; i < 4; i++)
            {
                Adventure adventure = new Adventure(i, 0);
                AdventureClick(i);
                SleepSecs(2);

                SimulateShiftWinS();
                SleepSecs(2);

                CutImgClick();
                SleepSecs(2);

                saver.SaveScreenshotFromClipboard(adventure.Path);
                adventure.TimeToFinish = GetMinsToSleep(adventure.Path, helper) + 1;

                adventures.Add(adventure);
            }
            return adventures.OrderByDescending(a => a.TimeToFinish).First();
        }


        static int GetMinsToSleep(string filePath, OcrHelper ocrHelper)
        {
            string extractedText = ocrHelper.ExtractTextFromImage(filePath);

            int extractedInt = int.Parse(extractedText.Trim());
            Console.WriteLine("Extracted int: " + extractedInt);

            return extractedInt;
        }
    }
}
