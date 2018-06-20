using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Kulinarna.Data.DbModels
{
    public class Recipe : BaseEntity
    {
        public string Name { get; set; }
        public int PreparationTime { get; set; }
        public string Components { get; set; }
        public string Description { get; set; }
        public ICollection<RecipeRating> RecipeRating { get; set; }


        public Recipe()
        {
            RecipeRating = new Collection<RecipeRating>();
        }
    }
}
