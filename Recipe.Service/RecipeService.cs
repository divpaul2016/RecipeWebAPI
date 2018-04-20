using System;
using Recipe.Service.Models;

namespace Recipe.Service
{
    public class RecipeService : IRecipeService
    {
        public Response CreateRecipe(Models.Recipe recipe)
        {
            return new Response();
        }
    }

}
