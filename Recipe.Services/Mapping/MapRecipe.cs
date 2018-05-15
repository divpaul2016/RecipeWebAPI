using System.Collections.Generic;
using System.Linq;
using Recipe.Services.Context;
using Recipe.Services.Models;
using Recipe.Services.Models.ApiModels;

namespace Recipe.Services.Mapping
{
   public class MapRecipe
    {
        private readonly FoodWorldContext _foodWorldContext;

        public MapRecipe(FoodWorldContext context)
        {
            _foodWorldContext = context;
        }

        public RecipeRequest MapToRecipe(int recipeId)
        {
            var foodrecipe = GetFoodRecipe(recipeId);

            var recipe = new RecipeRequest
            {
                FoodName = foodrecipe.FoodName,
                PrepTime = foodrecipe.PrepTime,
                ReadyIn =  foodrecipe.ReadyIn,
                CookingTime = foodrecipe.CookingTime,
                CreatedBy = foodrecipe.CreatedBy,
                Ingredients = GetIngredients(recipeId),
                MainIngredient = GetMainIngredient(recipeId),
                Directions = GetDirection(recipeId),
                MealType = GetMealType(recipeId),
                DishType =  GetDishType(recipeId),
                CookingStyle = GetCookingStyle(recipeId),
                Cuisine = GetCuisine(recipeId)
               
            };
            return recipe;
        }

        private List<string> GetCuisine(int recipeId)
        {
            var recipeCuisine = _foodWorldContext.RecipeCuisine.Where(x => x.RecipeId == recipeId).ToList();
            var cuisines = new List<string>();
            foreach (var item in recipeCuisine)
            {
                cuisines.Add(GetCuisineName(item.CuisineId));
            }

            return cuisines;
        }

        private string GetCuisineName(int itemCuisineId)
        {
            var cuisine = _foodWorldContext.Cuisines.FirstOrDefault(x => x.CuisineId == itemCuisineId);
            return cuisine?.CuisineName;
        }

        private List<string> GetCookingStyle(int recipeId)
        {
            var recipeCookingStyle = _foodWorldContext.RecipeCookingStyle.Where(x => x.RecipeId == recipeId).ToList();
            var cookingStyles = new List<string>();
            foreach (var item in recipeCookingStyle)
            {
                cookingStyles.Add(GetCookingStyleName(item.CookingStyleId));
            }

            return cookingStyles;
        }

        private string GetCookingStyleName(int itemCookingStyleId)
        {
            var cookingStyle =
                _foodWorldContext.CookingStyles.FirstOrDefault(x => x.CookingStyleId == itemCookingStyleId);
            return cookingStyle?.CookingStyleName;
        }

        private List<string> GetDishType(int recipeId)
        {
            var recipeDishType = _foodWorldContext.RecipeDishType.Where(x => x.RecipeId == recipeId).ToList();
            var dishTypes = new List<string>();
            foreach (var item in recipeDishType)
            {
                dishTypes.Add(GetDishTypeName(item.DishTypeId));
            }
            return dishTypes;
        }

        private string GetDishTypeName(int itemDishTypeId)
        {
            var dishtypes = _foodWorldContext.DishTypes.FirstOrDefault(x => x.DishTypeId == itemDishTypeId);
            return dishtypes?.DishTypeName;
        }

        private List<string> GetMealType(int recipeId)
        {
            var recipeMealTypes = _foodWorldContext.RecipeMealType.Where(x => x.RecipeId == recipeId).ToList();
            var mealTypes = new List<string>();
            foreach (var item in recipeMealTypes)
            {
                mealTypes.Add(GetMealTypeName(item.MealTypeId));
            }

            return mealTypes;

        }

        private string GetMealTypeName(int mealTypeId)
        {
            var mealTypeName = _foodWorldContext.MealTypes.FirstOrDefault(x => x.MealTypeId == mealTypeId);
            return mealTypeName?.MealTypeName;
        }

        private List<Direction> GetDirection(int recipeId)
        {
            var directions = new List<Direction>();
            var recipeDirection = _foodWorldContext.RecipeDirection.Where(x => x.RecipeId == recipeId).ToList();
            foreach (var itemRecipeDirection in recipeDirection)
            {
                directions.Add(new Direction
                {
                    Instruction = itemRecipeDirection.Instructions,
                    StepNo = itemRecipeDirection.StepNo
                });
           }
            return directions;

        }

        private string GetMainIngredient(int recipeId)
        {
            var recipeIngredient = _foodWorldContext.RecipeIngredient.FirstOrDefault(x => x.RecipeId == recipeId && x.MainIngredient == true);
            return recipeIngredient != null ? GetIngredientName(recipeIngredient.IngredientId) : null;
        }

        private FoodRecipe GetFoodRecipe(int recipeId)
        {
           return _foodWorldContext.FoodRecipes.FirstOrDefault(x => x.RecipeId == recipeId);
        }

        private List<Models.ApiModels.Ingredient> GetIngredients(int recipeId)
        {

            var recipeIngredient = _foodWorldContext.RecipeIngredient.Where(x => x.RecipeId == recipeId).ToList();
            var ingredients = new List<Models.ApiModels.Ingredient>();

            foreach (var item in recipeIngredient)
            {
                ingredients.Add(new Models.ApiModels.Ingredient
                {
                    IngredientName = GetIngredientName(item.IngredientId),
                    Unit = item.Unit,
                    Quantity = item.Quantity,
                });
            }

            return ingredients;
        }

        private string GetIngredientName(int itemIngredientId)
        {
            var ingredient = _foodWorldContext.Ingredients.FirstOrDefault(x => x.IngredientId == itemIngredientId);
            return ingredient?.IngredientName;
        }
    }
}
