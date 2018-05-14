using Recipe.Services.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Recipe.Services.Context
{
    public class FoodWorldContext : DbContext
    {
        public FoodWorldContext() : base("name=FoodWorld")
        {
            Database.SetInitializer<FoodWorldContext>(null);
        }

        public virtual DbSet<CookingStyle> CookingStyles { get; set; }
        public virtual DbSet<Cuisine> Cuisines { get; set; }
        public virtual DbSet<DishType> DishTypes { get; set; }
        public virtual DbSet<FoodRecipe> FoodRecipes { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<MealType> MealTypes { get; set; }
        public virtual DbSet<RecipeCookingStyle> RecipeCookingStyle { get; set; }
        public virtual DbSet<RecipeCuisine> RecipeCuisine { get; set; }
        public virtual DbSet<RecipeDirection> RecipeDirection { get; set; }
        public virtual DbSet<RecipeDishType> RecipeDishType { get; set; }
        public virtual DbSet<RecipeIngredient> RecipeIngredient { get; set; }
        public virtual DbSet<RecipeMealType> RecipeMealType { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();


            modelBuilder.Entity<FoodRecipe>()
                .HasKey(c => new { c.RecipeId })
                .ToTable("FoodRecipe", schemaName: "dbo");

            modelBuilder.Entity<Cuisine>()
                .HasKey(c => new { c.CuisineId })
                .ToTable("Cuisine", schemaName: "dbo");

            modelBuilder.Entity<MealType>()
                .HasKey(c => new { c.MealTypeId })
                .ToTable("MealType", schemaName: "dbo");

            modelBuilder.Entity<DishType>()
                .HasKey(c => new { c.DishTypeId })
                .ToTable("DishType", schemaName: "dbo");

            modelBuilder.Entity<CookingStyle>()
                .HasKey(c => new { c.CookingStyleId })
                .ToTable("CookingStyle", schemaName: "dbo");

            modelBuilder.Entity<Ingredient>()
                .HasKey(c => new { c.IngredientId });


            modelBuilder.Entity<RecipeCuisine>()
                .HasKey(c => new {c.RecipeCuisineId})
                .ToTable("RecipeCuisine", schemaName: "dbo");


            modelBuilder.Entity<RecipeDirection>()
                .HasKey(c => new { c.RecipeDirectionId })
                .ToTable("RecipeDirection", schemaName: "dbo");

            modelBuilder.Entity<RecipeCookingStyle>()
                .HasKey(c => new { c.RecipeCookingStyleId });

            modelBuilder.Entity<RecipeDishType>()
                .HasKey(c => new { c.RecipeDishTypeId });

            modelBuilder.Entity<RecipeIngredient>()
                .HasKey(c => new { c.RecipeIngredientId })
                .ToTable("RecipeIngredient", schemaName: "dbo");

            modelBuilder.Entity<RecipeMealType>()
                .HasKey(c => new { c.RecipeMealTypeId })
                .ToTable("RecipeMealType", schemaName: "dbo");



            modelBuilder.Entity<RecipeCookingStyle>()
                .HasRequired(t => t.FoodRecipe)
                .WithMany(t => t.RecipeCookingStyles)
                .HasForeignKey(t => t.RecipeId);

            modelBuilder.Entity<RecipeCookingStyle>()
                .HasRequired(t => t.CookingStyle);
                
            modelBuilder.Entity<RecipeDirection>()
                .HasRequired(t => t.FoodRecipe);


            modelBuilder.Entity<RecipeDishType>()
                .HasRequired(t => t.FoodRecipe)
                .WithMany(t => t.RecipeDishTypes)
                .HasForeignKey(t => t.RecipeId);

            modelBuilder.Entity<RecipeDishType>()
                .HasRequired(t => t.DishType);
                

            modelBuilder.Entity<RecipeIngredient>()
                .HasRequired(t => t.FoodRecipe)
                .WithMany(t => t.RecipeIngredients)
                .HasForeignKey(t => t.RecipeId);

            modelBuilder.Entity<RecipeIngredient>()
                .HasRequired(i => i.Ingredient);

            modelBuilder.Entity<RecipeCuisine>()
                .HasRequired(t => t.FoodRecipe)
                .WithMany(t => t.RecipeCuisines)
                .HasForeignKey(t => t.RecipeId);

            modelBuilder.Entity<RecipeCuisine>()
                .HasRequired(t => t.Cuisine);
            

            modelBuilder.Entity<RecipeMealType>()
                .HasRequired(t => t.FoodRecipe);


            //modelBuilder.Entity<RecipeMealType>()
            //    .HasRequired(t => t.MealType)
            //    .WithMany(t => t.RecipeMealTypes)
            //    .HasForeignKey(t => t.MealTypeId);

            base.OnModelCreating(modelBuilder);

        }
    }
}
