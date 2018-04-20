using Recipe.Service.Models;

namespace Recipe.Service
{
    public interface IRecipeService
    {
        Response CreateRecipe(Models.Recipe recipe);
    }
}