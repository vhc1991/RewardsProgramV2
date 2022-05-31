using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RewardsProgram.Models;
using RewardsProgram.Services;

namespace RewardsProgram.v2.Controllers
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class RewardsProgramController : ControllerBase
    {
       
        private readonly ISeedDataService _seedDataService;

        public RewardsProgramController(
            ISeedDataService seedDataService)
        {
            _seedDataService = seedDataService;
          
        }

        [HttpGet]
        public ActionResult GetAllRetailers()
        {
            // Add the spent

            return Ok(_seedDataService.GetAllRetailers());
        }
        [HttpPost]
        public ActionResult GetAllRewards(int TotalDollarsSpent)
        {
            // Add the spent
            var dto = new LinkDto (0, TotalDollarsSpent);
            return Ok(_seedDataService.GetRewardsEarned(dto));
        }
      
    }
}
