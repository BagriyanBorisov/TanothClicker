using static TanothClicker.MouseEvents;
using static TanothClicker.Extensions;
using static TanothClicker.Constants;
using static System.Console;
using System.Text;

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

                WriteLine("Choose mode between fast or slow:");
                string mode = ReadLine();


                ClickingStart();
                for (int i = 1; i <= adventuresToday; i++)
                {
                    WriteLine("Adventure number: " + i);

                    Adventure adventure = EffiencyCalculator.Calculate(ocrHelper, screenShotSaver, mode);

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
                screenShotSaver.DeleteAllScreenshots(UploadsPath);
            }
            else
            {
                //var adventure = new Adventure(1);
                // adventure.Number = 1;
                // adventure.TimeToFinish = 18;
                // adventure.Exp = 1234;
                // adventure.Gold = 123;



                // var builder = new StringBuilder();
                // builder.AppendLine("------------------");
                // builder.AppendLine($"| Adventure: {adventure.Number}   |");
                // builder.AppendLine($"| Gold:   {adventure.Gold}   |");
                // builder.AppendLine($"| Exp:    {adventure.Exp}    |");
                // builder.AppendLine($"| Time:   {adventure.TimeToFinish}     |");
                // builder.AppendLine("------------------");

                // Console.WriteLine(builder.ToString());


                //string text = ocrHelper.ExtractTextFromImage(UploadsPath + "Screenshot 2025-03-09 135149.png");

                //Console.WriteLine(text);

                while (Console.ReadLine() != "q")
                {
                    string path = UploadsPath + Guid.NewGuid() + "test.png";
                    screenShotSaver.SaveScreenshotFromClipboard(path);
                    string text = ocrHelper.ExtractTextFromImage(path);

                    Console.WriteLine(text);

                    Console.ReadLine();
                }


                //screenShotSaver.SaveScreenshotFromClipboard(UploadsPath + "test.png");
                //string text = ocrHelper.ExtractTextFromImage(UploadsPath + "test.png");


                //Console.WriteLine(text);
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
