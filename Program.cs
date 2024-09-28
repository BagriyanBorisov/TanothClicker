namespace TanothClicker
{
   
    using System.Runtime.InteropServices;
    using System.Threading;

    class Program
    {
        // Importing the necessary methods from user32.dll
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        // Constants for mouse events
        private const uint MOUSEEVENTF_LEFTDOWN = 0x02;
        private const uint MOUSEEVENTF_LEFTUP = 0x04;

        static void Main(string[] args)
        {
            
            int AcceptxCoord = 1100;  
            int AcceptyCoord = 750;  

            int AdventurexCoord = 590;
            int AdventureyCoord = 750;
            Console.WriteLine("Tanoth Clicker");
            Console.WriteLine("Press any key to start");

            string toggle  = Console.ReadLine();

            if(toggle == "exit")
            {
                return;
            }
            else if(toggle == "start")
            {
                Console.WriteLine("Clicking will start in 5 seconds");
                Thread.Sleep(1000);  // 5 seconds
                Console.WriteLine("Clicking will start in 4 seconds");
                Thread.Sleep(1000);  // 5 seconds
                Console.WriteLine("Clicking will start in 3 seconds");
                Thread.Sleep(1000);  // 5 seconds
                Console.WriteLine("Clicking will start in 2 seconds");
                Thread.Sleep(1000);  // 5 seconds
                Console.WriteLine("Clicking will start in 1 second");
                Thread.Sleep(1000);  // 5 seconds
            }


            for (int i = 0; i < 15; i++)
            {
                // Move the mouse to the desired location
                SetCursorPos(AdventurexCoord, AdventureyCoord);

                mouse_event(MOUSEEVENTF_LEFTDOWN, (uint)AdventurexCoord, (uint)AdventureyCoord, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, (uint)AdventurexCoord, (uint)AdventureyCoord, 0, 0);

                Thread.Sleep(3000);  // 3 seconds

                // Move the mouse to the desired location
                SetCursorPos(AcceptxCoord, AcceptyCoord);

                mouse_event(MOUSEEVENTF_LEFTDOWN, (uint)AcceptxCoord, (uint)AcceptyCoord, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, (uint)AcceptxCoord, (uint)AcceptyCoord, 0, 0);

                Thread.Sleep(20 * 60 * 1000);  // 20 minutes
            }
        }
    }

}
