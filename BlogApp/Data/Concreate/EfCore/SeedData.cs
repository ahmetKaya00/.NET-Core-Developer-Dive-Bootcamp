using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concreate.EfCore{

    public static class SeedData{

        public static void TestVerileriniDoldur(IApplicationBuilder app){
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

            if(context != null){
                if(context.Database.GetPendingMigrations().Any()){
                    context.Database.Migrate();
                }
                
            if(!context.Tags.Any()){

                context.Tags.AddRange(
                    new Tag{Text = "web programlama"},
                    new Tag{Text = "backend"},
                    new Tag{Text = "game"},
                    new Tag{Text = "fullstack"}
                );
                context.SaveChanges();
            }
            if(!context.Users.Any()){
                context.Users.AddRange(
                    new User {UserName = "ahmetkaya", Image = "p1.jpg"},
                    new User {UserName = "beyzacebeci", Image = "p2.jpg"}
                );
                context.SaveChanges();
            }
            if(!context.Posts.Any()){
                context.Posts.AddRange(
                    new Post{
                        Title = "Asp.net Core",
                        Content = "Bu alanda çalışabilirsiniz.",
                        IsActive = true,
                        Image = "1.png",
                        PublishedOn = DateTime.Now.AddDays(-5),
                        Tags = context.Tags.Take(3).ToList(),
                        UserId = 1
                    },
                    new Post{
                        Title = "Backend dersleri",
                        Content = "Bu alanda çalışabilirsiniz.",
                        IsActive = true,
                        Image = "2.png",
                        PublishedOn = DateTime.Now.AddDays(-8),
                        Tags = context.Tags.Take(2).ToList(),
                        UserId = 1
                    },
                    new Post{
                        Title = "Unity Game",
                        Content = "Bu alanda çalışabilirsiniz. Oyunlar yapın.",
                        IsActive = true,
                        Image = "3.png",
                        PublishedOn = DateTime.Now.AddDays(-10),
                        Tags = context.Tags.Take(3).ToList(),
                        UserId = 2
                    }
                );
                context.SaveChanges();
            }
            }
        }
    }
}