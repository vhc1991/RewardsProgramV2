using RewardsProgram.Models;
using RewardsProgram.Services;
using Xunit;

namespace RewardsProgramTests
{
    public class ServiceTests
    {
        private readonly ISeedDataService _service;

        public ServiceTests()
        {
            
            _service = new SeedDataService();
        }
        [Fact]  
        public void InitializeRewardsZeroTest()
        {
            var dto = new LinkDto(0,0);
            var result = _service.GetRewardsEarned(dto);
                Assert.Equal("0", result.RewardsEarned.ToString());
        }
        [Fact]
        public void InitializeRewardsCalculatedValueTest()
        {
            var dto = new LinkDto(0, 120);
            var result = _service.GetRewardsEarned(dto);
            Assert.Equal("90", result.RewardsEarned.ToString());
        }
    }
}