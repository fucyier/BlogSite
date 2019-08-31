using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Blog.Domain.Concrete;
using Blog.DataAccess.Concrete.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net.Mime;

namespace Blog.WebUI
{
    public class IdentityConfig : CreateDatabaseIfNotExists<BlogContext>
    {

        public class ApplicationUserManager : UserManager<ApplicationUser>
        {
            public ApplicationUserManager(IUserStore<ApplicationUser> store)
                : base(store)
            {
            }

            public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
            {
                var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<BlogContext>()));
                // Configure validation logic for usernames
                manager.UserValidator = new UserValidator<ApplicationUser>(manager)
                {
                    AllowOnlyAlphanumericUserNames = false,
                    RequireUniqueEmail = true
                };
                // Configure validation logic for passwords
                manager.PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 3,
                    RequireNonLetterOrDigit = false,
                    RequireDigit = false,
                    RequireLowercase = false,
                    RequireUppercase = false,
                };
                // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user. 
                // For more information on using two-factor authentication please see http://go.microsoft.com/fwlink/?LinkID=391935
                // You can write your own provider and plug in here.
                manager.RegisterTwoFactorProvider("PhoneCode", new PhoneNumberTokenProvider<ApplicationUser>
                {
                    MessageFormat = "Your security code is: {0}"
                });
                manager.RegisterTwoFactorProvider("EmailCode", new EmailTokenProvider<ApplicationUser>
                {
                    Subject = "SecurityCode",
                    BodyFormat = "Your security code is: {0}"
                });
                manager.EmailService = new EmailService();
                manager.SmsService = new SmsService();
                var dataProtectionProvider = options.DataProtectionProvider;
                if (dataProtectionProvider != null)
                {
                    manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
                }
                return manager;
            }
        }

        public class ApplicationRoleManager : RoleManager<IdentityRole>
        {
            public ApplicationRoleManager(IRoleStore<IdentityRole, string> roleStore)
                : base(roleStore)
            {
            }


            public static ApplicationRoleManager Create(
                IdentityFactoryOptions<ApplicationRoleManager> options,
                IOwinContext context)
            {
                var manager = new ApplicationRoleManager(
                    new RoleStore<IdentityRole>(
                        context.Get<BlogContext>()));

                return manager;
            }
        }

        public class EmailService : IIdentityMessageService
        {
            public Task SendAsync(IdentityMessage message)
            {
                // Plug in your email service here to send an email.
                return SendMail(message);
            }

            private Task SendMail(IdentityMessage message)
            {
                #region formatter
                string text = string.Format("Lütfen bağlantıya tıklayınız {0}: {1}", message.Subject, message.Body);
                string html = "<b>Lütfen bağlantıya tıklayınız:</b> <a href=\"" + "http://localhost:5010" + message.Body +
                              "\">buraya tıklayınız</a><br/><br/>";

                html +=
                    HttpUtility.HtmlEncode(@"Ya da bağlantıyı kopyalayarak tarayıcınızın adres çubuğuna yapıştırınız: " +
                                           "http://localhost:5010" + message.Body);
                #endregion

                MailMessage msg = new MailMessage();
                msg.To.Add(new MailAddress(message.Destination));
                msg.Subject = message.Subject;
                msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
                msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

                SmtpClient smtpClient = new SmtpClient();

                try
                {
                    smtpClient.Send(msg);
                    return Task.FromResult(1);
                }
                catch
                {
                    return Task.FromResult(0);
                }
            }
        }

        public class SmsService : IIdentityMessageService
        {
            public Task SendAsync(IdentityMessage message)
            {
                // Plug in your sms service here to send a text message.
                return Task.FromResult(0);
            }
        }

    }
}