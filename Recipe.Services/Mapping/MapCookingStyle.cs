using Recipe.Services.Context;
using Recipe.Services.Models;
using Recipe.Services.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipe.Services.Mapping
{
    public class MapCookingStyle
    {
        private readonly FoodWorldContext _foodWorldContext;

        public MapCookingStyle(FoodWorldContext context)
        {
            _foodWorldContext = context;
        }

        public List<RecipeCookingStyle> MapToRecipeCookingStyles(RecipeRequest recipeRequest)
        {
            var recipeCookingStyle = new List<RecipeCookingStyle>();
            foreach (var cookingStyleName in recipeRequest.CookingStyle)
            {
                if (!String.IsNullOrWhiteSpace(cookingStyleName))
                {
                    var cookingStyle = new RecipeCookingStyle();
                    {
                        if (CheckMealType(cookingStyleName))
                        {
                            var cookingstyle = GetMealTypeId(cookingStyleName);
                            cookingStyle.CookingStyle = cookingstyle;
                            cookingStyle.CookingStyleId = cookingstyle.CookingStyleId;
                        }
                        else
                        {
                            var mapToMealType = MapToCookigStyle(cookingStyleName);
                            cookingStyle.CookingStyle = mapToMealType;
                            cookingStyle.CookingStyleId = mapToMealType.CookingStyleId;
                        }

                    }
                    recipeCookingStyle.Add(cookingStyle);
                }
            }
            return recipeCookingStyle;
        }


        private bool CheckMealType(string cookingStyle)
        {
            var cookingStyles = _foodWorldContext.CookingStyles
                .FirstOrDefault(x => x.CookingStyleName == cookingStyle);
            return cookingStyles != null && cookingStyles.CookingStyleName.Equals(cookingStyle);
        }

        private CookingStyle GetMealTypeId(string cookingStyle)
        {
            var cookingStyles = _foodWorldContext.CookingStyles
                .FirstOrDefault(x => x.CookingStyleName == cookingStyle);
            return cookingStyles;
        }

        private CookingStyle MapToCookigStyle(string cookingStyleName)
        {
            var cookingStyle = new CookingStyle()
            {
                CookingStyleName = cookingStyleName
            };
            return cookingStyle;
        }
    }
}

