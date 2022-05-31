
using System;
using System.Collections.Generic;
using RewardsProgram.Models;

namespace RewardsProgram.Services
{
    public class SeedDataService : ISeedDataService
    {
        private readonly int loyaltyRewardsDefault = 50;
        private readonly int loyaltyRewardsDefaultStage1 = 100;

        #region PublicMethods
        public LinkDto  GetRewardsEarned(LinkDto linkDto)
        {
            
            if(linkDto != null)
            {
                try
                {
                    // checking  totalspent is greater than Default rewards program
                    if(linkDto.TotalDollarsSpent >= loyaltyRewardsDefault)
                    {
                        // as the total spent value is greater than default value calculating the rewards.
                        // Calculated rewards are added to rewardsEarned Property.
                        linkDto.RewardsEarned = linkDto.TotalDollarsSpent - loyaltyRewardsDefault;
                        // check if the rewards Earned are greater than the given stage1 value we are adding on the rewards
                        if(linkDto.TotalDollarsSpent >= loyaltyRewardsDefaultStage1)
                        {
                            // As the spent rewards are more than stage 1 the extra reqards are added.
                            linkDto.RewardsEarned += linkDto.TotalDollarsSpent - loyaltyRewardsDefaultStage1;
                        }
                        
                    }
                    else
                    {
                        linkDto.RewardsEarned = 0;
                    }
                    //Below is the dynamicmethod which is for reference.
               // you can use any method.the below line jsut to say that we can achieve the puzzle dynamically as well.
                var totalrewards =    RewardsEarnedDynamic(linkDto.TotalDollarsSpent);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //logfile.log(ex.message)
                }
            }
         return linkDto;
        }

        public dynamic GetAllRetailers()
        {
            var retailerList = new List<RetailersModel>();
            retailerList = GetAllRetailersList();
            return retailerList;

        }
        #endregion

        #region Private Methods
        private int RewardsEarnedDynamic(int totalDollarsSpent)
        {
            var totalRewardsEarned = 0;
            var dynamicRewardStages = GetdynamicStagevalues();
            if(dynamicRewardStages == null)
            {
                return totalRewardsEarned;
            }
            if (dynamicRewardStages.Length >=1)
            {
      
               for(int i = 0;i < dynamicRewardStages.Length; i++)
                {
                    if( i== 0 )
                    {
                        totalRewardsEarned = totalDollarsSpent - Convert.ToInt32(dynamicRewardStages.GetValue(i));
                    }
                    else
                    {
                        totalRewardsEarned += totalDollarsSpent - Convert.ToInt32(dynamicRewardStages.GetValue(i));
                    }

                }
             
            }
            return totalRewardsEarned;
        }
        private Array GetdynamicStagevalues()
        {
             var dynamicRewardStages = new int[2];
            // you can fill the values to the array from DB as well.
            // but now hardcoding for  2 length
            // Always make the rewards order as Ascending.
            dynamicRewardStages[0] = 50;
            dynamicRewardStages[1] = 100;
            return dynamicRewardStages;
        }

        private List<RetailersModel> GetAllRetailersList()
        {
            // this method is to fill the retailer list either from Sql or from other source.
            // Now we are doing the hardcode List
            var retailerList = new List<RetailersModel> {
                new RetailersModel { Id= 1, Name = "Retailer1", TotalRewardsEarned = 0,TotalSpent = 90},
                new RetailersModel { Id= 2, Name = "Retailer2", TotalRewardsEarned = 0,TotalSpent = 40},
                new RetailersModel { Id= 3, Name = "Retailer3", TotalRewardsEarned = 0,TotalSpent = 50},
                new RetailersModel { Id= 4, Name = "Retailer4", TotalRewardsEarned = 0,TotalSpent = 60},
                new RetailersModel { Id= 5, Name = "Retailer5", TotalRewardsEarned = 0,TotalSpent = 100},
                new RetailersModel { Id= 6, Name = "Retailer6", TotalRewardsEarned = 0,TotalSpent = 110},
                new RetailersModel { Id= 7, Name = "Retailer7", TotalRewardsEarned = 0,TotalSpent = 105},
                new RetailersModel { Id= 8, Name = "Retailer8", TotalRewardsEarned = 0,TotalSpent = 120},
                new RetailersModel { Id= 9, Name = "Retailer9", TotalRewardsEarned = 0,TotalSpent = 130},
                new RetailersModel { Id= 10, Name = "Retailer10", TotalRewardsEarned = 0,TotalSpent = 30},
                new RetailersModel { Id= 11, Name = "Retailer11", TotalRewardsEarned = 0,TotalSpent = 109},
                new RetailersModel { Id= 12, Name = "Retailer12", TotalRewardsEarned = 0,TotalSpent = 149}

            };
            return retailerList;
        }
        #endregion

    }
}
