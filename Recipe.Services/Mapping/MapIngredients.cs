using Recipe.Services.Context;
using Recipe.Services.Models;
using Recipe.Services.Models.ApiModels;
using System.Collections.Generic;
using System.Linq;
using Ingredient = Recipe.Services.Models.Ingredient;

namespace Recipe.Services.Mapping
{
    // Mapping RecipeIngredient, Ingredient 
    public class MapIngredients
    {
        private readonly FoodWorldContext _foodWorldContext;
        public MapIngredients(FoodWorldContext context)
        {
            _foodWorldContext = context;
        }
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
                            recipeIngredient.Ingredient = dbIngredient;
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
            var ingredient = _foodWorldContext.Ingredients
                .FirstOrDefault(x => x.IngredientName == ingredientName);
            return ingredient != null && ingredient.IngredientName.Equals(ingredientName);
        }

        private Ingredient GetIngredientId(string ingredientName)
        {
            var ingreident = _foodWorldContext.Ingredients
                .FirstOrDefault(x => x.IngredientName == ingredientName);
            return ingreident;
        }

        private Ingredient MapToIngredient(string ingredientName)
        {
            var intgrident = new Ingredient
            {
                IngredientName = ingredientName
            };
            return intgrident;
        }

    }
}
