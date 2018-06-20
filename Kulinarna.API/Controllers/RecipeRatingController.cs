using Kulinarna.Data.ModelDTO.Recipe;
using Kulinarna.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kulinarna.API.Controllers
{

    [Route("api/recipe/{recipeId}/rating")]
    public class RecipeRatingController : Controller
    {
        private readonly IRecipeRatingService _recipeRatingService;
        private readonly IRecipeService _recipeService;


        public RecipeRatingController(IRecipeRatingService recipeRatingService, IRecipeService recipeService)
        {
            _recipeRatingService = recipeRatingService;
            _recipeService = recipeService;
        }

        [HttpGet("{ratingId}")]
        public async Task<IActionResult> GetRecipeRating(int ratingId, int recipeId)
        {
            if(!await _recipeService.RecipeExist(recipeId))
            {
                return NotFound();
            }

            if(!await _recipeRatingService.RecipeRatingExist(ratingId))
            {
                return NotFound();
            }

            var result = await _recipeRatingService.GetRecipeRating(recipeId, ratingId);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecipeRating(int recipeId, [FromBody] CreateRecipeRatingDTO recipeRatingDTO)
        {
            if(!await _recipeService.RecipeExist(recipeId))
            {
                return NotFound();
            }

            try
            {
                var result = await _recipeRatingService.AddRecipeRatingAsync(recipeId, recipeRatingDTO);

                return Ok(result);
            }
            catch(Exception expception)
            {
                return BadRequest(expception.Message);
            }       
            
        }

        [HttpPut("{ratingId}")]
        public async Task<IActionResult> UpdateRecipeRating(int ratingId, int recipeId, [FromBody] CreateRecipeRatingDTO recipeRatingDTO)
        {

            await _recipeRatingService.UpdateRecipeRating(ratingId, recipeId, recipeRatingDTO);

            return Ok();
        }
   
    }
}
