using System.Threading.Tasks;
using RewardsProgram.Models;
namespace RewardsProgram.Services
{
    public interface ISeedDataService
    {
        LinkDto GetRewardsEarned(LinkDto linkDto);
        dynamic GetAllRetailers();
    }
}
