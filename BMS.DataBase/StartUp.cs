namespace BMS.DataBase
{
    using BMS.DataBaseData;
    using BMS.DataBaseModels;
    using BMS.DataBaseModels.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            using (var context = new BmsContex())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                Seed(context);
            }

        }
        // enter in the admin panel with:
        // Username: admin
        // Password: 123
        public static void Seed(BmsContex context)
        {
            var random = new Random();

            //SeedUsers();
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

            context.Users.AddRange(users);

            //SeedContragents();

            var contragents = new[]
             {
                new Contragent {PersonalVatNumber = "SD167882351",PersonalIndentityNumber = "101123205", BankDetails="BGNKJ1453STZ", Telephone = "0879665233",Town = "Haskovo", Address= "Hristo Botev 207", Description = "Food & Sweets", Email = "abv@gmail.com", Name = "Kaufland AD" , PersonForContact= "Vladimir", },
                new Contragent {PersonalVatNumber = "DFA12678935",PersonalIndentityNumber = "102212333", BankDetails="UKLDNSF1523SF", Telephone = "0889655294",Town = "Sofia", Address= "Peicho Slaveikov 3", Description = "Monthly Supplies", Email = "hugo@abv.bg", Name = "WeSupply EOOD", PersonForContact = "Pesho"},
                new Contragent {PersonalVatNumber = "DAS12678933",PersonalIndentityNumber = "101233452", BankDetails="DESF1523STZ", Telephone = "0879615259",Town = "Veliko Tarnovo", Address= "Raina Knqginq 24", Description = "Cleaning stuff", Email = "namaste@gmail.com", Name = "Goods EOOD", PersonForContact = "Ivan"},
                new Contragent {PersonalVatNumber = "DS167892357",PersonalIndentityNumber = "101234623", BankDetails="USASF1523STZ", Telephone = "0879665232",Town = "Yambol", Address= "Biznes Park Sofia", Description = "Internet services", Email = "koki@yahoo.com", Name = "Market2U OOD", PersonForContact = "Georgi"},
                new Contragent {PersonalVatNumber = "DJG12679736",PersonalIndentityNumber = "101235125", BankDetails="MEXSF1523STZ", Telephone = "0879665275",Town = "New York", Address= "Tsar Simeon Veliki 137", Description = "Fruits and Water Supply", Email = "bobi.v@abv.bg", Name = "Billa AD", PersonForContact = "Vladimir"},
            };

            context.Contragents.AddRange(contragents);

            //SeedInquiry();
            var inquiries = new[]
            {
                new Inquiry { Contragent = contragents[0], Creator = users[1], Date = DateTime.Now ,  Description = "Create me Web App"},
                new Inquiry { Contragent = contragents[1], Creator = users[2], Date = DateTime.Now ,  Description = "Sell that stock"},
                new Inquiry { Contragent = contragents[2], Creator = users[3], Date = DateTime.Now ,  Description = "Configure Computer"},
                new Inquiry { Contragent = contragents[3], Creator = users[4], Date = DateTime.Now ,  Description = "Reinstall Windows"},
                new Inquiry { Contragent = contragents[4], Creator = users[5], Date = DateTime.Now ,  Description = "Android App Inquiry"}
            };
            context.Inquiries.AddRange(inquiries);

            //SeedOffers();
            var offers = new[]
            {
                new Offer { Contragent = contragents[0], Creator = users[1], Date = DateTime.Now , InquiryId = 1, Description = "Cost: $1300"},
                new Offer { Contragent = contragents[1], Creator = users[2], Date = DateTime.Now , InquiryId = 2, Description = "Cost: $2500"},
                new Offer { Contragent = contragents[2], Creator = users[3], Date = DateTime.Now , InquiryId = 3, Description = "Cost: $3300"},
                new Offer { Contragent = contragents[3], Creator = users[4], Date = DateTime.Now , InquiryId = 4, Description = "Cost: $1800"},
                new Offer { Contragent = contragents[4], Creator = users[5], Date = DateTime.Now , InquiryId = 5, Description = "Cost: $3200"}
            };
            context.Offers.AddRange(offers);

            //SeedProjects();

            var projects = new[]
            {
                new Project {
                    Contragent = contragents[0],
                    Creator = users[1],
                    Offer = offers[0],
                    StartDate = DateTime.Today.AddDays(-10) ,
                    EndDate = DateTime.Today.AddDays(20),
                    DeadLine = DateTime.Today.AddDays(18),
                    Inquiry = inquiries[0],
                    Name = "Android App",
                    ContactPerson= "Nick",
                    ContactPhone= "0883521458"
                },

                new Project
                {
                    Contragent = contragents[1],
                    Creator = users[2],
                    Offer = offers[1],
                    Inquiry = inquiries[1],
                    StartDate =DateTime.Today.AddDays(-32),
                    EndDate =  DateTime.Today.AddDays(30),
                    DeadLine = DateTime.Today.AddDays(28),
                    Name = "Desktop App",
                    ContactPerson= "Denis",
                    ContactPhone= "0789231458"
                },

                new Project
                {
                    Contragent = contragents[2],
                    Creator = users[3],
                    Offer = offers[2],
                    Inquiry = inquiries[2],
                    StartDate = DateTime.Today.AddDays(-40),
                    EndDate = DateTime.Today.AddDays(40),
                    DeadLine = DateTime.Today.AddDays(38),
                    Name = "Web App",
                    ContactPerson= "Vicky",
                    ContactPhone= "0896231442"
                },

                new Project
                {
                    Contragent = contragents[3],
                    Creator = users[4],
                    Offer = offers[3],
                    Inquiry = inquiries[3],
                    StartDate = DateTime.Today.AddDays(-52),
                    EndDate = DateTime.Today.AddDays(50),
                    DeadLine = DateTime.Today.AddDays(48),
                    Name = "Sports WebSite",
                    ContactPerson= "Danny",
                    ContactPhone= "0889265328"
                },
                new Project
                {
                    Contragent = contragents[4],
                    Creator = users[5],
                    Offer = offers[4],
                    Inquiry = inquiries[4],
                    StartDate = DateTime.Today.AddDays(-16),
                    EndDate = DateTime.Today.AddDays(35),
                    DeadLine = DateTime.Today.AddDays(33),
                    Name = "Product Management",
                    ContactPerson= "Kaloyan",
                    ContactPhone= "0882231624"
                }
            };
            context.Projects.AddRange(projects);

            //Seed Notes
            var notes = new List<Note>();
            for (int i = 0; i < 50; i++)
            {
                var note = new Note
                {
                    Date = RandomDate(random),
                    Description = RandomDescription(random),
                    Project = projects[random.Next(0, projects.Length)],
                    Type = RandomEnum<NoteType>(random)
                };
                notes.Add(note);
            }
            context.Notes.AddRange(notes);


            //Seed ClientInvoices
            var clientInvoices = new List<Invoice>();

            for (int i = 0; i < 20; i++)
            {
                var clientId = random.Next(0, contragents.Length);
                var supplierId = random.Next(0, contragents.Length);

                while (clientId == supplierId)
                {
                    clientId = random.Next(0, contragents.Length);
                }

                var clientInvoice = new Invoice
                {
                    Project = projects[random.Next(0, projects.Length)],
                    Client = contragents[clientId],
                    Supplier = contragents[supplierId],
                    Text = RandomDescription(random),
                    Date = RandomDate(random),
                    Price = (decimal)(random.Next(10, 1000) * 1.24),
                    Vat = random.Next(7, 21),
                    Town = RandomTown(random),
                    InvoiceNum = RandomInvoice(random)

                };

                clientInvoice.Total = clientInvoice.Price * clientInvoice.Vat;

                clientInvoices.Add(clientInvoice);
            }

            context.Invoices.AddRange(clientInvoices);

            //Seed SupplierInvoices
            var supplierInvoices = new List<Invoice>();

            for (int i = 0; i < 20; i++)
            {
                var clientId = random.Next(0, contragents.Length);
                var supplierId = random.Next(0, contragents.Length);

                while (clientId == supplierId)
                {
                    clientId = random.Next(0, contragents.Length);
                }

                var supplierInvoice = new Invoice
                {
                    Project = projects[random.Next(0, projects.Length)],
                    Client = contragents[clientId],
                    Supplier = contragents[supplierId],
                    Text = RandomDescription(random),
                    Date = RandomDate(random),
                    Price = (decimal)(random.Next(10, 1000) * 1.24),
                    Vat = random.Next(7, 21),
                    Town = RandomTown(random),
                    InvoiceNum = RandomInvoice(random)
                };

                supplierInvoice.Total = supplierInvoice.Price * supplierInvoice.Vat;

                supplierInvoices.Add(supplierInvoice);
            }

            context.Invoices.AddRange(supplierInvoices);

            //Validate Payments
            var payments = new List<Payment>();
            for (int i = 0; i < 50; i++)
            {
                var clientId = random.Next(0, contragents.Length);
                var supplierId = random.Next(0, contragents.Length);

                while (clientId == supplierId)
                {
                    clientId = random.Next(0, contragents.Length);
                }

                var payment = new Payment
                {
                    Project = projects[random.Next(0, projects.Length)],
                    Client = contragents[clientId],
                    Supplier = contragents[supplierId],
                    Date = RandomDate(random),
                    Price = (decimal)(random.Next(13, 1000) * 1.35),
                    Vat = random.Next(3, 21),
                };
                payment.Total = payment.Price * payment.Vat;

                payments.Add(payment);
            }

            context.Payments.AddRange(payments);

            var events = new List<CalendarEvent>();

            for (int i = 0; i < 50; i++)
            {

                var startDate = RandomDate(random);
                var endDate = RandomDate(random);
                while (startDate >= endDate)
                {
                    startDate = RandomDate(random);
                }

                var @event = new CalendarEvent
                {
                    Color = RandomEnum<Color>(random),
                    Creator = users[random.Next(0, users.Count)],
                    Description = RandomDescription(random),
                    Project = projects[random.Next(0, projects.Length)],
                    StartTime = startDate,
                    EndTime = endDate,
                    Title = RandomTitle(random)
                };

                while (events.Any(e => e.Title == @event.Title))
                {
                    @event.Title = RandomTitle(random);
                }

                events.Add(@event);
            }

            context.CalendarEvents.AddRange(events);

            context.SaveChanges();

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
                new Contragent {PersonalVatNumber = "SD12351",PersonalIndentityNumber = "101205", BankDetails="BGNKJ1453STZ", Telephone = "0879665233",Town = "Haskovo", Address= "Hristo Botev 207", Description = "Food & Sweets", Email = "abv@gmail.com", Name = "Kaufland AD" , PersonForContact= "Vladimir", },
                new Contragent {PersonalVatNumber = "DFA1235",PersonalIndentityNumber = "102233", BankDetails="UKLDNSF1523SF", Telephone = "0889655294",Town = "Sofia", Address= "Peicho Slaveikov 3", Description = "Monthly Supplies", Email = "hugo@abv.bg", Name = "WeSupply EOOD", PersonForContact = "Pesho"},
                new Contragent {PersonalVatNumber = "DAS1233",PersonalIndentityNumber = "103452", BankDetails="DESF1523STZ", Telephone = "0879615259",Town = "Veliko Tarnovo", Address= "Raina Knqginq 24", Description = "Cleaning stuff", Email = "namaste@gmail.com", Name = "Goods EOOD", PersonForContact = "Ivan"},
                new Contragent {PersonalVatNumber = "DS12357",PersonalIndentityNumber = "104623", BankDetails="USASF1523STZ", Telephone = "0879665232",Town = "Yambol", Address= "Biznes Park Sofia", Description = "Internet services", Email = "koki@yahoo.com", Name = "Market2U OOD", PersonForContact = "Georgi"},
                new Contragent {PersonalVatNumber = "DJG1236",PersonalIndentityNumber = "105125", BankDetails="MEXSF1523STZ", Telephone = "0879665275",Town = "New York", Address= "Tsar Simeon Veliki 137", Description = "Fruits and Water Supply", Email = "bobi.v@abv.bg", Name = "Billa AD", PersonForContact = "Vladimir"},
            };

            context.Contragents.AddRange(contragents);
            context.SaveChanges();
        }

        public static void SeedInquiry()
        {
            var context = new BmsContex();
            var inquiries = new[]
            {
                new Inquiry { ContragentId = 1, CreatorId = 2, Date = DateTime.Now ,  Description = "Create me Web App"},
                new Inquiry { ContragentId = 2, CreatorId = 3, Date = DateTime.Now ,  Description = "Sell that stock"},
                new Inquiry { ContragentId = 3, CreatorId = 4, Date = DateTime.Now ,  Description = "Configure Computer"},
                new Inquiry { ContragentId = 4, CreatorId = 5, Date = DateTime.Now ,  Description = "Reinstall Windows"},
                new Inquiry { ContragentId = 5, CreatorId = 6, Date = DateTime.Now ,  Description = "Android App Inquiry"}
            };
            context.Inquiries.AddRange(inquiries);
            context.SaveChanges();
        }

        public static void SeedOffers()
        {
            var context = new BmsContex();
            var offers = new[]
            {
                new Offer { ContragentId = 1, CreatorId = 2, Date = DateTime.Now , InquiryId = 1, Description = "Cost: $1300"},
                new Offer { ContragentId = 2, CreatorId = 3, Date = DateTime.Now , InquiryId = 2, Description = "Cost: $2500"},
                new Offer { ContragentId = 3, CreatorId = 4, Date = DateTime.Now , InquiryId = 3, Description = "Cost: $3300"},
                new Offer { ContragentId = 4, CreatorId = 5, Date = DateTime.Now , InquiryId = 4, Description = "Cost: $1800"},
                new Offer { ContragentId = 5, CreatorId = 6, Date = DateTime.Now , InquiryId = 5, Description = "Cost: $3200"}
            };
            context.Offers.AddRange(offers);
            context.SaveChanges();
        }

        public static void SeedProjects()
        {
            var context = new BmsContex();
            var project = new[]
            {
                new Project { ContragentId = 1, CreatorId = 2, OfferId = 1, StartDate = DateTime.Today.AddDays(-10) ,EndDate = DateTime.Today.AddDays(20),DeadLine = DateTime.Today.AddDays(18), InquiryId = 1, Name = "Android App"},
                new Project { ContragentId = 2, CreatorId = 3, OfferId = 2, StartDate =DateTime.Today.AddDays(-32) ,EndDate =  DateTime.Today.AddDays(30),DeadLine = DateTime.Today.AddDays(28), InquiryId = 2, Name = "Desktop App"},
                new Project { ContragentId = 3, CreatorId = 4, OfferId = 3, StartDate = DateTime.Today.AddDays(-40) ,EndDate = DateTime.Today.AddDays(40),DeadLine = DateTime.Today.AddDays(38), InquiryId = 3, Name = "Web App"},
                new Project { ContragentId = 4, CreatorId = 5, OfferId = 4, StartDate = DateTime.Today.AddDays(-52) ,EndDate = DateTime.Today.AddDays(50),DeadLine = DateTime.Today.AddDays(48), InquiryId = 4, Name = "Sports WebSite"},
                new Project { ContragentId = 5, CreatorId = 6, OfferId = 5, StartDate = DateTime.Today.AddDays(-16) ,EndDate = DateTime.Today.AddDays(35),DeadLine = DateTime.Today.AddDays(33), InquiryId = 5, Name = "Product Management"}
            };
            context.Projects.AddRange(project);
            context.SaveChanges();
        }

        private static T RandomEnum<T>(Random random)
        {
            var values = Enum.GetValues(typeof(T));
            var randomEnum = (T)values.GetValue(random.Next(values.Length));
            return randomEnum;
        }

        private static DateTime RandomDate(Random random)
        {
            var start = new DateTime(1991, 1, 1);
            var range = (DateTime.Today - start).Days;
            var endDate =
                start.AddDays(random.Next(range)).AddHours(random.Next(0, 24)).AddMinutes(random.Next(0, 60)).AddSeconds(random.Next(0, 60));
            return endDate;
        }

        private static string RandomDescription(Random random)
        {
            var words = "health,trouble,hierarchy,cover,threat,board,gaffe,help,basin,harvest,bee,telephone,brand,profit,aloof,symptom,memorandum,emphasis,tumble,pipe,damage,attack,stun,surgeon,leak,necklace,integrity,casualty,established,jockey,guest,speech,carve,direction,retire,function,cry,braid,elite,produce,avant-garde,location,systematic,recording,shoulder,fiction,breakfast,perceive,circle,fresh,crisis,reactor,rare,privacy,quarter,beer,triangle,float,budget,touch,basic,wear,package,possibility,steep,hypnothize,talented,rape,willpower,layout,core,lamb,difficulty,tear,teacher,praise,entry,brick,cereal,scrap,hear,knock,Sunday,virgin,generate,preparation,principle,ambiguity,oppose,wood,bottle,resignation,orchestra,shape,cheese,key,fix,inject,button,liberty,classroom,sequence,performer,chase,gate,block,sport,egg white,president,trance,continuous,publication,difficult,dignity,norm,equation,temporary,summit,tube,bar,long,extinct,contrary,portrait,fall,afford,clock,superintendent,professor,clothes,prospect,packet,trivial,freeze,related,healthy,fee,hotdog,aware,filter,court,articulate,aspect,vegetarian,loyalty,overall,branch,constitution,government,glare,material,disclose,document,selection,sweep,marsh,mutual,award,suit,import,thin,undertake,shy,flood,officer,listen,area,nun,chief,bag,legislature,dough,texture,hypothesize,smash,smart,occasion,place,witch,mark,attractive,custody,compensation,fantasy,innovation,offend,bucket,critic,strap,stool,integrated,inflate,twilight,see,wife,arrow,epicalyx,drown,pure,quotation,sympathetic,throw,light,site,suppress,denial,contradiction,agreement,embrace,miner,take,simplicity,arrest,microphone,assembly,adjust,charity,meat,tiger,desk,honest,partnership,layer,break down,adventure,understand,product,monarch,knife,budge,rib,demand,connection,date,rub,make,smell,coerce,Mars,scatter,extract,dirty,behavior,lift,pass,subway,revival,discreet,persist,relaxation,cathedral,avenue,variable,surface,instal,literacy,pen,fool around,film,sheet,flex,designer,race,large,priority,struggle,marble,important,axis,lead,compose,mass,frighten,abnormal,diagram,reliance,ground,beautiful,dream,injection,meet,shadow,chest,fashion,land,forget,turn,happen,cousin,symbol,exemption,expect,result,flavor,elephant,blue,grateful,lazy,ritual,retiree,rubbish,wear out,worker,shock,emergency,patience,smile,ignite,first,structure,alarm,chimney,suburb,requirement,explosion,prevalence,authority,sting,map,talkative,conference,forecast,testify,thread,temple,patient,bed,queue,veil,money,pressure,rational,curve,deadly,flight,nominate,crowd,guide,publicity,hurt,paradox,presidential,node,mouth,formation,stubborn,indirect,eye,astonishing,pride,weakness,straw,few,banana,sentiment,candidate,management,protect,preference,falsify,section,transport,run,round,refuse,shave,vacuum,conceive,model,list,meaning,taxi,discourage,indication,advantage,revolutionary,introduce,wealth,complain,vegetable,fear,fortune,civilization,cellar,exit,voyage,consciousness,garlic,mechanical,inappropriate,rocket,trace,bread,legend,siege,declaration,green,arrangement,discuss,find,fox,biology,senior,dare,education,investment,confidence,reception,tail,judge,terrify,dividend,ivory,criminal,dollar,vision,realize,polish,war,medieval,modest,loss,similar,stroke,heaven,account,cage,omission,pay,essential,depression,vigorous,ghost,undress,penny,junior,wing,lace,shorts,splurge,allowance,extent,open,build,gold,buffet,rebellion,powder,rainbow,mask,era,sculpture,lawyer,sun,horse,opposed,strong,secular,fossil,circulate,analysis,fax,standard,rhythm,performance,horoscope,reduction,policy,capital,hut,pan,retreat,neighborhood,laundry,irony,disappointment,appendix,candle,judicial,market,provoke,iron,sigh,salvation,highway,foundation,illness,quit,arch,snuggle,rotate,coincide,tray,precede,crevice,character,spring,conscience,feminist,heir";

            var wordsSplit = words.Split(',');

            var wordsToAdd = new List<string>();

            for (int i = 0; i < 15; i++)
            {
                wordsToAdd.Add(wordsSplit[random.Next(0, wordsSplit.Length)]);
            }

            var sentence = string.Join(" ", wordsToAdd);

            return sentence;
        }

        private static string RandomTitle(Random random)
        {
            var randomSentence = RandomDescription(random);
            var randomTitle = randomSentence.Split()[random.Next(0, randomSentence.Split().Length)];

            return randomTitle;
        }

        private static string RandomTown(Random random)
        {
            var towns = new List<string>() { "Plovdiv","Sofia","Varna","Burgas","Ruse","Varna","StaraZagora",
                "Gabrovo","Sevlievo","Pleven","Vidin","Lom","Silistra","Kurdjali" };

            var randomCity = towns[random.Next(0,towns.Count-1)];
            return randomCity;
        }

        private static int RandomInvoice(Random random)
        {
            var invoices = new List<int>() { 397933065, 578818815, 333372723, 553708490,
                543745590, 859616541, 645152523, 1346363246, 155232567, 732562627,
                62626065, 578418815, 333372723, 653708490,
                17626065, 575218815, 333372723, 353838880,
                32626065, 578818815, 325372723, 213705350,
                40626065, 149918815, 386372723, 123779950,
                125747236 };

            var randomInvoice = invoices[random.Next(0, invoices.Count - 1)];
            return randomInvoice;
        }
    }
}
