using Kulinarna.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kulinarna.Repository.Interfaces
{
    public interface IRecipeRepository :IRepository<Recipe>
    {
        Task<Recipe> GetRecipeAsync(int id);
        Task<IEnumerable<Recipe>> GetAllRecipeAsync();
        Task<IEnumerable<Recipe>> BrowseAsyncName(string searchString);
        Task<IEnumerable<Recipe>> BrowseAsyncPrepareTime(string searchValue);
        Task<IEnumerable<Recipe>> BrowseAsyncComponents(string searchString);
    }
}
