using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recipe.Services.Context;
using Recipe.Services.Models;
using Recipe.Services.Models.ApiModels;

namespace Recipe.Services.Mapping
{
    public class MapMealType
    {
        private readonly FoodWorldContext _foodWorldContext;

        public MapMealType(FoodWorldContext context)
        {
            _foodWorldContext = context;
        }

        public List<RecipeMealType> MapToRecipeCuisines(RecipeRequest recipeRequest)
        {
            var recipeMealTypes = new List<RecipeMealType>();
            foreach (var mealTypes in recipeRequest.MealType)
            {
                if (!String.IsNullOrWhiteSpace(mealTypes))
                {
                    var recipeMealType = new RecipeMealType();
                    {
                        if (CheckMealType(mealTypes))
                        {
                            var mealtype = GetMealTypeId(mealTypes);
                            recipeMealType.MealType = mealtype;
                            recipeMealType.MealTypeId = mealtype.MealTypeId;
                        }
                        else
                        {
                            var mapToMealType = MapToMealType(mealTypes);
                            recipeMealType.MealType = mapToMealType;
                            recipeMealType.MealTypeId = mapToMealType.MealTypeId;
                        }

                    }
                    recipeMealTypes.Add(recipeMealType);
                }
            }
            return recipeMealTypes;
        }


        private bool CheckMealType(string mealtype)
        {
            var mealType = _foodWorldContext.MealTypes
                .FirstOrDefault(x => x.MealTypeName == mealtype);
            return mealType != null && mealType.MealTypeName.Equals(mealtype);
        }

        private MealType GetMealTypeId(string mealtype)
        {
            var mealType = _foodWorldContext.MealTypes
                .FirstOrDefault(x => x.MealTypeName == mealtype);
            return mealType;
        }

        private MealType MapToMealType(string mealtype)
        {
            var mealType = new MealType()
            {
                MealTypeName = mealtype
            };
            return mealType;
        }
    }
}
