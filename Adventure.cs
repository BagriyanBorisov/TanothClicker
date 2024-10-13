namespace TanothClicker
{
    public class Adventure
    {
        public Adventure(int number, int timeToFinish)
        {
            this.Number = number;
            this.TimeToFinish = timeToFinish + 1;
            this.Path = Constants.UploadsPath + Id.ToString() + ".png";
        }

        public Guid Id { get; set; } = Guid.NewGuid();

        public string Path { get; set; }
        public int Number { get; set; }
        public int TimeToFinish { get; set; }
    }
}
