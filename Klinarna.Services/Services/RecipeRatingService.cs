using AutoMapper;
using Kulinarna.Data.DbModels;
using Kulinarna.Data.ModelDTO.Recipe;
using Kulinarna.Repository.Interfaces;
using Kulinarna.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulinarna.Services.Services
{
    public class RecipeRatingService : IRecipeRatingService
    {


        private readonly IRecipeRatingRepository _recipeRatingRepository;
        private readonly IMapper _mapper;


        public RecipeRatingService(IRecipeRatingRepository recipeRatingRepository, IMapper mapper)
        {
            _recipeRatingRepository = recipeRatingRepository;
            _mapper = mapper;
        }


        public async Task<CreateRecipeRatingDTO> AddRecipeRatingAsync(int recipeId, CreateRecipeRatingDTO recipeRatingDTO)
        {
            var rating = _mapper.Map<CreateRecipeRatingDTO, RecipeRating>(recipeRatingDTO);
            rating.RecipeId = recipeId;

            await _recipeRatingRepository.AddAsync(rating);
            await _recipeRatingRepository.SaveAsync();


            return recipeRatingDTO;
            
        }

        public async Task<CreateRecipeRatingDTO> GetRecipeRating(int recipeId, int ratingId)
        {

            var rating = _recipeRatingRepository.FindByAsync(x => x.RecipeId == recipeId, y => y.Id == ratingId);
            var result = _mapper.Map<CreateRecipeRatingDTO>(rating);
            await _recipeRatingRepository.SaveAsync();

            return result;           

        }


        public async Task<bool> RecipeRatingExist(int ratingId)
        {
            return await _recipeRatingRepository.RecipeRatingExist(ratingId);
        }

        public async Task UpdateRecipeRating(int recipeId, int ratingId, CreateRecipeRatingDTO recipeRatingDTO)
        {

            var rating = _recipeRatingRepository.FindByAsync(x => x.RecipeId == recipeId, y => y.Id == ratingId);
            await _mapper.Map(recipeRatingDTO, rating);

            await _recipeRatingRepository.SaveAsync();
                      
        }
    }
}
