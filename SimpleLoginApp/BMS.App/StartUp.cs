using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfApp1.Data;
using WpfApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace WpfApp1.App
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new BmsDbContext())
            {
                ResetDatabase(context);
            }
        }

        private static void ResetDatabase(BmsDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Database.EnsureCreated();

            //Seed(context);
        }

        //private static void Seed(BmsDbContext context)
        //{
        //    var random = new Random();

        //    var loremImpsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

        //    var loremArr = loremImpsum.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        //    var randomNames = "Ona Croskey  Mai TribbleLucy Wieczorek  Randy Burciaga  Luciano Tell  Ernesto Delreal  Gaylene Bozek  Damian Fravel  Merrie Carty  Evan Bransford  Oretha Hakala  Jonna Sponaugle  Edda Starkey  Clelia Rahm  Arden Pintor  Angeline Prunty  Tamiko Rosborough  Clarissa Slade  Elanor Dicicco  Juana Adolphsen  Kevin Kulp  Han Delisa  Karole Tannehill  Rachelle Amezcua  Myron Wingo  Darlene Haworth  Claris Humber  Ronald Richie  Heath Maharaj  Inez Devera";

        //    var randomNamesArr = randomNames.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

        //    var randomFirms = "The Walt Disney Company,Audi,Adobe Systems,Microsoft,Wal-Mart,BlackBerry,BMW,Shell Oil Company,Smirnoff,NTT Data,United Parcel Service,Starbucks,Johnson & Johnson,General Electric,Credit Suisse,Moët et Chandon,Gucci,IKEA,Amazon.com,Morgan Stanley,Panasonic Corporation,Allianz,PepsiCo,Xerox,Johnnie Walker,Verizon Communications,Facebook, Inc.,Coca-Cola,MTV,SAP,Beko,Kia Motors,3M,Honda Motor Company, Ltd,Kleenex,Nokia,Pizza Hut,Siemens AG,Heineken Brewery,Tiffany & Co.,Home Depot,Cisco Systems, Inc.,Oracle Corporation,HSBC,Canon,McDonald's,Intel Corporation,Citigroup,Volkswagen Group,Nintendo,Harley-Davidson Motor Company,Nike, Inc.,Wells Fargo,AT&T,Deere & Company,Cartier SA,Bank of America,Ferrari S.p.A.,Tesco Corporation,Louis Vuitton,Corona,Google,Nescafé,MasterCard,Zara,Avon,Sprite,IBM,Global Gillette,KFC,Hewlett-Packard,L'Oréal,Chase,Prada,Jack Daniel's,Apple Inc.,Kellogg Company,Ralph Lauren Corporation,Porsche,Pampers";

        //    var randomFirmsArr = randomFirms.Split(',', StringSplitOptions.RemoveEmptyEntries).ToArray();

        //    var alphabet = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
        //    var alphabetArr = alphabet.Split(',', StringSplitOptions.RemoveEmptyEntries).ToArray();

        //    var contragents = new List<Contragent>();

        //    for (int i = 0; i < 200; i++)
        //    {
        //        var contragent = new Contragent
        //        {
        //            Name = RandomString(random, randomFirmsArr),
        //            PersonForContact = RandomString(random, randomNamesArr),
        //            VatNumber = RandomVatNumber(random)
        //        };

        //        if (contragents.Any(c => c.VatNumber == contragent.VatNumber))
        //        {
        //            continue;
        //        }

        //        contragents.Add(contragent);

        //    }

        //    context.Contragents.AddRange(contragents);

        //    //var contragents = new[]
        //    //{
        //    //    new Contragent { VatNumber = "SD12351", Name = "Billa AD" , PersonForContact= "Ona Croskey "},
        //    //    new Contragent { VatNumber = "FD52352", Name = "Lidl AD" },
        //    //    new Contragent { VatNumber = "DD14351", Name = "Harribo AD" },
        //    //    new Contragent { VatNumber = "GD72355", Name = "Bai Ivan OOD" },
        //    //    new Contragent { VatNumber = "XC64351", Name = "Dragan OOD" },
        //    //    new Contragent { VatNumber = "ZV34353", Name = "Acer AD" },
        //    //    new Contragent { VatNumber = "VB99931", Name = "Nvdia AD" },
        //    //    new Contragent { VatNumber = "NM75322", Name = "Random OOD" },
        //    //    new Contragent { VatNumber = "DFA1235", Name = "WeSupply EOOD", PersonForContact = "Pesho"},
        //    //    new Contragent { VatNumber = "DAS1233", Name = "Goods EOOD", PersonForContact = "Ivan"},
        //    //    new Contragent { VatNumber = "DS12357", Name = "Market2U OOD", PersonForContact = "Georgi"},
        //    //    new Contragent { VatNumber = "DJG1236", Name = "Billa AD", PersonForContact = "Dragan"},
        //    //    new Contragent { VatNumber = "PKL1235", Name = "Random EAD", PersonForContact = "Petkan"},
        //    //    new Contragent { VatNumber = "KSJS516", Name = "H2COOH OOD", PersonForContact = "Vladimir"},
        //    //    new Contragent { VatNumber = "PP92922", Name = "Tycoons AD", PersonForContact = "Simeon"},
        //    //    new Contragent { VatNumber = "PPL9128", Name = "Ilienci AD", PersonForContact = "Bai Mangau"},
        //    //};

        //    context.Contragents.AddRange(contragents);

        //    var banks = new[]
        //    {
        //        new Bank { Address = "Sofia, bul.Hristo Botev 35", Name = "Societe Generale", BIC = "ADSA546"},
        //        new Bank { Address = "Sofia, bul. Nqma takuv", Name = "First Investment", BIC = "GGDF213"},
        //        new Bank { Address = "Sofia, str.Vitoshka 14", Name = "UniCreditBulBank", BIC = "KKOP764"},
        //        new Bank { Address = "Sofia, bul.Evlogi Georgiev", Name = "United Bulgarian Bank", BIC = "QQQP995"},
        //        new Bank { Address = "Varna, str.street in Varna", Name = "Random Bank", BIC = "KOSS554"},
        //        new Bank { Address = "Burgas, str.Random", Name = "Goldman Sachs", BIC = "RNDM943"},
        //        new Bank { Address = "Sofia, bul.Hristo Botev 14", Name = "Bank of America", BIC = "UITR683"},
        //        new Bank { Address = "Plvodiv, str.Main Street", Name = "JP Morgan Chase", BIC = "YEPA743"},
        //    };

        //    context.Banks.AddRange(banks);


        //    var bankAccounts = new List<BankAccount>();
        //    foreach (var contragent in contragents)
        //    {
        //        var accountNameArray = contragent.Name
        //                       .ToUpper()
        //                       .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        //                       .ToArray();
        //        var fullAccountName = string.Join("", accountNameArray.Reverse());
        //        var accountLetters = fullAccountName.ToCharArray();

        //        var alreadyAddedAccountNumbers = new List<string>();
        //        for (int i = 0; i < 5; i++)
        //        {
        //            var accountNumber = random.Next(10000, 100000).ToString();
        //            var lettersToAppend = string.Join("", accountLetters.Take(random.Next(4, accountLetters.Length)).ToArray());

        //            var fullAccountNumber = accountNumber + $"{lettersToAppend}";

        //            if (alreadyAddedAccountNumbers.Contains(fullAccountNumber))
        //            {
        //                continue;
        //            }

        //            var bankId = random.Next(0, banks.Length);

        //            var bankAccount = new BankAccount
        //            {
        //                AccountNumber = fullAccountNumber,
        //                Bank = banks[bankId],
        //                Contragent = contragent
        //            };

        //            bankAccounts.Add(bankAccount);
        //            alreadyAddedAccountNumbers.Add(fullAccountNumber);
        //        }
        //    }

        //    //foreach (var supplier in suppliers)
        //    //{
        //    //    var accountNameArray = supplier.Name
        //    //                   .ToUpper()
        //    //                   .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        //    //                   .ToArray();
        //    //    var fullAccountName = string.Join("", accountNameArray.Reverse());
        //    //    var accountLetters = fullAccountName.ToCharArray();

        //    //    var alreadyAddedAccountNumbers = new List<string>();
        //    //    for (int i = 0; i < 5; i++)
        //    //    {
        //    //        var accountNumber = random.Next(10000, 100000).ToString();

        //    //        var chars = new char[random.Next(4, 7)];

        //    //        for (int j = 0; j < chars.Length; j++)
        //    //        {
        //    //            chars[j] = accountLetters[random.Next(accountLetters.Length)];
        //    //        }

        //    //        var lettersToAppend = new String(chars);

        //    //        var fullAccountNumber = accountNumber + $"{lettersToAppend}";

        //    //        if (alreadyAddedAccountNumbers.Contains(fullAccountNumber))
        //    //        {
        //    //            continue;
        //    //        }

        //    //        var bankId = random.Next(0, banks.Length);

        //    //        var bankAccount = new BankAccount
        //    //        {
        //    //            AccountNumber = fullAccountNumber,
        //    //            Bank = banks[bankId],
        //    //            Supplier = supplier
        //    //        };

        //    //        bankAccounts.Add(bankAccount);
        //    //        alreadyAddedAccountNumbers.Add(fullAccountNumber);
        //    //    }
        //    //}

        //    context.BankAccounts.AddRange(bankAccounts);

        //    var inquiries = new List<Inquiry>();
        //    for (int i = 0; i < 50; i++)
        //    {
        //        var inquiry = new Inquiry
        //        {
        //            Client = contragents[random.Next(0, contragents.Length)],
        //            Date = RandomStartDate(random),
        //            Description = RandomText(random, loremArr)
        //        };

        //        if (inquiries.Any(iq => iq.Client == inquiry.Client && iq.Description == inquiry.Description))
        //        {
        //            continue;
        //        }

        //        inquiries.Add(inquiry);
        //    }

        //    context.Inquiries.AddRange(inquiries);
        //    //var inquiries = new[]
        //    //{
        //    //    new Inquiry { Client = contragents[0], Date = new DateTime(2017,12,12), Description = "Tursq gumi za Jigula"},
        //    //    new Inquiry { Client = contragents[0], Date = new DateTime(2014,07,22), Description = "Tursq kola na evtino"},
        //    //    new Inquiry { Client = contragents[1], Date = new DateTime(2013,08,23), Description = "random random"},
        //    //    new Inquiry { Client = contragents[2], Date = new DateTime(2007,09,14), Description = "Nqma takuv request"},
        //    //    new Inquiry { Client = contragents[3], Date = new DateTime(2009,04,10), Description = "PeshoIsKing"},
        //    //    new Inquiry { Client = clients[4], Date = new DateTime(1999,01,01), Description = "Prodavam kushta v Selo Ivanovo"},
        //    //    new Inquiry { Client = clients[2], Date = new DateTime(2001,02,03), Description = "Prodavam Parcel v Sofiq"},
        //    //    new Inquiry { Client = clients[5], Date = new DateTime(2000,03,04), Description = "Tursq Hotel v centura"},
        //    //    new Inquiry { Client = clients[6], Date = new DateTime(2005,05,05), Description = "Kupuvam koli na edro"},
        //    //    new Inquiry { Client = clients[7], Date = new DateTime(2011,11,16), Description = "Neshto mi trqaa ma ne zna kvo"},
        //    //    new Inquiry { Client = clients[7], Date = new DateTime(2014,10,29), Description = "JIGULI TI SI STRASHNA KOLA"},
        //    //    new Inquiry { Client = clients[6], Date = new DateTime(2017,02,28), Description = "Izkupuvam chasti za traktor"},
        //    //    new Inquiry { Client = clients[4], Date = new DateTime(2008,07,30), Description = "Tursq arhitekt za garaj"},
        //    //    new Inquiry { Client = clients[3], Date = new DateTime(2010,06,12), Description = "Tursq ovoshna gradina za pod naem"},
        //    //    new Inquiry { Client = clients[1], Date = new DateTime(2003,07,14), Description = "Kupuvam chastni parceli na edro"},
        //    //    new Inquiry { Client = clients[0], Date = new DateTime(2004,08,25), Description = "Tursq nemo"},
        //    //};

        //    context.Inquiries.AddRange(inquiries);

        //    var employees = new[]
        //    {
        //        new Employee { FirstName = "Ivan", LastName = "Georgiev", Clearence = ClearenceType.Employee},
        //        new Employee { FirstName = "Petur", LastName = "Georgiev", Clearence = ClearenceType.Employee},
        //        new Employee { FirstName = "Hristo", LastName = "Petkov", Clearence = ClearenceType.Employee},
        //        new Employee { FirstName = "Martin", LastName = "Dimitrov", Clearence = ClearenceType.Employee},
        //        new Employee { FirstName = "Vladimir", LastName = "Vasilev", Clearence = ClearenceType.Employee},
        //        new Employee { FirstName = "Simeon", LastName = "KaraIvanov", Clearence = ClearenceType.Employee},
        //        new Employee { FirstName = "Petkan", LastName = "Petkanov", Clearence = ClearenceType.Employee},
        //        new Employee { FirstName = "Dragan", LastName = "Piriliev", Clearence = ClearenceType.Employee},
        //        new Employee { FirstName = "Chicko", LastName = "Scrutch", Clearence = ClearenceType.Employee},
        //        new Employee { FirstName = "Bill", LastName = "Martinson", Clearence = ClearenceType.Employee},
        //        new Employee { FirstName = "Volodq", LastName = "Limanov", Clearence = ClearenceType.Admin},
        //        new Employee { FirstName = "NeVodq", LastName = "Kone", Clearence = ClearenceType.Admin},
        //        new Employee { FirstName = "Samo", LastName = "Petli", Clearence = ClearenceType.Employee},
        //        new Employee { FirstName = "Karam", LastName = "Kola", Clearence = ClearenceType.Employee},
        //        new Employee { FirstName = "Krustia", LastName = "Bebeta", Clearence = ClearenceType.Admin},
        //    };

        //    context.Employees.AddRange(employees);

        //    var offers = new List<Offer>();

        //    for (int i = 0; i < 60; i++)
        //    {
        //        var employeeId = random.Next(0, employees.Length);
        //        var inquiryId = random.Next(0, inquiries.Count);
        //        var clientId = random.Next(0, contragents.Length);

        //        var offer = new Offer
        //        {
        //            Employee = employees[employeeId],
        //            Inquiry = inquiries[inquiryId],
        //            DateTime = RandomStartDate(random),
        //            Description = RandomText(random, loremArr)
        //        };

        //        if (offers.Any(o => o.Employee == offer.Employee && o.Inquiry == offer.Inquiry))
        //        {
        //            continue;
        //        }

        //        offers.Add(offer);
        //    }

        //    context.Offers.AddRange(offers);

        //    //var contracts = new List<Contract>();
        //    //for (int i = 0; i < 20; i++)
        //    //{
        //    //    var employeeId = random.Next(0, employees.Length);
        //    //    var offerId = random.Next(0, offers.Count);
        //    //    var descriptionToAppend = RandomText(random, loremArr);

        //    //    var contract = new Contract
        //    //    {
        //    //        Date = RandomStartDate(random),
        //    //        Description = descriptionToAppend,
        //    //        Employee = employees[employeeId],
        //    //        Offer = offers[offerId]
        //    //    };

        //    //    if (contracts.Any(c => c.Offer == contract.Offer))
        //    //    {
        //    //        continue;
        //    //    }

        //    //    contracts.Add(contract);
        //    //}

        //    //context.Contracts.AddRange(contracts);

        //    var projects = new List<Project>();

        //    for (int i = 0; i < 50; i++)
        //    {
        //        var employeeId = random.Next(0, employees.Length);
        //        var offerId = random.Next(0, offers.Count);
        //        var contragentId = random.Next(0, contragents.Length);

        //        var projectName = RandomString(random, randomNamesArr);

        //        var project = new Project
        //        {
        //            Client = contragents[contragentId],
        //            Employee = employees[employeeId],
        //            Offer = offers[offerId],
        //            Name = projectName
        //        };

        //        var startDate = RandomStartDate(random);
        //        var deadLine = RandomEndDate(random);

        //        while (startDate >= deadLine)
        //        {
        //            startDate = RandomStartDate(random);
        //            deadLine = RandomEndDate(random);
        //        }

        //        if (projects.Any(p => p.Name == project.Name || p.Offer == project.Offer))
        //        {
        //            continue;
        //        }

        //        //var existingContract = contracts.SingleOrDefault(c => c.Offer == project.Offer);
        //        //if (existingContract != null)
        //        //{
        //        //    project.Contract = existingContract;
        //        //}

        //        project.StartDate = startDate;
        //        project.DeadLine = deadLine;

        //        if (i % 3 == 0 || i % 4 == 0)
        //        {
        //            project.EndDate = deadLine.AddDays(5);
        //        }

        //        projects.Add(project);
        //    }

        //    context.Projects.AddRange(projects);

        //    var invoicesClient = new List<InvoiceClient>();

        //    for (int i = 0; i < 35; i++)
        //    {
        //        var projectId = random.Next(0, projects.Count);

        //        var invoiceClient = new InvoiceClient
        //        {
        //            InvoiceNumber = GenerateInvoiceNumber(random),
        //            Date = RandomStartDate(random),
        //            Client = projects[projectId].Client,
        //            TotalPrice = (decimal)((random.Next(1, 10) * contragents.Length * projects.Count) / (projectId + 1)),
        //            VAT = random.Next(7, 21)
        //        };

        //        if (invoicesClient.Any(ic => ic.InvoiceNumber == invoiceClient.InvoiceNumber))
        //        {
        //            continue;
        //        }

        //        invoicesClient.Add(invoiceClient);
        //    }

        //    context.InvoicesClient.AddRange(invoicesClient);

        //    var invoicesSupplier = new List<InvoiceSupplier>();

        //    for (int i = 0; i < 35; i++)
        //    {
        //        var supplierId = random.Next(0, contragents.Length);
        //        var projectId = random.Next(0, projects.Count);

        //        var invoiceSupplier = new InvoiceSupplier
        //        {
        //            InvoiceNumber = GenerateInvoiceNumber(random),
        //            Date = RandomStartDate(random),
        //            Supplier = contragents[supplierId],
        //            TotalPrice = (decimal)((random.Next(1, 10) * contragents.Length * projects.Count) / (supplierId + 1)),
        //            VAT = random.Next(7, 21)
        //        };

        //        if (invoicesSupplier.Any(@is => @is.InvoiceNumber == invoiceSupplier.InvoiceNumber))
        //        {
        //            continue;
        //        }

        //        invoicesSupplier.Add(invoiceSupplier);
        //    }

        //    context.InvoicesSupplier.AddRange(invoicesSupplier);

        //    var projectSuppliers = new List<ProjectSupplier>();
        //    for (int i = 0; i < 200; i++)
        //    {
        //        var projectId = random.Next(0, projects.Count);
        //        var supplierId = random.Next(0, contragents.Length);

        //        var projectSupplier = new ProjectSupplier
        //        {
        //            Project = projects[projectId],
        //            Supplier = contragents[supplierId]
        //        };

        //        if (projectSuppliers.Any(p => p.Project == projectSupplier.Project && p.Supplier == projectSupplier.Supplier))
        //        {
        //            continue;
        //        }

        //        if (projects[projectId].Client == projectSupplier.Supplier)
        //        {
        //            continue;
        //        }
        //        projectSuppliers.Add(projectSupplier);
        //    }

        //    context.ProjectsSuppliers.AddRange(projectSuppliers);

        //    context.SaveChanges();

        //    //var suppliersFromDb = context.Contragents.ToList();
        //    //foreach (var supplier in suppliersFromDb)
        //    //{

        //    //    if (random.Next(2, 6) % 2 == 0)
        //    //    {
        //    //        supplier.Project = projects[random.Next(0, projects.Count)];
        //    //    }
        //    //}

        //    //context.SaveChanges();
        //}

        private static string RandomVatNumber(Random random, string[] alphabetArr)
        {
            var firstTwoLetters = alphabetArr;
            return null;
        }

        private static string GenerateInvoiceNumber(Random random)
        {
            var numbers1 = random.Next(1000000000, int.MaxValue).ToString().ToCharArray();

            var numbers2 = random.Next(700001).ToString().ToCharArray();

            var sb = new StringBuilder();

            var numberToAdd = 0;
            for (int i = 0; i < numbers1.Length; i++)
            {
                var firstNumberToInsert = int.Parse(numbers1[i].ToString());
                var secondNumberToInsert = int.Parse(numbers1[random.Next(0, numbers1.Length)].ToString());
                var result = firstNumberToInsert + secondNumberToInsert + numberToAdd;

                numberToAdd = 0;
                if (result >= 10)
                {
                    result -= 10;
                    numberToAdd = 1;
                }

                sb.Append(result.ToString());
            }

            return sb.ToString();
            
        }

        private static string RandomString(Random random, string[] randomNamesArr)
        {
            var arrName = new string[random.Next(10, randomNamesArr.Length)];

            for (int p = 0; p < arrName.Length; p++)
            {
                arrName[p] = randomNamesArr[random.Next(0, randomNamesArr.Length)];
            }

            var randomNameToAppend = arrName[random.Next(0, arrName.Length)].Trim().ToLower();
            return randomNameToAppend;
        }

        private static string RandomText(Random random, string[] loremArr)
        {
            var arrLorem = new string[random.Next(10, loremArr.Length)];

            for (int p = 0; p < arrLorem.Length; p++)
            {
                arrLorem[p] = loremArr[random.Next(0, loremArr.Length)];
            }

            var descriptionToAppend = string.Join(" ", arrLorem).Trim();
            return descriptionToAppend;
        }

        private static DateTime RandomStartDate(Random random)
        {
            var start = new DateTime(1991, 1, 1);
            var range = (DateTime.Today - start).Days;
            var end = start.AddDays(random.Next(range)).AddHours(random.Next(0, 24)).AddMinutes(random.Next(0, 60)).AddSeconds(random.Next(0, 60));
            return end;
        }

        private static DateTime RandomEndDate(Random random)
        {
            var start = new DateTime(1992, 1, 1);
            var range = (DateTime.Today - start).Days;
            var end = start.AddDays(random.Next(range)).AddHours(random.Next(0, 24)).AddMinutes(random.Next(0, 60)).AddSeconds(random.Next(0, 60));
            return end;
        }
    }
}
