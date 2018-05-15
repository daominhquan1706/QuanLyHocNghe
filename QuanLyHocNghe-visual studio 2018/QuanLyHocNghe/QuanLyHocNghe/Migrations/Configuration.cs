namespace QuanLyHocNghe.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<QuanLyHocNghe.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "QuanLyHocNghe.Models.ApplicationDbContext";
        }

        protected override void Seed(QuanLyHocNghe.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            roleManager.Create(new IdentityRole("Admins"));
            roleManager.Create(new IdentityRole("Guests"));
            roleManager.Create(new IdentityRole("SinhViens"));
            roleManager.Create(new IdentityRole("HuanLuyenViens"));


            if (!(context.Users.Any(u => u.UserName == "Admin@Company.com")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = "Admin@Company.com", PhoneNumber = "1234567890" };
                userManager.Create(userToInsert, "Password@123");
                userManager.AddToRole(userToInsert.Id, "Admins");
            }

            if (!(context.Users.Any(u => u.UserName == "Guest@Company.com")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = "Guest@Company.com", PhoneNumber = "1234567891" };
                userManager.Create(userToInsert, "Password@123");
                userManager.AddToRole(userToInsert.Id, "Guests");
            }
            if (!(context.Users.Any(u => u.UserName == "SinhViens@Company.com")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = "SinhViens@Company.com", PhoneNumber = "1234567891" };
                userManager.Create(userToInsert, "Password@123");
                userManager.AddToRole(userToInsert.Id, "SinhViens");
            }
            if (!(context.Users.Any(u => u.UserName == "HuanLuyenViens@Company.com")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = "HuanLuyenViens@Company.com", PhoneNumber = "1234567891" };
                userManager.Create(userToInsert, "Password@123");
                userManager.AddToRole(userToInsert.Id, "HuanLuyenViens");
            }
        }
    }
}
