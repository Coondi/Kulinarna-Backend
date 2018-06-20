using Kulinarna.Data.DbModels;
using Kulinarna.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulinarna.Repository.Repositories
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(DataContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Recipe>> BrowseAsyncComponents(string searchString)
        {
            var recipes = _context.Recipes.AsEnumerable();
            if(!string.IsNullOrWhiteSpace(searchString))
            {
                recipes = recipes.Where(x => x.Components.ToLowerInvariant().Contains(searchString.ToLowerInvariant()));
            }


            return await Task.FromResult(recipes);
            
        }

        public async Task<IEnumerable<Recipe>> BrowseAsyncName(string searchString)
        {
            var recipes = _context.Recipes.AsEnumerable();
            if(!string.IsNullOrWhiteSpace(searchString))
            {
                recipes = recipes.Where(x => x.Name.ToLowerInvariant().Contains(searchString.ToLowerInvariant()));

            }


            return await Task.FromResult(recipes);
        }

        public async Task<IEnumerable<Recipe>> BrowseAsyncPrepareTime(string searchValue)
        {
            var recipes = _context.Recipes.AsEnumerable();
            if(!string.IsNullOrWhiteSpace(searchValue))
            {
                recipes = recipes.Where(x => x.PreparationTime.ToString().ToLowerInvariant().Contains(searchValue.ToLowerInvariant()));
            }

            return await Task.FromResult(recipes);
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipeAsync()
            => await _context.Recipes.ToListAsync();

        public Task<Recipe> GetRecipeAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
