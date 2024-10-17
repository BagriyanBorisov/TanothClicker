using static TanothClicker.MouseEvents;
using static TanothClicker.Extensions;
using static TanothClicker.Constants;

namespace TanothClicker
{
    class Program
    {
        static void Main(string[] args)
        {
            ScreenShotSaver screenShotSaver = new ScreenShotSaver();
            OcrHelper ocrHelper = new OcrHelper(TessDataPath);

            Console.WriteLine("Tanoth Clicker");
            Console.WriteLine("Press s to start");

            string toggle = Console.ReadLine();

            if (toggle == "exit")
            {
                return;
            }
            else if (toggle == "s")
            {
                Console.WriteLine("Enter number of adventures to do:");
                int adventuresToday = Convert.ToInt32(Console.ReadLine());
                ClickingStart();
                for (int i = 1; i <= adventuresToday; i++)
                {
                    Console.WriteLine("Adventure number: " + i);
                    Console.WriteLine("------------------------------");

                    Adventure adventure = EffiencyCalculator.Calculate(ocrHelper, screenShotSaver);
                    int minsToSleep = adventure.TimeToFinish;

                    AdventureClick(adventure.Number);
                    SleepSecs(2);

                    AcceptClick();

                    Console.WriteLine("Sleeping for " + minsToSleep + " minutes");
                    SleepMins(minsToSleep);

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
                Console.WriteLine("Test pos");
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("Enter new x and y coordinates: ");

                    int newxCoord = Convert.ToInt32(Console.ReadLine());
                    int newyCoord = Convert.ToInt32(Console.ReadLine());

                    SetPosition(newxCoord, newyCoord);
                }
            }
        }
    }
}
