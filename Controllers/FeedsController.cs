using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace dotnetapi
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedsController : ControllerBase
    {
         private readonly AppDbContext  dbContext;

         public FeedsController(AppDbContext  _dbContext) {
             dbContext= _dbContext;
         }

        [HttpGet]
        public ActionResult<IEnumerable<Feeds>> GetFeeds()
        {
           return Ok(FeedsRepository.GetFeeds(dbContext));
        }

       
    }
}
