using BMS.DataBaseData;
using BMS.DataBaseModels;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace BMS.DataBase
{
    public class StartUp
    {
        public static void Main()
        {
            using (var context = new BmsContex())
            {
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();
                //Seed();

            }
        
        }
        // enter in the admin panel with:
        // Username: admin
        // Password: 123
        public static void Seed()
        {
            SeedUsers();
            SeedContragents();
            SeedInquiry();
            SeedOffers();
            SeedProjects();
            Console.WriteLine("All data inserted successfully");
        }

        public static void SeedUsers()
        {
            var db = new BmsContex();
            var users = new List<User>();
            string[] names = new string[] { "viktor", "koko", "gogi", "vankata", "violeta" };

            var admin = new User
            {
                Username = "admin",
                Type = ClearenceType.Admin,
                Password = "40BD001563085FC35165329EA1FF5C5ECBDBBEEF"
            };
            users.Add(admin);

            for (int i = 0; i < 5; i++)
            {
                var user = new User
                {
                    Username = names[i],
                    Type = ClearenceType.User,
                    Password = "40BD001563085FC35165329EA1FF5C5ECBDBBEEF"
                };
                users.Add(user);
             }

            db.Users.AddRange(users);
            db.SaveChanges();
        }

        public static void SeedContragents()
        {
            var context = new BmsContex();

            var contragents = new[]
             {                                               
                new Contragent {PersonalVatNumber = "SD12351",PersonalIndentityNumber = 101, BankDetails="BGNKJ1453STZ", Telephone = "0879665233", Address= "Hristo Botev 207", Description = "nai dobrata firma", Email = "", Name = "Kaufland AD" , PersonForContact= "Vladimir", },                                                          
                new Contragent {PersonalVatNumber = "DFA1235",PersonalIndentityNumber = 102, BankDetails="UKLDNSF1523SF", Telephone = "0889655294", Address= "Peicho Slaveikov 3", Description = "nai dobrata firma", Email = "", Name = "WeSupply EOOD", PersonForContact = "Pesho"},                                                           
                new Contragent {PersonalVatNumber = "DAS1233",PersonalIndentityNumber = 103, BankDetails="DESF1523STZ", Telephone = "0879615259", Address= "Raina Knqginq 24", Description = "nai dobrata firma", Email = "", Name = "Goods EOOD", PersonForContact = "Ivan"}, 
                new Contragent {PersonalVatNumber = "DS12357",PersonalIndentityNumber = 104, BankDetails="USASF1523STZ", Telephone = "0879665232", Address= "Biznes Park Sofia", Description = "nai dobrata firma", Email = "", Name = "Market2U OOD", PersonForContact = "Georgi"},                                                            
                new Contragent {PersonalVatNumber = "DJG1236",PersonalIndentityNumber = 105, BankDetails="MEXSF1523STZ", Telephone = "0879665275", Address= "Tsar Simeon Veliki 137", Description = "nai dobrata firma", Email = "", Name = "Billa AD", PersonForContact = "Vladimir"},
            };                                                 

            context.Contragents.AddRange(contragents);
            context.SaveChanges();
        }

        public static void SeedInquiry()
        {
            var context = new BmsContex();
            var inquiries = new[]
            {
                new Inquiry { ClientId = 1, CreatorId = 2, Date = DateTime.Now ,  Description = "Create me Web App"},
                new Inquiry { ClientId = 2, CreatorId = 3, Date = DateTime.Now ,  Description = "Sell that stock"},
                new Inquiry { ClientId = 3, CreatorId = 4, Date = DateTime.Now ,  Description = "Configure Computer"},
                new Inquiry { ClientId = 4, CreatorId = 5, Date = DateTime.Now ,  Description = "Reinstall Windows"},
                new Inquiry { ClientId = 5, CreatorId = 6, Date = DateTime.Now ,  Description = "Android App Inquiry"}
            };
            context.Inquiries.AddRange(inquiries);
            context.SaveChanges();
        }

        public static void SeedOffers()
        {
            var context = new BmsContex();
            var offers = new[]
            {
                new Offer { ClientId = 1, CreatorId = 2, Date = DateTime.Now , InquiryId = 1, Description = "Cost: $1300"},
                new Offer { ClientId = 2, CreatorId = 3, Date = DateTime.Now , InquiryId = 2, Description = "Cost: $2500"},
                new Offer { ClientId = 3, CreatorId = 4, Date = DateTime.Now , InquiryId = 3, Description = "Cost: $3300"},
                new Offer { ClientId = 4, CreatorId = 5, Date = DateTime.Now , InquiryId = 4, Description = "Cost: $1800"},
                new Offer { ClientId = 5, CreatorId = 6, Date = DateTime.Now , InquiryId = 5, Description = "Cost: $3200"}
            };
            context.Offers.AddRange(offers);
            context.SaveChanges();
        }

        public static void SeedProjects()
        {
            var context = new BmsContex();
            var project = new[]
            {
                new Project { ClientId = 1, CreatorId = 2, OfferId = 1, StartDate = DateTime.Now ,EndDate = DateTime.Now,DeadLine = DateTime.Now, InquiryId = 1, Name = "Android App"},
                new Project { ClientId = 2, CreatorId = 3, OfferId = 2, StartDate = DateTime.Now ,EndDate = DateTime.Now,DeadLine = DateTime.Now, InquiryId = 2, Name = "Desktop App"},                                           
                new Project { ClientId = 3, CreatorId = 4, OfferId = 3, StartDate = DateTime.Now ,EndDate = DateTime.Now,DeadLine = DateTime.Now, InquiryId = 3, Name = "Web App"},                                              
                new Project { ClientId = 4, CreatorId = 5, OfferId = 4, StartDate = DateTime.Now ,EndDate = DateTime.Now,DeadLine = DateTime.Now, InquiryId = 4, Name = "Sports WebSite"},                                       
                new Project { ClientId = 5, CreatorId = 6, OfferId = 5, StartDate = DateTime.Now ,EndDate = DateTime.Now,DeadLine = DateTime.Now, InquiryId = 5, Name = "Production Management System"}
            };
            context.Projects.AddRange(project);
            context.SaveChanges();
        }
    }
}
