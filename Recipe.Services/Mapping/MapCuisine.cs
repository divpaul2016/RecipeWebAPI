using Recipe.Services.Context;
using Recipe.Services.Models;
using Recipe.Services.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipe.Services.Mapping
{
    public class MapRecipeCuisine
    {
        private readonly FoodWorldContext _foodWorldContext;

        public MapRecipeCuisine(FoodWorldContext context)
        {
            _foodWorldContext = context;
        }

        public List<RecipeCuisine> MapToRecipeCuisines(RecipeRequest recipeRequest)
        {
            var cuisinesRecipeCuisines = new List<RecipeCuisine>();
            foreach (var cuisines in recipeRequest.Cuisine)
            {
                if (!String.IsNullOrWhiteSpace(cuisines))
                {
                    var recipeCuisine = new RecipeCuisine();
                    {
                        if (CheckCuisine(cuisines))
                        {
                            var cuisine = GetCuisineId(cuisines);
                            recipeCuisine.Cuisine = cuisine;
                            recipeCuisine.CuisineId = cuisine.CuisineId;
                        }
                        else
                        {
                            var mapToCuisine =  MapToCuisine(cuisines);
                            recipeCuisine.CuisineId = mapToCuisine.CuisineId;
                            recipeCuisine.Cuisine = mapToCuisine;
                        }
                    }
                    cuisinesRecipeCuisines.Add(recipeCuisine);

                }
            }
            return cuisinesRecipeCuisines;
        }


        private bool CheckCuisine(string ingredientName)
        {
            var ingredient = _foodWorldContext.Ingredients
                .FirstOrDefault(x => x.IngredientName == ingredientName);
            return ingredient != null && ingredient.IngredientName.Equals(ingredientName);
        }

        private Cuisine GetCuisineId(string cuisineName)
        {
            var cuisine = _foodWorldContext.Cuisines
                .FirstOrDefault(x => x.CuisineName == cuisineName);
            return cuisine;
        }

        private Cuisine MapToCuisine(string cuisineName)
        {
            var cuisine = new Cuisine()
            {
                CuisineName = cuisineName
            };
            return cuisine;
        }
    }
}
