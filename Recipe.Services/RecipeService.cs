using Recipe.Services.Context;
using Recipe.Services.Mapping;
using Recipe.Services.Models.ApiModels;
using System.Collections.Generic;
using System.Linq;

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
            var foodRecipe = new MapFoodRecipe();
            var foodrecipeMap = foodRecipe.GetMappingToFoodRecipe(recipeRequest);
            _recipeContext.FoodRecipes.Add(foodrecipeMap);

            var map = new MapIngredients(_recipeContext);
            var recipeIngredients = map.MapToRecipeIngredient(recipeRequest);
            if (recipeIngredients != null)
            {
                foodrecipeMap.RecipeIngredients.AddRange(recipeIngredients);
            }
            var mapdirection = new MapDirections();
            var directions = mapdirection.MapToRecipeDirections(recipeRequest);
            _recipeContext.RecipeDirection.AddRange(directions);

            var mapCuisine = new MapRecipeCuisine(_recipeContext);
            var recipeCuisine = mapCuisine.MapToRecipeCuisines(recipeRequest);
            _recipeContext.RecipeCuisine.AddRange(recipeCuisine);

            var mapMealtype = new MapMealType(_recipeContext);
            var recipeMealType = mapMealtype.MapToRecipeCuisines(recipeRequest);
            _recipeContext.RecipeMealType.AddRange(recipeMealType);

            var mapDishType = new MapDishType(_recipeContext);
            var recipeDishType = mapDishType.MapToRecipeDishType(recipeRequest);
            _recipeContext.RecipeDishType.AddRange(recipeDishType);

            var mapCookingStyle = new MapCookingStyle(_recipeContext);
            var recipeCookingStyle = mapCookingStyle.MapToRecipeCookingStyles(recipeRequest);
            _recipeContext.RecipeCookingStyle.AddRange(recipeCookingStyle);

            _recipeContext.SaveChanges();
            return foodrecipeMap.RecipeId;
        }

        public RecipeRequest GetFoodRecipe(int recipeId)
        {
            var recipe = new MapRecipe(_recipeContext);
            return recipe.MapToRecipe(recipeId);
        }

        public RecipeRequest GetFoodRecipe(string recipeName)
        {
            var foodRecipe= _recipeContext.FoodRecipes.FirstOrDefault(x => x.FoodName == recipeName);
            var recipe = new MapRecipe(_recipeContext);
            if (foodRecipe != null) return recipe.MapToRecipe(foodRecipe.RecipeId);
            return new RecipeRequest();
        }

        public List<RecipeRequest> GetFoodRecipeByIngredients(string ingredientName)
        {
            var ingredientId = GetIngredientId(ingredientName);
            if(ingredientId <1)
                return new List<RecipeRequest>();

            var foodRecipes = _recipeContext.RecipeIngredient.Where(x => x.IngredientId == ingredientId).ToList();
            if(foodRecipes.Equals(null))
                return new List<RecipeRequest>();

            List<RecipeRequest> recipeRequests = new List<RecipeRequest>();
            foreach (var recipeItem in foodRecipes)
            {
                var recipe = new MapRecipe(_recipeContext);
                recipeRequests.Add(recipe.MapToRecipe(recipeItem.RecipeId));
            }
            return recipeRequests;
        }

        private int GetIngredientId(string ingredientName)
        {
            var ingredient = _recipeContext.Ingredients.FirstOrDefault(x => x.IngredientName == ingredientName);
            if (ingredient != null) return ingredient.IngredientId;
            return 0;
        }
    }
}