using System;
using Recipe.Services.Context;
using Recipe.Services.Models;
using Recipe.Services.Models.ApiModels;
using System.Collections.Generic;
using System.Linq;

namespace Recipe.Services.Mapping
{
    public class MapDishType
    {
        private readonly FoodWorldContext _foodWorldContext;

        public MapDishType(FoodWorldContext context)
        {
            _foodWorldContext = context;
        }

        public List<RecipeDishType> MapToRecipeDishType(RecipeRequest recipeRequest)
        {
            var dishTypes = new List<RecipeDishType>();
            foreach (var dishtype in recipeRequest.DishType)
            {
                if (!String.IsNullOrWhiteSpace(dishtype))
                {
                    var recipeDishType = new RecipeDishType();
                    {
                        if (CheckDishType(dishtype))
                        {
                            var recipeDishtype = GetDishTypeId(dishtype);
                            recipeDishType.DishType = recipeDishtype;
                            recipeDishType.DishTypeId = recipeDishtype.DishTypeId;
                        }
                        else
                        {
                            var mapToDishType = MapToDishType(dishtype);
                            recipeDishType.DishTypeId = mapToDishType.DishTypeId;
                            recipeDishType.DishType = mapToDishType;
                        }
                    }
                   dishTypes.Add(recipeDishType);

                }
            }
            return dishTypes;
        }


        private bool CheckDishType(string dishType)
        {
            var ingredient = _foodWorldContext.DishTypes
                .FirstOrDefault(x => x.DishTypeName == dishType);
            return ingredient != null && ingredient.DishTypeName.Equals(dishType);
        }

        private DishType GetDishTypeId(string dishType)
        {
            var dishtype = _foodWorldContext.DishTypes
                .FirstOrDefault(x => x.DishTypeName == dishType);
            return dishtype;
        }

        private DishType MapToDishType(string dishType)
        {
            var dishtype = new DishType()
            {
                DishTypeName = dishType
            };
            return dishtype;
        }
    
    }
}
