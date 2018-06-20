using System;
using System.Collections.Generic;
using System.Text;

namespace Kulinarna.Data.DbModels
{
    public class RecipeRating : BaseEntity
    {       
        public int Stars { get; set; }
        public int Difficulty { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        
    }
}
