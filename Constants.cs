namespace TanothClicker
{
    public static class Constants
    {
        //public static string TessDataPath = @"C:\Users\Bagri\source\repos\TanothClicker\tessdata";
        //public static string UploadsPath = @"C:\Users\Bagri\source\repos\TanothClicker\Uploads\";

        public static string ProjectRoot
        {
            get
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                // Assumes the structure: ProjectRoot\bin\Debug\net8.0-windows\
                DirectoryInfo dirInfo = new DirectoryInfo(baseDir);
                // Go up three levels:
                string projectRoot = dirInfo.Parent?.Parent?.Parent?.FullName
                                     ?? throw new Exception("Could not determine project root.");
                return projectRoot;
            }
        }

        // Now build the dynamic path for your Uploads folder at the project root.
        public static string UploadsPath
        {
            get
            {
                string path = Path.Combine(ProjectRoot, "Uploads");
                // Append the directory separator if it's not already there.
                if (!path.EndsWith(Path.DirectorySeparatorChar.ToString()))
                {
                    path += Path.DirectorySeparatorChar;
                }
                return path;
            }
        }

        // Similarly, for tessdata:
        public static string TessDataPath => Path.Combine(ProjectRoot, "tessdata");

        public static int AdventuresToday = 25;

        public static int AdventureOnexCoord = 400; /*590;*/
        public static int AdventureOneyCoord = 640; /*630;*/

        public static int AdventureTwoxCoord = 400; /*590;*/
        public static int AdventureTwoyCoord = 670;

        public static int AdventureThreexCoord = 400; /*590;*/
        public static int AdventureThreeyCoord = 710;

        public static int AdventureFourxCoord = 400; /*590;*/
        public static int AdventureFouryCoord = 750;

        public static int AcceptxCoord = 850; /*1100;*/
        public static int AcceptyCoord = 750; /*750;*/

        public static int NextxCoord = 730; /*910;*/
        public static int NextyCoord = 910; /*915;*/

        public static int AdvMenuxCoord = 100; /*350;*/
        public static int AdvMenuyCoord = 535; /*545;*/

        public static int CutImgMinutesXUpCoord = 645; /*843;*/
        public static int CutImgMinutesYUpCoord = 695; /*690;*/

        public static int CutImgMinutesXWidth = 105; /*112;*/
        public static int CutImgMinutesYHeight = 25; /*30;*/

        public static int CutImgGoldXUpCoord = 640; /*843;*/
        public static int CutImgGoldYUpCoord = 640; /*643;*/

        public static int CutImgGoldXWidth = 48;
        public static int CutImgGoldYHeight = 27; /*27;*/

        public static int CutImgExpXUpCoord = 645; /*843;*/
        public static int CutImgExpYUpCoord = 670;

        public static int CutImgExpXWidth = 38; /*42;*/
        public static int CutImgExpYHeight = 22; /*20;*/


        public static uint MOUSEEVENTF_LEFTDOWN = 0x02;
        public static uint MOUSEEVENTF_LEFTUP = 0x04;
        public static uint MOUSEEVENTF_RIGHTDOWN = 0x08;
        public static uint MOUSEEVENTF_RIGHTUP = 0x10;
        public static uint MOUSEEVENTF_MIDDLEDOWN = 0x20;
        public static uint MOUSEEVENTF_MIDDLEUP = 0x40;
    }
}
