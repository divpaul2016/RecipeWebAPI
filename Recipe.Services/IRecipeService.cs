using System.Collections.Generic;
using Recipe.Services.Models.ApiModels;

namespace Recipe.Services
{
    public interface IRecipeService
    {
        int CreateRecipe(RecipeRequest recipe);

        RecipeRequest GetFoodRecipe(int recipeId);
        RecipeRequest GetFoodRecipe(string recipeName);
        List<RecipeRequest> GetFoodRecipeByIngredients(string ingredientName);
    }
}