using Recipe.Services.Context;
using Recipe.Services.Models;
using Recipe.Services.Models.ApiModels;
using System.Collections.Generic;
using System.Linq;

namespace Recipe.Services.Mapping
{
    // Mapping RecipeIngredient, Ingredient 
    public class MapIngredients
    {
      public List<RecipeIngredient> MapToRecipeIngredient(RecipeRequest recipeRequest)
        {
            var recipeIngredients = new List<RecipeIngredient>();
            foreach (var ingredient in recipeRequest.Ingredients)
            {
                if (ingredient.IngredientName != null && ingredient.Quantity != null)
                {
                    var recipeIngredient = new RecipeIngredient();
                    {

                        recipeIngredient.Quantity = ingredient.Quantity;
                        recipeIngredient.Unit = ingredient.Unit;
                        recipeIngredient.MainIngredient = ingredient.MainIngredient;
                        if (CheckIngredient(ingredient.IngredientName))
                        {
                            var dbIngredient = GetIngredientId(ingredient.IngredientName);
                            recipeIngredient.IngredientId = dbIngredient.IngredientId;
                            recipeIngredient.Ingredient = MapToIngredient(ingredient.IngredientName);
                        }
                        else
                        {
                            var ingredients = MapToIngredient(ingredient.IngredientName);
                            if (ingredients != null)
                                recipeIngredient.IngredientId = ingredient.IngredientId;
                            recipeIngredient.Ingredient = ingredients;
                        }
                    }
                    recipeIngredients.Add(recipeIngredient);
                }
            }

            return recipeIngredients;
        }

        private bool CheckIngredient(string ingredientName)
        {
            using (var recipeContext = new FoodWorldContext())
            {
                var ingredient = recipeContext.Ingredients
                    .FirstOrDefault(x => x.IngredientName == ingredientName);
                return ingredient != null && ingredient.IngredientName.Equals(ingredientName);
            }
        }

        private Ingredient GetIngredientId(string ingredientName)
        {
            using (var recipeContext = new FoodWorldContext())
            {
                var ingreident = recipeContext.Ingredients
                    .FirstOrDefault(x => x.IngredientName == ingredientName);
                return ingreident;
            }
        }


        private Ingredient MapToIngredient(string ingredientName)
        {
            Ingredient intgrident = new Ingredient();
            intgrident.IngredientName = ingredientName;
            return intgrident;
        }

    }
}
