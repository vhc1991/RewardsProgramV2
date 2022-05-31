using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RewardsProgram.Models;
using RewardsProgram.Services;

namespace RewardsProgram.v1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Route("api/[controller]")]
    public class RewardsProgramController : ControllerBase
    {
        private readonly ISeedDataService _seedDataService;

        public RewardsProgramController(
           
            ISeedDataService seedDataService
           )
        {
            _seedDataService = seedDataService;
            
        }
        [HttpGet(Name = nameof(GetAllRetailers))]
        public ActionResult GetAllRetailers()
        {

            return Ok(_seedDataService.GetAllRetailers());

        }

        [HttpPost(Name = nameof(GetAllRewards))]
        public ActionResult GetAllRewards([FromQuery] int TotalDollarsSpent)
        {
            var dto = new LinkDto(0, TotalDollarsSpent);
           
            return Ok(_seedDataService.GetRewardsEarned(dto));

        }

       

    }
}
