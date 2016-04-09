using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Interfaces;
using DAL.Interfaces;
using DAL.Repositories;
using Domain;

namespace Dal.Repositories
{
   public class CampaignRepository : EFRepository<Campaign>, ICampaignRepository
    {
       public CampaignRepository(IDbContext dbContext) : base(dbContext)
       {
       }
    }
}
