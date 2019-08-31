using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Blog.DataAccess.Concrete.EntityFramework;
using Blog.Domain.Concrete;

namespace Blog.DataAccess.Configurations
{
    public class DatabaseInitializer : CreateDatabaseIfNotExists<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            InitializeIdentityForEf(context);
            base.Seed(context);
        }

        private void InitializeIdentityForEf(BlogContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            const string adminName = "admin";
            const string adminFirstName = "Caner";
            const string adminLastName = "Demir";
            const string adminEmail = "canerdemir2@gmail.com";
            const string adminPassword = "123";
            const string adminRole = "Admin";

            //Create Role Admin if it does not exist
            var role = roleManager.FindByName(adminRole);

            if (role == null)
            {
                role = new IdentityRole(adminRole);
                var roleResult = roleManager.Create(role);
            }

            //Create User account if it does not exist
            var user = userManager.FindByEmail(adminEmail);

            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = adminName,
                    FirstName = adminFirstName,
                    LastName = adminLastName,
                    Email = adminEmail,
                };
                var result = userManager.Create(user, adminPassword);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            // Add user admin to Role Admin if not already added
            var rolesForUser = userManager.GetRoles(user.Id);

            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }
    }
}