using Kulinarna.Data.ModelDTO.Recipe;
using Kulinarna.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Kulinarna.API.Controllers
{
    [Route("api/recipe")]
    public class RecipeController : Controller
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRecipes()
        {
            var recipes = await _recipeService.GetAllRecipeAsync();
            if (recipes == null)
            {
                return NotFound();
            }
            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecipe(int id)
        {
            var recipe = await _recipeService.GetRecipeAsync(id);
            if(recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecipe([FromBody] SaveRecipeDTO recipeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _recipeService.AddRecipeAsync(recipeDTO);

            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            if (!await _recipeService.RecipeExist(id))
            {
                return NotFound();
            }

            await _recipeService.DeleteRecipe(id);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecipe(int id, [FromBody] SaveRecipeDTO recipeDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            if(!await _recipeService.RecipeExist(id))
            {
                return NotFound();
            }

            if(!await _recipeService.UpdateRecipe(id , recipeDTO))
            {
                return BadRequest("Nastąpił problem z edycją przepisu");
            }

           
            return Ok(recipeDTO);
        }
        

        [HttpGet("searchName/{searchName}")]
        public async Task<IActionResult> SearchByName(string searchName)
        {
            var recipes = await _recipeService.BrowseAsyncName(searchName);
            await _recipeService.GetAllRecipeAsync();

            return Json(recipes);
        }

        [HttpGet("searchComponents/{searchComponents}")]
        public async Task<IActionResult> SearchByComponents(string searchComponents)
        {
            var recipes = await _recipeService.BrowseAsyncComponents(searchComponents);
            await _recipeService.GetAllRecipeAsync();

            return Json(recipes);
        }

        [HttpGet("searchTime/{searchTime}")]
        public async Task<IActionResult> SearchByPrepareTime(string searchTime)
        {
            var recipes = await _recipeService.BrowseAsyncPrepareTime(searchTime);
            await _recipeService.GetAllRecipeAsync();

            return Json(recipes);
        }


    }
}
