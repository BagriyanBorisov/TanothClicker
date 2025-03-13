using static TanothClicker.Core.MouseEvents;
using static TanothClicker.Extensions;
using TanothClicker.Models;
using TanothClicker.Enums;

namespace TanothClicker.Core
{
    internal class EffiencyCalculator
    {

        public static Adventure Calculate(OcrHelper helper, ImageProcessor imageProcessor, string mode)
        {
            List<Adventure> adventures = new List<Adventure>();
            for (int i = 0; i < 4; i++)
            {
                Adventure adventure = new Adventure(i);
                AdventureClick(i);
                SleepSecs(2);
                imageProcessor.ProcessScreenScreenshot(adventure.Path);


                adventure.TimeToFinish = ExtractInt(adventure.MinutesPath, helper) + 1;
                adventure.Gold = ExtractInt(adventure.GoldPath, helper);
                adventure.Exp = ExtractInt(adventure.ExpPath, helper);

                adventures.Add(adventure);
            }

            switch (mode)
            {
                case "gold":
                    return adventures.OrderByDescending(a => a.Gold).First();
                case "exp":
                    return adventures.OrderByDescending(a => a.Exp).First();
                case "time":
                    return adventures.OrderBy(a => a.TimeToFinish).First();
                case "slow":
                    return adventures.OrderByDescending(a => a.TimeToFinish).First();
                case "fast":
                    return adventures.OrderBy(a => a.TimeToFinish).First();

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

        //private static void CutMode(Mode mode)
        //{
        //    SimulateShiftWinS();
        //    SleepSecs(2);
        //    CutImgClick(mode);
        //    SleepSecs(2);
        //}
    }
}
