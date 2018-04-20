using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Recipe.Services.Context;
using Recipe.Services.Mapping;
using Recipe.Services.Models;
using Recipe.Services.Models.ApiModels;

namespace Recipe.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly FoodWorldContext _recipeContext;

        public RecipeService(FoodWorldContext context)
        {
            _recipeContext = context;
        }

        public int CreateRecipe(RecipeRequest recipeRequest)
        {
            return AddRecipe(recipeRequest);
        }

        public FoodRecipe GetFoodRecipe(int recipeId)
        {
            return new FoodRecipe();
            //_recipeContext.FoodRecipes.FirstOrDefault(m => m.RecipeId == recipeId);
            /*SELECT * 
FROM FoodRecipes 
JOIN RecipeCookingStyle on FoodRecipes.RecipeId = RecipeCookingStyle .RecipeId
JOIN CookingStyles ON RecipeCookingStyle.CookingStyleId = CookingStyles.CookingStyleId
JOIN RecipeCuisine on FoodRecipes.RecipeId = RecipeCuisine.RecipeId
JOIN Cuisines ON RecipeCuisine.CuisineId = Cuisines.CuisineId
JOIN RecipeDirection ON FoodRecipes.RecipeId = RecipeDirection.RecipeId
JOIN RecipeDishType ON FoodRecipes.RecipeId = RecipeDishType.RecipeId
JOIN DishTypes ON RecipeDishType.DishTypeId = DishTypes.DishTypeID
JOIN RecipeIngredient ON FoodRecipes.RecipeId = RecipeIngredient.RecipeId
JOIN Ingredients ON FoodRecipes.RecipeId = Ingredients.IngredientID
JOIN RecipeMealType ON FoodRecipes.RecipeId = RecipeMealType.RecipeId
JOIN MealTypes ON RecipeMealType.MealTypeId = MealTypes.MealTypeId
Where FoodRecipes.RecipeId = 5*/


            //var dat = _recipeContext.FoodRecipes
            //    .Where(m => m.RecipeId == recipeId)
            //    .SelectMany(c => c.RecipeCookingStyles)
            //    .SelectMany(c=>c.)
            //    {
            //        RecipeId = recipeId
            //    });

            //.SelectMany(rd =>rd.);

            //    {
            //        FoodRecipe = m,
            //        RecipeCookingStyle = m.RecipeId,
            //        RecipeDirection = m.RecipeId,
            //        RecipeCuisine = m.RecipeId,
            //        RecipeDishType = m.RecipeId,
            //        RecipeIngredient = m.RecipeId,
            //        RecipeMealType = m.RecipeId
            //    }
            //).FirstOrDefault();
        }

        public int AddRecipe(RecipeRequest recipeRequest)
        {
            var foodRecipe = new MapFoodRecipe();
            var foodrecipeMap = foodRecipe.GetMappingToFoodRecipe(recipeRequest);
            _recipeContext.FoodRecipes.Add(foodrecipeMap);

            var map = new MapIngredients();
            var recipeIngredients = map.MapToRecipeIngredient(recipeRequest);
            if (recipeIngredients != null)
            {
                foodrecipeMap.RecipeIngredients.AddRange(recipeIngredients);
            }
            _recipeContext.SaveChanges();
            return foodrecipeMap.RecipeId;
        }
    }
}