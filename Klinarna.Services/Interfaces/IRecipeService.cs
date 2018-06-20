using Kulinarna.Data.ModelDTO.Recipe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kulinarna.Services.Interfaces
{
    public interface IRecipeService
    {
        Task<GetRecipeDTO> GetRecipeAsync(int id);
        Task<IEnumerable<GetRecipeDTO>> GetAllRecipeAsync();
        Task<GetRecipeDTO> AddRecipeAsync(SaveRecipeDTO recipeDTO);
        Task<bool> RecipeExist(int id);
        Task DeleteRecipe(int id);
        Task<bool> UpdateRecipe(int id, SaveRecipeDTO recipeDTO);
        Task<IEnumerable<GetRecipeDTO>> BrowseAsyncName(string searchString);
        Task<IEnumerable<GetRecipeDTO>> BrowseAsyncPrepareTime(string searchValue);
        Task<IEnumerable<GetRecipeDTO>> BrowseAsyncComponents(string searchString);
    }
}
