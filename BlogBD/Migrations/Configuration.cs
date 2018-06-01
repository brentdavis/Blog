namespace BlogBD.Migrations
{
    using BlogBD.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BlogBD.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BlogBD.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));

            if(!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            if (!context.Roles.Any(r => r.Name == "Moderator"))
            {
                roleManager.Create(new IdentityRole { Name = "Moderator" });
            }

            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            if (!context.Users.Any(u => u.Email == "brentdavis@Mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "brentdavis@Mailinator.com",
                    Email = "brentdavis@Mailinator.com",
                    Firstname = "Brent",
                    Lastname = "Davis",
                    Displayname = "one brent boi"
                }, "Sheeps23#");
            }

            if (!context.Users.Any(u => u.Email == "johnmahoney@Mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "johnmahoney@Mailinator.com",
                    Email = "johnmahoney@Mailinator.com",
                    Firstname = "John",
                    Lastname = "Mahoney",
                    Displayname = "lenny2261"
                }, "Lenny2261");
            }

            if (!context.Users.Any(u => u.Email == "jasontwichell@Mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "jasontwichell@Mailinator.com",
                    Email = "jasontwichell@Mailinator.com",
                    Firstname = "Jason",
                    Lastname = "Twichell",
                    Displayname = "Jason T"
                }, "Jason123");
            }

            var userId = userManager.FindByEmail("brentdavis@Mailinator.com").Id;
            userManager.AddToRole(userId, "Admin");

            userId = userManager.FindByEmail("johnmahoney@Mailinator.com").Id;
            userManager.AddToRole(userId, "Moderator");

            userId = userManager.FindByEmail("jasontwichell@Mailinator.com").Id;
            userManager.AddToRole(userId, "Moderator");
        }
    }
}
