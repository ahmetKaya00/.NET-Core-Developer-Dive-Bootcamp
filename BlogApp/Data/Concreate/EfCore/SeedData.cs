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
                    new Tag{Text = "web programlama", Url = "web-programlama",Color = TagColors.primary},
                    new Tag{Text = "backend", Url = "backend",Color = TagColors.danger},
                    new Tag{Text = "game", Url = "game",Color = TagColors.info},
                    new Tag{Text = "fullstack", Url = "full-stack",Color = TagColors.success},
                    new Tag{Text = "Augmented Realty", Url = "full-stack",Color = TagColors.secondary}
                );
                context.SaveChanges();
            }
            if(!context.Users.Any()){
                context.Users.AddRange(
                    new User {UserName = "ahmetkaya", Name = "Ahmet Kaya", Email= "ahmet@kaya.com",Password="123456" ,Image = "p1.jpg"},
                    new User {UserName = "beyzacebeci",Name = "Beyza Cebeci", Email= "beyza@cebeci.com",Password="123456" , Image = "p2.jpg"}
                );
                context.SaveChanges();
            }
            if(!context.Posts.Any()){
                context.Posts.AddRange(
                    new Post{
                        Title = "Asp.net Core",
                        Content = "Bu alanda çalışabilirsiniz.",
                        Url = "aspnet-core",
                        IsActive = true,
                        Image = "1.png",
                        PublishedOn = DateTime.Now.AddDays(-5),
                        Tags = context.Tags.Take(3).ToList(),
                        UserId = 1,
                        Comments = new List<Comment>{
                            new Comment{Text = "başarılı", PublishedOn = new DateTime(), UserId=1},
                            new Comment{Text = "güzel", PublishedOn = new DateTime(), UserId=2},
                            },
                    },
                    new Post{
                        Title = "Backend dersleri",
                        Content = "Bu alanda çalışabilirsiniz.",
                        Url = "backend-dersleri",
                        IsActive = true,
                        Image = "2.png",
                        PublishedOn = DateTime.Now.AddDays(-8),
                        Tags = context.Tags.Take(2).ToList(),
                        UserId = 1
                    },
                    new Post{
                        Title = "Unity Game",
                        Content = "Bu alanda çalışabilirsiniz. Oyunlar yapın.",
                        Url = "unity-game",
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