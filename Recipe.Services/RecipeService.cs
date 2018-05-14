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

    }
}