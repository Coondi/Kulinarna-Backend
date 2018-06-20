using System;
using System.Collections.Generic;
using System.Text;

namespace Kulinarna.Data.ModelDTO.Recipe
{
    public class RecipeRatingDTO
    {
        public int RecipeId { get; set; }
        public int Stars { get; set; }
        public double Average { get; set; }
        public int Difficulty { get; set; }
        public int NumberOfRating { get; set; }
    }
}
