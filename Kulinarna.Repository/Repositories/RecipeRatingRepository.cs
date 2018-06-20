using Kulinarna.Data.DbModels;
using Kulinarna.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kulinarna.Repository.Repositories
{
    public class RecipeRatingRepository : Repository<RecipeRating>, IRecipeRatingRepository
    {
        public RecipeRatingRepository(DataContext context) : base(context)
        {

        }


        public async Task<bool> RecipeRatingExist(int ratingId)
        {
            var rating = await _context.RecipeRatings.AnyAsync(x => x.Id == ratingId);

            return rating;
        }
    }
}
