namespace TanothClicker
{
    public class Adventure
    {
        public Adventure(int number)
        {
            this.Number = number;
            this.TimeToFinish = 0;
            this.Path = Constants.UploadsPath + Id.ToString() + "Minutes.png";
            this.Exp = 0;
            this.Gold = 0;
            this.ExpPath = Constants.UploadsPath + Id.ToString() + "Exp.png";
            this.GoldPath = Constants.UploadsPath + Id.ToString() + "Gold.png";
        }

        public Guid Id { get; set; } = Guid.NewGuid();

        public string Path { get; set; }
        public int Number { get; set; }
        public int TimeToFinish { get; set; }

        public int Gold { get; set; }
        public string GoldPath { get; set; }

        public int Exp { get; set; }
        public string ExpPath { get; set; }
    }
}
