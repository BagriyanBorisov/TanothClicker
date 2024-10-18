using static TanothClicker.MouseEvents;
using static TanothClicker.Extensions;
using static TanothClicker.Constants;
using static System.Console;

namespace TanothClicker
{
    class Program
    {
        static void Main(string[] args)
        {
            ScreenShotSaver screenShotSaver = new ScreenShotSaver();
            OcrHelper ocrHelper = new OcrHelper(TessDataPath);

            WriteLine("Tanoth Clicker");
            WriteLine("Press s to start");

            string toggle = ReadLine();

            if (toggle == "exit")
            {
                return;
            }
            else if (toggle == "s")
            {
                WriteLine("Enter number of adventures to do:");
                int adventuresToday = Convert.ToInt32(ReadLine());

                WriteLine("Choose mode between gold, exp and time:");
                string mode = ReadLine();


                ClickingStart();
                for (int i = 1; i <= adventuresToday; i++)
                {
                    WriteLine("Adventure number: " + i);
                    WriteLine("------------------------------");

                    Adventure adventure = EffiencyCalculator.Calculate(ocrHelper, screenShotSaver, mode);


                    AdventureClick(adventure.Number);
                    SleepSecs(2);

                    AcceptClick();

                    WriteLine("Sleeping for " + adventure.TimeToFinish + " minutes");
                    SleepMins(adventure.TimeToFinish);

                    NextClick();
                    SleepSecs(2);

                    AdvMenuClick();
                    SleepSecs(2);
                }
                //Delete all screenshots
                screenShotSaver.DeleteAllScreenshots(UploadsPath);
            }
            else
            {
                string text = ocrHelper.ExtractTextFromImage(UploadsPath + "ab17405e-3b4c-49b0-82e8-ed33dce48b05Gold.png");

                Console.WriteLine("Test pos");
                for (int i = 0; i < 100; i++)
                {
                    WriteLine("------------------------------");
                    WriteLine("Enter new x and y coordinates: ");

                    int newxCoord = Convert.ToInt32(ReadLine());
                    int newyCoord = Convert.ToInt32(ReadLine());

                    SetPosition(newxCoord, newyCoord);
                }
            }
        }
    }
}
