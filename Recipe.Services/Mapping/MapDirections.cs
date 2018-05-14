using Recipe.Services.Models;
using Recipe.Services.Models.ApiModels;
using System.Collections.Generic;

namespace Recipe.Services.Mapping
{
    public class MapDirections
    {
        public List<RecipeDirection> MapToRecipeDirections(RecipeRequest recipeRequest)
        {
            List<RecipeDirection> recipeDirections = new List<RecipeDirection>();
            foreach (var direction in recipeRequest.Directions)
            {
                var recipeDirection = new RecipeDirection
                {
                    Instructions = direction.Instruction,
                    StepNo = direction.StepNo
                };
                recipeDirections.Add(recipeDirection);
            }
            return recipeDirections;
        }
    }
}
