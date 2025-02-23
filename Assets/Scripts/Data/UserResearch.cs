namespace DefenceOfTheHole.Data
{
    public class UserResearch
    {
        public const int MaxLevel = 3;

        public int UserId { get; set; }

        public int ResearchId { get; set; }

        public int Level { get; set; }

        public bool IsLevelMax => Level == MaxLevel;
    }
}
