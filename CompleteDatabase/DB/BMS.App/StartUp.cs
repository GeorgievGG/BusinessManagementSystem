using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BMS.Data;
using BMS.Models;
using Microsoft.EntityFrameworkCore;

namespace BMS.App
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new BmsDbContext())
            {
                //Понякога гърми,че има проект със същото име макар да съм го проверил.
                ResetDatabase(context);
            }
        }

        private static void ResetDatabase(BmsDbContext context)
        {
            context.Database.EnsureDeleted();

            //context.Database.EnsureCreated();
            context.Database.Migrate();

            Seed(context);
        }

        private static void Seed(BmsDbContext context)
        {
            var random = new Random();

            var loremImpsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

            var loremArr = loremImpsum.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var clients = new[]
            {
                new Client { VatNumber = "SD12351", Name = "Billa AD" },
                new Client { VatNumber = "FD52352", Name = "Lidl AD" },
                new Client { VatNumber = "DD14351", Name = "Harribo AD" },
                new Client { VatNumber = "GD72355", Name = "Bai Ivan OOD" },
                new Client { VatNumber = "XC64351", Name = "Dragan OOD" },
                new Client { VatNumber = "ZV34353", Name = "Acer AD" },
                new Client { VatNumber = "VB99931", Name = "Nvdia AD" },
                new Client { VatNumber = "NM75322", Name = "Random OOD" },
            };

            context.Clients.AddRange(clients);

            var banks = new[]
            {
                new Bank { Address = "Sofia, bul.Hristo Botev 35", Name = "Societe Generale", BIC = "ADSA546"},
                new Bank { Address = "Sofia, bul. Nqma takuv", Name = "First Investment", BIC = "GGDF213"},
                new Bank { Address = "Sofia, str.Vitoshka 14", Name = "UniCreditBulBank", BIC = "KKOP764"},
                new Bank { Address = "Sofia, bul.Evlogi Georgiev", Name = "United Bulgarian Bank", BIC = "QQQP995"},
                new Bank { Address = "Varna, str.street in Varna", Name = "Random Bank", BIC = "KOSS554"},
                new Bank { Address = "Burgas, str.Random", Name = "Goldman Sachs", BIC = "RNDM943"},
                new Bank { Address = "Sofia, bul.Hristo Botev 14", Name = "Bank of America", BIC = "UITR683"},
                new Bank { Address = "Plvodiv, str.Main Street", Name = "JP Morgan Chase", BIC = "YEPA743"},
            };

            context.Banks.AddRange(banks);

            var suppliers = new[]
            {
                new Supplier { VatNumber = "DFA1235", Name = "WeSupply EOOD", PersonForContact = "Pesho"},
                new Supplier { VatNumber = "DAS1233", Name = "Goods EOOD", PersonForContact = "Ivan"},
                new Supplier { VatNumber = "DS12357", Name = "Market2U OOD", PersonForContact = "Georgi"},
                new Supplier { VatNumber = "DJG1236", Name = "Billa AD", PersonForContact = "Dragan"},
                new Supplier { VatNumber = "PKL1235", Name = "Random EAD", PersonForContact = "Petkan"},
                new Supplier { VatNumber = "KSJS516", Name = "H2COOH OOD", PersonForContact = "Vladimir"},
                new Supplier { VatNumber = "PP92922", Name = "Tycoons AD", PersonForContact = "Simeon"},
                new Supplier { VatNumber = "PPL9128", Name = "Ilienci AD", PersonForContact = "Bai Mangau"},
            };

            context.Suppliers.AddRange(suppliers);


            var bankAccounts = new List<BankAccount>();
            foreach (var client in clients)
            {
                var accountNameArray = client.Name
                               .ToUpper()
                               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                               .ToArray();
                var fullAccountName = string.Join("", accountNameArray.Reverse());
                var accountLetters = fullAccountName.ToCharArray();

                var alreadyAddedAccountNumbers = new List<string>();
                for (int i = 0; i < 5; i++)
                {
                    var accountNumber = random.Next(10000, 100000).ToString();
                    var lettersToAppend = string.Join("", accountLetters.Take(random.Next(4, accountLetters.Length)).ToArray());

                    var fullAccountNumber = accountNumber + $"{lettersToAppend}";

                    if (alreadyAddedAccountNumbers.Contains(fullAccountNumber))
                    {
                        continue;
                    }

                    var bankId = random.Next(0, banks.Length);

                    var bankAccount = new BankAccount
                    {
                        AccountNumber = fullAccountNumber,
                        Bank = banks[bankId],
                        Client = client
                    };

                    bankAccounts.Add(bankAccount);
                    alreadyAddedAccountNumbers.Add(fullAccountNumber);
                }
            }

            foreach (var supplier in suppliers)
            {
                var accountNameArray = supplier.Name
                               .ToUpper()
                               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                               .ToArray();
                var fullAccountName = string.Join("", accountNameArray.Reverse());
                var accountLetters = fullAccountName.ToCharArray();

                var alreadyAddedAccountNumbers = new List<string>();
                for (int i = 0; i < 5; i++)
                {
                    var accountNumber = random.Next(10000, 100000).ToString();

                    var chars = new char[random.Next(4, 7)];

                    for (int j = 0; j < chars.Length; j++)
                    {
                        chars[j] = accountLetters[random.Next(accountLetters.Length)];
                    }

                    var lettersToAppend = new String(chars);

                    var fullAccountNumber = accountNumber + $"{lettersToAppend}";

                    if (alreadyAddedAccountNumbers.Contains(fullAccountNumber))
                    {
                        continue;
                    }

                    var bankId = random.Next(0, banks.Length);

                    var bankAccount = new BankAccount
                    {
                        AccountNumber = fullAccountNumber,
                        Bank = banks[bankId],
                        Supplier = supplier
                    };

                    bankAccounts.Add(bankAccount);
                    alreadyAddedAccountNumbers.Add(fullAccountNumber);
                }
            }

            context.BankAccounts.AddRange(bankAccounts);

            var inquiries = new[]
            {
                new Inquiry { Client = clients[0], Date = new DateTime(2017,12,12), Description = "Tursq gumi za Jigula"},
                new Inquiry { Client = clients[0], Date = new DateTime(2014,07,22), Description = "Tursq kola na evtino"},
                new Inquiry { Client = clients[1], Date = new DateTime(2013,08,23), Description = "random random"},
                new Inquiry { Client = clients[2], Date = new DateTime(2007,09,14), Description = "Nqma takuv request"},
                new Inquiry { Client = clients[3], Date = new DateTime(2009,04,10), Description = "PeshoIsKing"},
                new Inquiry { Client = clients[4], Date = new DateTime(1999,01,01), Description = "Prodavam kushta v Selo Ivanovo"},
                new Inquiry { Client = clients[2], Date = new DateTime(2001,02,03), Description = "Prodavam Parcel v Sofiq"},
                new Inquiry { Client = clients[5], Date = new DateTime(2000,03,04), Description = "Tursq Hotel v centura"},
                new Inquiry { Client = clients[6], Date = new DateTime(2005,05,05), Description = "Kupuvam koli na edro"},
                new Inquiry { Client = clients[7], Date = new DateTime(2011,11,16), Description = "Neshto mi trqaa ma ne zna kvo"},
                new Inquiry { Client = clients[7], Date = new DateTime(2014,10,29), Description = "JIGULI TI SI STRASHNA KOLA"},
                new Inquiry { Client = clients[6], Date = new DateTime(2017,02,28), Description = "Izkupuvam chasti za traktor"},
                new Inquiry { Client = clients[4], Date = new DateTime(2008,07,30), Description = "Tursq arhitekt za garaj"},
                new Inquiry { Client = clients[3], Date = new DateTime(2010,06,12), Description = "Tursq ovoshna gradina za pod naem"},
                new Inquiry { Client = clients[1], Date = new DateTime(2003,07,14), Description = "Kupuvam chastni parceli na edro"},
                new Inquiry { Client = clients[0], Date = new DateTime(2004,08,25), Description = "Tursq nemo"},
            };

            context.Inquiries.AddRange(inquiries);

            var employees = new[]
            {
                new Employee { FirstName = "Ivan", LastName = "Georgiev", Clearence = ClearenceType.Employee},
                new Employee { FirstName = "Petur", LastName = "Georgiev", Clearence = ClearenceType.Employee},
                new Employee { FirstName = "Hristo", LastName = "Petkov", Clearence = ClearenceType.Employee},
                new Employee { FirstName = "Martin", LastName = "Dimitrov", Clearence = ClearenceType.Employee},
                new Employee { FirstName = "Vladimir", LastName = "Vasilev", Clearence = ClearenceType.Employee},
                new Employee { FirstName = "Simeon", LastName = "KaraIvanov", Clearence = ClearenceType.Employee},
                new Employee { FirstName = "Petkan", LastName = "Petkanov", Clearence = ClearenceType.Employee},
                new Employee { FirstName = "Dragan", LastName = "Piriliev", Clearence = ClearenceType.Employee},
                new Employee { FirstName = "Chicko", LastName = "Scrutch", Clearence = ClearenceType.Employee},
                new Employee { FirstName = "Bill", LastName = "Martinson", Clearence = ClearenceType.Employee},
                new Employee { FirstName = "Volodq", LastName = "Limanov", Clearence = ClearenceType.Admin},
                new Employee { FirstName = "NeVodq", LastName = "Kone", Clearence = ClearenceType.Admin},
                new Employee { FirstName = "Samo", LastName = "Petli", Clearence = ClearenceType.Employee},
                new Employee { FirstName = "Karam", LastName = "Kola", Clearence = ClearenceType.Employee},
                new Employee { FirstName = "Krustia", LastName = "Bebeta", Clearence = ClearenceType.Admin},
            };

            context.Employees.AddRange(employees);

            var offers = new List<Offer>();

            for (int i = 0; i < 60; i++)
            {
                var employeeId = random.Next(0, employees.Length);
                var inquiryId = random.Next(0, inquiries.Length);
                var clientId = random.Next(0, clients.Length);
                
                var offer = new Offer
                {
                    Employee = employees[employeeId],
                    Inquiry = inquiries[inquiryId],
                    DateTime = RandomDate(random),
                    Description = RandomText(random, loremArr)
                };

                if (offers.Any(o => o.Employee == offer.Employee && o.Inquiry == offer.Inquiry))
                {
                    continue;
                }

                offers.Add(offer);
            }

            context.Offers.AddRange(offers);

            var contracts = new List<Contract>();
            for (int i = 0; i < 20; i++)
            {
                var employeeId = random.Next(0, employees.Length);
                var offerId = random.Next(0, offers.Count);
                var descriptionToAppend = RandomText(random, loremArr);

                var contract = new Contract
                {
                    Date = RandomDate(random),
                    Description = descriptionToAppend,
                    Employee = employees[employeeId],
                    Offer = offers[offerId]
                };

                if (contracts.Any(c => c.Offer == contract.Offer))
                {
                    continue;
                }

                contracts.Add(contract);
            }

            context.Contracts.AddRange(contracts);

            var projects = new List<Project>();

            for (int i = 0; i < 50; i++)
            {
                var employeeId = random.Next(0, employees.Length);
                var offerId = random.Next(0, offers.Count);
                var clientId = random.Next(0, clients.Length);

                var projectName = RandomName(random, loremArr);

                var project = new Project
                {
                    Client = clients[clientId],
                    Date = RandomDate(random),
                    Employee = employees[employeeId],
                    Offer = offers[offerId],
                    Name = projectName
                };

                if (projects.Any(p => p.Name == project.Name || p.Offer == project.Offer))
                {
                    continue;
                }

                var existingContract = contracts.SingleOrDefault(c => c.Offer == project.Offer);
                if (existingContract != null)
                {
                    project.Contract = existingContract;
                }

                projects.Add(project);
            }

            context.Projects.AddRange(projects);

            var invoicesClient = new List<InvoiceClient>();

            for (int i = 0; i < 35; i++)
            {
                var projectId = random.Next(0, projects.Count);

                var invoiceClient = new InvoiceClient
                {
                    InvoiceNumber = GenerateInvoiceNumber(random),
                    Date = RandomDate(random),
                    Project = projects[projectId],
                    Client = projects[projectId].Client,
                    TotalPrice = (decimal)((random.Next(1, 10) * clients.Length * projects.Count) / (projectId + 1)),
                    VAT = random.Next(7,21)
                };

                if (invoicesClient.Any(ic => ic.InvoiceNumber == invoiceClient.InvoiceNumber))
                {
                    continue;
                }

                invoicesClient.Add(invoiceClient);
            }

            context.InvoicesClient.AddRange(invoicesClient);

            var invoicesSupplier = new List<InvoiceSupplier>();

            for (int i = 0; i < 35; i++)
            {
                var supplierId = random.Next(0, suppliers.Length);
                var projectId = random.Next(0, projects.Count);

                var invoiceSupplier = new InvoiceSupplier
                {
                    InvoiceNumber = GenerateInvoiceNumber(random),
                    Date = RandomDate(random),
                    Supplier = suppliers[supplierId],
                    TotalPrice = (decimal)((random.Next(1, 10) * clients.Length * projects.Count) / (supplierId  + 1)),
                    VAT = random.Next(7, 21)
                };

                if (invoicesSupplier.Any(@is => @is.InvoiceNumber == invoiceSupplier.InvoiceNumber))
                {
                    continue;
                }

                invoicesSupplier.Add(invoiceSupplier);
            }

            context.InvoicesSupplier.AddRange(invoicesSupplier);

            context.SaveChanges();


            var suppliersFromDb = context.Suppliers.ToList();
            foreach (var supplier in suppliersFromDb)
            {

                if (random.Next(2, 6) % 2 == 0) 
                {
                    supplier.Project = projects[random.Next(0, projects.Count)]; 
                }
            }

            context.SaveChanges();
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

        private static string RandomName(Random random, string[] loremArr)
        {
            var arrLorem = new string[random.Next(10, loremArr.Length)];

            for (int p = 0; p < arrLorem.Length; p++)
            {
                arrLorem[p] = loremArr[random.Next(0, loremArr.Length)];
            }

            var randomNameToAppend = arrLorem[random.Next(0, arrLorem.Length)].Trim();
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

        private static DateTime RandomDate(Random random)
        {
            var start = new DateTime(1991, 1, 1);
            var range = (DateTime.Today - start).Days;
            var end = start.AddDays(random.Next(range)).AddHours(random.Next(0, 24)).AddMinutes(random.Next(0, 60)).AddSeconds(random.Next(0, 60));
            return end;
        }
    }
}
