using Microsoft.Ajax.Utilities;
using Recipe.Services;
using Recipe.Services.Models.ApiModels;
using System;
using System.Web.Http;

namespace Recipe.Controllers
{
    public class RecipesController : ApiController
    {
        private readonly IRecipeService _recipeService;

        public RecipesController(IRecipeService service)
        {
            _recipeService = service;
        }

        //GET: api/recipes/?id=6
        public IHttpActionResult GetRecipeByRecipeId(int id)
        {
            var recipe = _recipeService.GetFoodRecipe(id);
            return Ok(recipe);
        }

        ///GET: api/recipes/?recipeName=
        public IHttpActionResult GetRecipeByRecipeName(string recipeName)
        {
            var recipe = _recipeService.GetFoodRecipe(recipeName);
            return Ok(recipe);
        }

        ///GET: api/recipes/?ingredient=Brocoli
        public IHttpActionResult GetRecipesByIngredientName(string ingredient)
        {
            var recipe = _recipeService.GetFoodRecipeByIngredients(ingredient);
            return Ok(recipe);
        }

        // POST: api/Recipes
        [HttpPost]
        public IHttpActionResult CreateRecipe([FromBody]RecipeRequest recipe)
        {
            try
            {
                if (recipe == null)
                {
                    return BadRequest();
                }

                if (recipe.FoodName.IsNullOrWhiteSpace())
                {
                    return BadRequest();
                }

                var recipeId = _recipeService.CreateRecipe(recipe);

                return Ok(new Response { RecipeId = recipeId });
            }
            catch (ArgumentException exception)
            {
                return BadRequest();
            }
            catch (Exception exception)
            {
                return BadRequest();
            }
        }
    }
}
