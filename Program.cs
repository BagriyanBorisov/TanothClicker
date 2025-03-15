using TanothClicker.Core;
using TanothClicker.Models;
using static System.Console;
using static TanothClicker.Constants;
using static TanothClicker.Extensions;
using static TanothClicker.Core.MouseEvents;

namespace TanothClicker
{
    class Program
    {
        static void Main(string[] args)
        {
            ImageProcessor imageProcessor = new ImageProcessor();
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

                WriteLine("Choose mode between fast or slow:");
                string mode = ReadLine();


                ClickingStart();
                for (int i = 1; i <= adventuresToday; i++)
                {
                    WriteLine("Adventure number: " + i);

                    Adventure adventure = EffiencyCalculator.Calculate(ocrHelper, imageProcessor, mode);

                    AdventureClick(adventure.Number);
                    SleepSecs(2);

                    AcceptClick();

                    PrintAdventure(adventure);
                    SleepMins(adventure.TimeToFinish);

                    NextClick();
                    SleepSecs(2);

                    AdvMenuClick();
                    SleepSecs(2);
                   
                }
                //Delete all screenshots
                imageProcessor.DeleteAllScreenshots(UploadsPath);
            }
            else
            {
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
