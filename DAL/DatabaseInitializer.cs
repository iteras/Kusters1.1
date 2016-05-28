using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain;
using Domain.Identity;
using Microsoft.AspNet.Identity;

namespace DAL
{
    //    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DataBaseContext>
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DataBaseContext>
    {
        protected override void Seed(DataBaseContext context)
        {
            var pwdHasher = new PasswordHasher();

            // Roles
            context.RolesInt.Add(new RoleInt()
            {
                Name = "Admin"
            });
            // Roles
            context.RolesInt.Add(new RoleInt()
            {
                Name = "User"
            });
            context.SaveChanges();

            // Users
            UserInt us = new UserInt()
            {
                UserName = "1@eesti.ee",
                Email = "1@eesti.ee",
                FirstName = "Super",
                LastName = "User",
                PasswordHash = pwdHasher.HashPassword("a"),
                SecurityStamp = Guid.NewGuid().ToString()
            };

            UserInt us2 = new UserInt()
            {
                UserName = "tom@eesti.ee",
                Email = "tom@eesti.ee",
                FirstName = "Tom",
                LastName = "Kari",
                PasswordHash = pwdHasher.HashPassword("a"),
                SecurityStamp = Guid.NewGuid().ToString()
            };

            context.UsersInt.Add(us);
            context.UsersInt.Add(us2);
            context.SaveChanges();

            // Users in Roles
            context.UserRolesInt.Add(new UserRoleInt()
            {
                User = context.UsersInt.FirstOrDefault(a => a.UserName == "1@eesti.ee"),
                Role = context.RolesInt.FirstOrDefault(a => a.Name == "Admin")
            });

            context.SaveChanges();


            var articleHeadLine = "<h1>ASP.NET</h1>";
            var articleBody =
                "<p class=\"lead\">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.<br/>" +
                "As a demo, here is simple Contact application - log in and save your contacts!</p>";
            var article = new Article()
            {
                ArticleName = "HomeIndex",
                ArticleHeadline =
                    new MultiLangString(articleHeadLine, "en", articleHeadLine, "Article.HomeIndex.ArticleHeadline"),
                ArticleBody = new MultiLangString(articleBody, "en", articleBody, "Article.HomeIndex.ArticleBody")
            };
            context.Articles.Add(article);
            context.SaveChanges();

            context.Translations.Add(new Translation()
            {
                Value = "<h1>ASP.NET on suurepärane!</h1>",
                Culture = "et",
                MultiLangString = article.ArticleHeadline
            });

            context.Translations.Add(new Translation()
            {
                Value =
                    "<p class=\"lead\">ASP.NET on tasuta veebiraamistik suurepäraste veebide arendamiseks kasutades HTML-i, CSS-i, ja JavaScript-i.<br/>" +
                    "Demona on siin lihtne Kontaktirakendus - logi sisse ja salvesta enda kontakte</p>",
                Culture = "et",
                MultiLangString = article.ArticleBody
            });
            context.SaveChanges();



            context.ContactTypes.Add(new ContactType()
            {
                ContactTypeName = new MultiLangString("Skype", "en", "Skype", "ContactType.0")
            });
            context.ContactTypes.Add(new ContactType()
            {
                ContactTypeName = new MultiLangString("Email", "en", "Email", "ContactType.0")
            });
            context.ContactTypes.Add(new ContactType()
            {
                ContactTypeName = new MultiLangString("Phone", "en", "Phone", "ContactType.0")
            });

            context.SaveChanges();
            Person Imre = new Person
            {
                UserId = 0,
                User = us,
                FirstName = "Imre",
                LastName = "Teras",
                BankNr = "453543345",
                Email = "asd@gmail.com",
                Invited = 1,
                Locked = false,
                Money = 40,
                Password = "asd",
                Raiting = 5,
                Gender = true,
                TelNr = "5435346",
                Registered = DateTime.Today
            };

            Person Tom = new Person
            {
                UserId = 1,
                User = us2,
                FirstName = "Tom",
                LastName = "Kari",
                BankNr = "453543345",
                Email = "tom@gmail.com",
                Invited = 1,
                Locked = false,
                Money = 0,
                Password = "asd",
                Raiting = 0,
                Gender = true,
                TelNr = "5435346",
                Registered = DateTime.Today
            };
            context.Persons.Add(Imre);
            context.Persons.Add(Tom);
            
            context.SaveChanges();

            context.Campaigns.Add(new Campaign()
            {
                Description ="normal",
                Percentage = 0,
                From = DateTime.Today,
                Until = DateTime.Today
            });
            context.SaveChanges();


            context.Products.Add(new Product()
            {
                Person = Imre,
                Title = "Samsung 42 tolline TV",
                Content = "Müüa seisma jäänud telekas. Müügi põhjuseks nurka seismajäämine",
                Price =280,
                TrackingCode ="",
                Created = DateTime.Now
            });
            context.Products.Add(new Product()
            {
                Person = Tom,
                Title = "PS3",
                Content = "Müüa seisma jäänud PS3. Müügi põhjuseks konsooli väljavahetus",
                Price = 130,
                TrackingCode = "",
                Created = DateTime.Now
            });
            context.Products.Add(new Product()
            {
                Person = Tom,
                Title = "Müüa lund",
                Content = "Müüa välja seisma jäänud lund, korralik käru täis.",
                Price = 15,
                TrackingCode = "",
                Created = DateTime.Now
            });
            //articleHeadLine = "<h1>ASP.NET</h1>";
            //articleBody =
            //    "<p class=\"lead\">ASP.NET on tasuta veebiraamistik suurepäraste veebide arendamiseks kasutades HTML-i, CSS-i, ja JavaScript-i.</p>";
            //article.ArticleHeadline = new MultiLangString(articleHeadLine, "et", articleHeadLine);
            //article.ArticleBody = new MultiLangString(articleBody, "et", articleBody);
            //context.Articles.Attach(article);
            //context.SaveChanges();

            base.Seed(context);
        }
    }
}