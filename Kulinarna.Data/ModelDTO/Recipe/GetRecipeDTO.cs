using System;
using System.Collections.Generic;
using System.Text;

namespace Kulinarna.Data.ModelDTO.Recipe
{
    public class GetRecipeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PreparationTime { get; set; }
        public string Components { get; set; }
        public string Description { get; set; }
    }
}
