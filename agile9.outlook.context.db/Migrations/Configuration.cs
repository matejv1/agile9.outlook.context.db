namespace agile9.outlook.context.db.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using agile9.outlook.context.db.Models;


    internal sealed class Configuration : DbMigrationsConfiguration<agile9.outlook.context.db.Models.dbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(agile9.outlook.context.db.Models.dbContext context)
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

            context.JobType.AddOrUpdate(x => x.Id,
                new JobType() { Id = 1, Title = "Marketing Manager" },
                new JobType() { Id = 2, Title = "Technical Consultant" },
                new JobType() { Id = 3, Title = "CEO" });

            context.Companies.AddOrUpdate(x => x.Id,
                new Company() { Id = 1, Name = "Apple Inc.", Email = "@apple.com", LogoUrl = "http://www.h3dwallpapers.com/wp-content/uploads/2014/08/Apple_logo-9.gif" },
                new Company() { Id = 2, Name = "Microsoft Inc.", Email = "@microsoft.com", LogoUrl = "http://allthingsd.com/files/2012/08/msft_logo_crop.jpg" },
                new Company() { Id = 3, Name = "Google Inc.", Email = "@google.com", LogoUrl = "data:image/jpeg;base64,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" },
                new Company() { Id = 4, Name = "Yammer Network", Email = "@yammer.com", LogoUrl = "url" });

            context.Person.AddOrUpdate(x => x.Id,
                new Person() { Id = 1, Name = "John", Surname = "Baker", CompanyId = 1, JobTypeId = 1 },
                new Person() { Id = 2, Name = "Arnold", Surname = "Tucker", CompanyId = 2, JobTypeId = 1 },
                new Person() { Id = 3, Name = "Nancy", Surname = "Powell", CompanyId = 3, JobTypeId = 1 },
                new Person() { Id = 4, Name = "Sam", Surname = "Benson", CompanyId = 3, JobTypeId = 1 },
                new Person() { Id = 5, Name = "Carl", Surname = "Chavez", CompanyId = 3, JobTypeId = 1 },
                new Person() { Id = 6, Name = "Lawrence", Surname = "Snyder", CompanyId = 4, JobTypeId = 1 },
                new Person() { Id = 7, Name = "Darlene", Surname = "Johnston", CompanyId = 4, JobTypeId = 1 },
                new Person() { Id = 8, Name = "Ralph", Surname = "Holloway", CompanyId = 4, JobTypeId = 1 },
                new Person() { Id = 9, Name = "Anna", Surname = "Ortega", CompanyId = 4, JobTypeId = 1 },
                new Person() { Id = 10, Name = "Terence", Surname = "Campbell", CompanyId = 4, JobTypeId = 1 });

            context.Reports.AddOrUpdate(x => x.Id,
                new Report() { Id = 1, CompanyId = 1, Year = 2012, Revenues = 1150500, Profit = 220800, ProfitAfterTax = 170000, Expenses = 500000 },
                new Report() { Id = 2, CompanyId = 1, Year = 2013, Revenues = 900500, Profit = 140800, ProfitAfterTax = 120000, Expenses = 190000 },
                new Report() { Id = 3, CompanyId = 1, Year = 2014, Revenues = 1390500, Profit = 240800, ProfitAfterTax = 170200, Expenses = 390000 },
                new Report() { Id = 4, CompanyId = 1, Year = 2015, Revenues = 1590500, Profit = 340800, ProfitAfterTax = 210900, Expenses = 690000 },

                new Report() { Id = 5, CompanyId = 2, Year = 2012, Revenues = 1150500, Profit = 220800, ProfitAfterTax = 170000, Expenses = 500000 },
                new Report() { Id = 6, CompanyId = 2, Year = 2013, Revenues = 900500, Profit = 140800, ProfitAfterTax = 120000, Expenses =  190000 },
                new Report() { Id = 7, CompanyId = 2, Year = 2014, Revenues = 1390500, Profit = 240800, ProfitAfterTax = 170200, Expenses = 390000 },
                new Report() { Id = 8, CompanyId = 2, Year = 2012, Revenues = 1590050, Profit = 340800, ProfitAfterTax = 290200, Expenses = 690000 },

                new Report() { Id = 9, CompanyId = 3, Year = 2013, Revenues = 15900500, Profit = 340800, Expenses = 690000 },
                new Report() { Id = 10, CompanyId = 3, Year = 2014, Revenues = 15900500, Profit = 340800, Expenses = 690000 },
                new Report() { Id = 11, CompanyId = 3, Year = 2015, Revenues = 15900500, Profit = 340800, Expenses = 690000 });



            context.Insurances.AddOrUpdate(x => x.Id,
                new Insurance() { Id = 1, Address = "11 Brook St Mayfair, London W1S 1PY", Name = "Claridge's Inc.", TaxId = "SI231884882" },
                new Insurance() { Id = 2, Address = "38 Maddox St, London W1S 1PY", Name = "Metrobank", TaxId = "SI231884882" });

            context.Clients.AddOrUpdate(x => x.Id,
                new Client() { Id = 1, Address = "Address 1", ClientCompanyName = "", IsCompany = false, ContactNumber = "041 388 999", Name = "Josh", Surname = "Snyder", TaxId = "" },
                new Client() { Id = 2, Address = "Address 2", ClientCompanyName = "HSBC", IsCompany = true, ContactNumber = "041 100 283", Name = "John", Surname = "Johnston", TaxId = "SI2381983" });

            context.Cars.AddOrUpdate(x => x.Id,
                new Car() { Id = 1, Manufacturer = "WV", Model = "Passat 1.9 TDI", Year = 2015 },
                new Car() { Id = 2, Manufacturer = "BMW", Model = "M3", Year = 2013 });

            context.Jobs.AddOrUpdate(x => x.Id,
                new Job()
                {
                    Id = 1,
                    ClientId = 1,
                    CompanyId = 1,
                    CarId = 1,
                    Date = new DateTime(2015, 7, 7),
                    InsuranceId = 1,
                    Tax = 452.6,
                    Total = 2349.99
                },
                new Job()
                {
                    Id = 2,
                    ClientId = 2,
                    CompanyId = 2,
                    CarId = 2,
                    Date = new DateTime(2015, 7, 8),
                    InsuranceId = 2,
                    Tax = 120.6,
                    Total = 849.99
                });
        }
    }
}
