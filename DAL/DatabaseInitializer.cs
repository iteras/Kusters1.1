using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain;
using Domain.Identity;
using Domain.Video;
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


            var articleHeadLine = "<h1>Welcome to Kusters - the safe middleman service!</h1>";
            var articleBody =
                "<p class=\"lead\">To use this system as a seller, you have to post your item to this site and you must"+
                "let the buyer find you in Deals section. Next will be agreeing with deal and waiting for posting the item / s." +
                "The countdown will start and at the end of the time you get the money if everything goes" +
                "as planned / otherwise purchaser gets his / her money back.</p>" +
                "<p class=\"lead\"> As for buyer, you must find seller's name in Deals section by full name and choose 1 of his/her avaible items" +
                "for purchase.Next you make a deal and if seller agrees with it, the countdown will begin. Now seller has to post item,"+
                "and post item's tracking code. If it is not done in countdown time, deal will be canceled. But if everything goes as planned"+
                "(item's tracking code is posted) your time of transaction starts ticking. If you will not pay for the item, you may be left"+
                "with bad feedback.But if you work well and everything goes as they must be for successfull deal, as you pay the price and"+
                "recive dealed item, mark it as Deal done and deal is closed.<p> ";
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
                Value = "<h1>Tere tulemast Kustrersile - ohutu vahendamisteenuse veebilehele!</h1>",
                Culture = "et",
                MultiLangString = article.ArticleHeadline
            });

            context.Translations.Add(new Translation()
            {
                Value =
                    "<p class=\"lead\">Et müüa enda kaupa ohutult, tuleb esmalt postitada oma asi/asjad lehele \"Minu asjad\" lehel ja seejärel lasta ostjal ennast otside "+
                    " tehingute lehel täisnime järgi. Seejärel tuleb müüjal nõustuda tehinguga ja seejärel kauba postitamine teenusepakkujale(Omniva, SmartPost vms)."+
                    "Aeg hakkab tiksuma ja aja täis tiksudes kui kõik on läinud nii nagu peab, saab müüja raha kätte enda kontole. Vastasel juhul saab ostja raha tagasi.</p>"+
                    "<p class=\"lead\">Ostja peab ennem leidma endale toote mida ta osta tahab ja seejärel pöördub Kustersi lehele ja otsib Tehingute alt müüjat ja seejärel valib "+
                    "müüja saadaval olevate asjade hulgast valitu mida ta soovis osta. Järgmiseks peab müüja tehinguga nõustuma ja aeg hakkab tiksuma. Müüja postitab asja ning "+
                    "sisestab veebilehele saadetise jälgimiskoodi. Kui seda ei tehta ja aeg saaab otsa, tühistatakse tehing automaatselt. Aga kui kõik läheb nii nagu peab"+
                    "(saadetise pakikood on postitatud) hakkab tiksuma saadetise enda aeg ja ootab paki väljavõtmist. Peale paki väljavõtmist kas ostja ise postitab, et toode on välja "+
                    " võetud või saame teenuse pakkujalt info, et toode on välja võetud sulgub tehing ning müüja saab kätte enda rahasumma.<p>",
                Culture = "et",
                MultiLangString = article.ArticleBody
            });
            context.SaveChanges();

            context.Videos.Add(new Video()
            {
                Title = "Intz hate",
                YoutubeVideoId = "E5ONTXHS2mM"
            });

            context.Videos.Add(new Video()
            {
                Title = "Impz way",
                YoutubeVideoId = "YS-5oD2Y4Wk"
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