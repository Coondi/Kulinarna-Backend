using System;
using System.Collections.Generic;
using System.Text;

namespace Kulinarna.Data.ModelDTO.Recipe
{
    public class CreateRecipeRatingDTO
    {
        public int RecipeId { get; set; }
        public int Stars { get; set; }
        public int Difficulty { get; set; }
    }
}
