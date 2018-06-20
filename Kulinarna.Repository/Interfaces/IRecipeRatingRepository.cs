using Kulinarna.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kulinarna.Repository.Interfaces
{
    public interface IRecipeRatingRepository : IRepository<RecipeRating>
    {
        Task<bool> RecipeRatingExist(int ratingId);
    }
}
