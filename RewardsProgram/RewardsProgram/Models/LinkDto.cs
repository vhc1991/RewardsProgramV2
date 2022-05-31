namespace RewardsProgram.Models
{
    public class LinkDto
    {
        public int RewardsEarned { get; set; }
        public int TotalDollarsSpent { get; set; }
        

        public LinkDto(int rewardsEarned, int totalDollarsSpent)
        {
            RewardsEarned = rewardsEarned;
            TotalDollarsSpent = totalDollarsSpent;
           
        }
    }
}