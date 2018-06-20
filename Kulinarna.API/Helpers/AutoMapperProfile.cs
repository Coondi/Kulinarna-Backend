using AutoMapper;
using Kulinarna.Data.DbModels;
using Kulinarna.Data.ModelDTO.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kulinarna.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Recipe, GetRecipeDTO>();
            CreateMap<GetRecipeDTO, Recipe>();

            CreateMap<SaveRecipeDTO, Recipe>();
            CreateMap<Recipe, SaveRecipeDTO>();

            CreateMap<SaveRecipeDTO, GetRecipeDTO>();
            CreateMap<GetRecipeDTO, SaveRecipeDTO>();

            CreateMap<CreateRecipeRatingDTO, RecipeRating>();
            CreateMap<RecipeRating, CreateRecipeRatingDTO>();


        }
    }
}
