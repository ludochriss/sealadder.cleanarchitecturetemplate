using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var administratorRole = new IdentityRole("Administrator");

            if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await roleManager.CreateAsync(administratorRole);
            }

            var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

            if (userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await userManager.CreateAsync(administrator, "Administrator1!");
                await userManager.AddToRolesAsync(administrator, new [] { administratorRole.Name });
                
            }
        }
        public static async Task SeedSampleMovieUsers(ApplicationDbContext context)
        {
            if (!context.MovieUsers.Any())
            {
                context.MovieUsers.Add(new User { Name = "Fred" });
                context.MovieUsers.Add(new User { Name = "George" });
                context.MovieUsers.Add(new User { Name = "Bill" });
                context.MovieUsers.Add(new User { Name = "Kate" });
                context.MovieUsers.Add(new User { Name = "Mary" });
                context.MovieUsers.Add(new User { Name = "Charlie" });
                await context.SaveChangesAsync();

            }
        }



        //public static async Task SeedEmotionsAsync(ApplicationDbContext _db)
        //{


        //    if (!_db.Emotions.Any())
        //    {
                
        //        _db.MovieEmotionLists.Add(new MovieEmotionList()
        //        {

                    
                    
        //            MovieEmotions ={
        //                        new MovieEmotion { Emotion = "None", Count = 0 },
        //                        new MovieEmotion { Emotion = "Admiration", Count = 0 },
        //                        new MovieEmotion { Emotion = "Adoration", Count = 0 },
        //                        new MovieEmotion { Emotion = "Aesthetic", Count = 0 },
        //                        new MovieEmotion { Emotion = "Appreciation", Count = 0 },
        //                        new MovieEmotion { Emotion = "Amusement", Count = 0 },
        //                        new MovieEmotion { Emotion = "Anxiety", Count = 0 },
        //                        new MovieEmotion { Emotion = "Awe", Count = 0 },
        //                        new MovieEmotion { Emotion = "Awkwardness", Count = 0 },
        //                        new MovieEmotion { Emotion = "Boredom", Count = 0 },
        //                        new MovieEmotion { Emotion = "Calmness", Count = 0 },
        //                        new MovieEmotion { Emotion = "Confusion", Count = 0 },
        //                        new MovieEmotion { Emotion = "Craving", Count = 0 },
        //                        new MovieEmotion { Emotion = "Disgust", Count = 0 },
        //                        new MovieEmotion { Emotion = "Empathetic pain", Count = 0 },
        //                        new MovieEmotion { Emotion = "Entrancement", Count = 0 },
        //                        new MovieEmotion { Emotion = "Envy", Count = 0 },
        //                        new MovieEmotion { Emotion = "Excitement", Count = 0 },
        //                        new MovieEmotion { Emotion = "Fear", Count = 0 },
        //                        new MovieEmotion { Emotion = "Horror", Count = 0 },
        //                        new MovieEmotion { Emotion = "Interest", Count = 0 },
        //                        new MovieEmotion { Emotion = "Joy", Count = 0 },
        //                        new MovieEmotion { Emotion = "Nostalgia", Count = 0 },
        //                        new MovieEmotion { Emotion = "Romance", Count = 0 },
        //                        new MovieEmotion { Emotion = "Sadness", Count = 0 },
        //                        new MovieEmotion { Emotion = "Satisfaction", Count = 0 },
        //                        new MovieEmotion { Emotion = "Sexual desire", Count = 0 },
        //                        new MovieEmotion { Emotion = "Sympathy", Count = 0 },
        //                        new MovieEmotion { Emotion = "Triumph", Count = 0 }
        //    }
        //        }
        //        );
        //       await _db.SaveChangesAsync();
               
        //    }
        //}
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            // Seed, if necessary
            if (!context.TodoLists.Any())
            {
                context.TodoLists.Add(new TodoList
                {
                    Title = "Shopping",
                    Items =
                    {
                        new TodoItem { Title = "Apples", Done = true },
                        new TodoItem { Title = "Milk", Done = true },
                        new TodoItem { Title = "Bread", Done = true },
                        new TodoItem { Title = "Toilet paper" },
                        new TodoItem { Title = "Pasta" },
                        new TodoItem { Title = "Tissues" },
                        new TodoItem { Title = "Tuna" },
                        new TodoItem { Title = "Water" }
                    }
                });

                await context.SaveChangesAsync();
            }
        }
    }
}