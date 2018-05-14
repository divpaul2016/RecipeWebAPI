using Recipe.Services.Models;
using Recipe.Services.Models.ApiModels;
using System;

namespace Recipe.Services.Mapping
{
    public class MapFoodRecipe
    {
        public FoodRecipe GetMappingToFoodRecipe(RecipeRequest recipeRequest)
        {
            var recipe = new FoodRecipe
            {
                FoodName = recipeRequest.FoodName,
                PrepTime = recipeRequest.PrepTime,
                ReadyIn = recipeRequest.ReadyIn,
                CookingTime = recipeRequest.CookingTime,
                CreatedBy = recipeRequest.CreatedBy,
                CreatedOn = DateTime.Now
            };
            return recipe;
        }
    }
}
