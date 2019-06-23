using System.Collections.Generic;
 
namespace dotnetapi
{
    public class FeedsRepository {
        public static List<Feeds> GetFeeds(AppDbContext dbContext)
        {

             return new  List<Feeds>(dbContext.Feeds);

        }
    }
}