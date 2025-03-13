using System.Runtime.InteropServices;

namespace TanothClicker.Core
{
    public static class KeySimulator
    {
        // Importing user32.dll for keybd_event
        [DllImport("user32.dll", SetLastError = true)]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

        // Constants for key codes and flags
        private const int KEYEVENTF_KEYDOWN = 0x0000; // Key down flag
        private const int KEYEVENTF_KEYUP = 0x0002;   // Key up flag
        private const byte VK_SHIFT = 0x10;  // Control key code
        private const byte VK_LWIN = 0x5B;     // Left Windows key code
        private const byte VK_S = 0x53;        // 'S' key code

        public static void SimulateShiftWinS()
        {
            // Press Shift
            keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYDOWN, 0);
            // Press Win
            keybd_event(VK_LWIN, 0, KEYEVENTF_KEYDOWN, 0);
            // Press 'S'
            keybd_event(VK_S, 0, KEYEVENTF_KEYDOWN, 0);

            // Release 'S'
            keybd_event(VK_S, 0, KEYEVENTF_KEYUP, 0);
            // Release Win
            keybd_event(VK_LWIN, 0, KEYEVENTF_KEYUP, 0);
            // Release Ctrl
            keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, 0);
        }
    }
}
