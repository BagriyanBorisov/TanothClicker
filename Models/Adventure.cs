namespace TanothClicker.Models
{
    public class Adventure
    {
        public Adventure(int number)
        {
            Number = number;
            TimeToFinish = 0;
            Exp = 0;
            Gold = 0;
            Path = Constants.UploadsPath + Id.ToString(); ;
            MinutesPath = Constants.UploadsPath + Id.ToString() + "Minutes.png";
            ExpPath = Constants.UploadsPath + Id.ToString() + "Exp.png";
            GoldPath = Constants.UploadsPath + Id.ToString() + "Gold.png";
        }

        public Guid Id { get; set; } = Guid.NewGuid();

        public string Path { get; set; }
        public int Number { get; set; }
        public int TimeToFinish { get; set; }
        public string MinutesPath { get; set; }

        public int Gold { get; set; }
        public string GoldPath { get; set; }

        public int Exp { get; set; }
        public string ExpPath { get; set; }
    }
}
