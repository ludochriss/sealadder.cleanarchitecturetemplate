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
                await userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });

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



        public static async Task SeedEmotionsAsync(ApplicationDbContext _db)
        {
                List<Emotion> emotionSeed =  new List<Emotion>(){
                     new Emotion { Name = "None"  },
                               new Emotion {  Name = "Admiration"  },
                               new Emotion {  Name = "Adoration"  },
                               new Emotion {  Name = "Aesthetic"  },
                               new Emotion {  Name = "Appreciation"  },
                               new Emotion {  Name = "Amusement"  },
                               new Emotion {  Name = "Anxiety"  },
                               new Emotion {  Name = "Awe"  },
                               new Emotion {  Name = "Awkwardness"  },
                               new Emotion {  Name = "Boredom"  },
                               new Emotion {  Name = "Calmness"  },
                               new Emotion {  Name = "Confusion"  },
                               new Emotion {  Name = "Craving"  },
                               new Emotion {  Name = "Disgust"  },
                               new Emotion {  Name = "Empathetic pain"  },
                               new Emotion {  Name = "Entrancement"  },
                               new Emotion {  Name = "Envy"  },
                               new Emotion {  Name = "Excitement"  },
                               new Emotion {  Name = "Fear"  },
                               new Emotion {  Name = "Horror"  },
                               new Emotion {  Name = "Interest"  },
                               new Emotion {  Name = "Joy"  },
                               new Emotion {  Name = "Nostalgia"  },
                               new Emotion {  Name = "Romance"  },
                               new Emotion {  Name = "Sadness"  },
                               new Emotion {  Name = "Satisfaction"  },
                               new Emotion {  Name = "Sexual desire"  },
                               new Emotion {  Name = "Sympathy"  },
                               new Emotion {  Name = "Triumph"  },          
                };

            if (!_db.Emotions.Any())
            {
                            foreach(var m in emotionSeed){

                                   _db.Emotions.Add(m);
                            }
             
            await _db.SaveChangesAsync();

        }
    }
  
}
}