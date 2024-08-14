namespace ASP.NET_Core_Web_API__1.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Length { get; set; }

        public Guid RegionId { get; set; }

        public Guid WalkDifficultyId { get; set; }

        //Nevigation property

        public Region Region { get; set; }
        public WalkDifficulty WalkDifficulty { get; set; }

    }
}
