using Kulinarna.Data.ModelDTO.Recipe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kulinarna.Services.Interfaces
{
    public interface IRecipeRatingService
    {
        Task<bool> RecipeRatingExist(int recipeId);
        Task<CreateRecipeRatingDTO> AddRecipeRatingAsync(int recipeId, CreateRecipeRatingDTO recipeRatingDTO);
        Task<CreateRecipeRatingDTO> GetRecipeRating(int recipeId, int ratingId);
        Task UpdateRecipeRating(int recipeId, int ratingId, CreateRecipeRatingDTO recipeRatingDTO);

    }
}
