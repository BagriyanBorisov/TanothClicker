using static TanothClicker.MouseEvents;
using static TanothClicker.KeySimulator;
using static TanothClicker.Extensions;

namespace TanothClicker
{
    internal class EffiencyCalculator
    {
        public static Adventure Calculate(OcrHelper helper, ScreenShotSaver saver, string mode)
        {
            List<Adventure> adventures = new List<Adventure>();
            for (int i = 0; i < 4; i++)
            {
                Adventure adventure = new Adventure(i);
                AdventureClick(i);
                SleepSecs(2);

                CutMode(Mode.Gold);
                saver.SaveScreenshotFromClipboard(adventure.GoldPath);
                adventure.Gold = ExtractInt(adventure.GoldPath, helper);

                CutMode(Mode.Expirience);
                saver.SaveScreenshotFromClipboard(adventure.ExpPath);
                adventure.Exp = ExtractInt(adventure.ExpPath, helper);

                CutMode(Mode.Minutes);
                saver.SaveScreenshotFromClipboard(adventure.Path);
                adventure.TimeToFinish = ExtractInt(adventure.Path, helper) + 1;

                adventures.Add(adventure);
            }

            switch(mode)
            {
                case "gold":
                    return adventures.OrderByDescending(a => a.Gold).First();
                case "exp":
                    return adventures.OrderByDescending(a => a.Exp).First();
                case "time":
                    return adventures.OrderBy(a => a.TimeToFinish).First();
                case "both":
                    return adventures.OrderByDescending(a => a.TimeToFinish).First();

                default:
                    return adventures.OrderBy(a => a.TimeToFinish).First();

            }
        }


        private static int ExtractInt(string filePath, OcrHelper ocrHelper)
        {
            string extractedText = ocrHelper.ExtractTextFromImage(filePath);

            try
            {
                int extractedInt = int.Parse(extractedText.Trim());
                return extractedInt;
            }
            catch (Exception)
            { 
                Console.WriteLine("Could not retrieve int from: " + filePath);
            }
            return 0;
        }

        private static void CutMode(Mode mode)
        {
            SimulateShiftWinS();
            SleepSecs(2);
            CutImgClick(mode);
            SleepSecs(2);
        }
    }
}
