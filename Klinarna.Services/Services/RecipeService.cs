using AutoMapper;
using Kulinarna.Data.DbModels;
using Kulinarna.Data.ModelDTO.Recipe;
using Kulinarna.Repository.Interfaces;
using Kulinarna.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulinarna.Services.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;

        public RecipeService(IRecipeRepository recipeRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        public async Task<GetRecipeDTO> AddRecipeAsync(SaveRecipeDTO recipeDTO)
        {
            var recipes = _mapper.Map<SaveRecipeDTO, Recipe>(recipeDTO);
            await _recipeRepository.AddAsync(recipes);
            await _recipeRepository.SaveAsync();

            var result = _mapper.Map<SaveRecipeDTO, GetRecipeDTO>(recipeDTO);
            return result;
        }

        public async Task<IEnumerable<GetRecipeDTO>> BrowseAsyncComponents(string searchString = null)
        {
            var recipes = await _recipeRepository.BrowseAsyncComponents(searchString);

            return _mapper.Map<IEnumerable<GetRecipeDTO>>(recipes);
        }

        public async Task<IEnumerable<GetRecipeDTO>> BrowseAsyncName(string searchString = null)
        {
            var recipes = await _recipeRepository.BrowseAsyncName(searchString);

            return _mapper.Map<IEnumerable<GetRecipeDTO>>(recipes);

        }

        public async Task<IEnumerable<GetRecipeDTO>> BrowseAsyncPrepareTime(string searchValue = null)
        {
            var recipes = await _recipeRepository.BrowseAsyncPrepareTime(searchValue);

            return _mapper.Map<IEnumerable<GetRecipeDTO>>(recipes);

        }

        public async Task DeleteRecipe(int id)
        {
            var recipe = await _recipeRepository.GetAsync(id);

            await _recipeRepository.DeleteAsyn(recipe);
           
        }

        public async Task<IEnumerable<GetRecipeDTO>> GetAllRecipeAsync()
        {
            var recipes = await _recipeRepository.GetAllRecipeAsync();
            var result = _mapper.Map<IEnumerable<GetRecipeDTO>>(recipes);
            return result;
        }

        public async Task<GetRecipeDTO> GetRecipeAsync(int id)
        {
            var recipe = await _recipeRepository.GetAsync(id);
            var result = _mapper.Map<Recipe, GetRecipeDTO>(recipe);

            return result;
            
        }

        public async Task<bool> RecipeExist(int id)
        {
            var recipe = await _recipeRepository.GetAsync(id);

            if(recipe == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> UpdateRecipe(int id, SaveRecipeDTO recipeDTO)
        {
            var recipe = await _recipeRepository.GetAsync(id);
            var mappedRecipe = _mapper.Map(recipeDTO, recipe);
            if(await _recipeRepository.UpdateAsync(mappedRecipe, id) == null)
            {
                return false;
            }

            return true;
        }
    }
}
