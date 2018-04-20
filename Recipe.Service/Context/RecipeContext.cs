using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Recipe.Service.Context
{
    public interface IRecipeContext
    {

    }
    public class RecipeContext : DbContext,IRecipeContext
    {
        public RecipeContext() : base("FoodWorld")
        {
            Database.SetInitializer<RecipeContext>(null);
        }

    }
}
