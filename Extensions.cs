namespace TanothClicker
{
    public static class Extensions
    {
        public static void SleepMins(int v)
        {
            Thread.Sleep(v * 60 * 1000);
        }

        public static void SleepSecs(int v)
        {
            Thread.Sleep(v * 1000);
        }

        public static void ClickingStart()
        {
            Console.WriteLine("Clicking will start in 5 seconds");
            SleepSecs(1);
            Console.WriteLine("Clicking will start in 4 seconds");
            SleepSecs(1);
            Console.WriteLine("Clicking will start in 3 seconds");
            SleepSecs(1);
            Console.WriteLine("Clicking will start in 2 seconds");
            SleepSecs(1);
            Console.WriteLine("Clicking will start in 1 second");
            SleepSecs(1);
        }
    }
}
