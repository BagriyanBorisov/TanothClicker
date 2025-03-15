using System.Runtime.InteropServices;
using TanothClicker.Enums;
using static TanothClicker.Constants;

namespace TanothClicker.Core
{
    public static class MouseEvents
    {
        // Importing the necessary methods from user32.dll
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);


        private static void LeftClick(int x, int y)
        {
            SetCursorPos(x, y);
            mouse_event(MOUSEEVENTF_LEFTDOWN, (uint)x, (uint)y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, (uint)x, (uint)y, 0, 0);
        }

        private static void Drag(int x, int y, int x2, int y2)
        {
            SetCursorPos(x, y);
            mouse_event(MOUSEEVENTF_LEFTDOWN, (uint)x, (uint)y, 0, 0);
            SetCursorPos(x2, y2);
            mouse_event(MOUSEEVENTF_LEFTUP, (uint)x2, (uint)y2, 0, 0);
        }

        public static void AdventureClick(int i)
        {
            switch (i)
            {
                case 0:
                    LeftClick(AdventureOnexCoord, AdventureOneyCoord);
                    break;
                case 1:
                    LeftClick(AdventureTwoxCoord, AdventureTwoyCoord);
                    break;
                case 2:
                    LeftClick(AdventureThreexCoord, AdventureThreeyCoord);
                    break;
                case 3:
                    LeftClick(AdventureFourxCoord, AdventureFouryCoord);
                    break;
            }
        }

        public static void AcceptClick() => LeftClick(AcceptxCoord, AcceptyCoord);

        public static void NextClick() => LeftClick(NextxCoord, NextyCoord);

        public static void AdvMenuClick() => LeftClick(AdvMenuxCoord, AdvMenuyCoord);

        public static void SetPosition(int x, int y) => SetCursorPos(x, y);
    }
}

