namespace agile9.outlook.context.db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Manufacturer = c.String(),
                        Model = c.String(),
                        Year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Address = c.String(),
                        ClientCompanyName = c.String(),
                        IsCompany = c.Boolean(nullable: false),
                        TaxId = c.String(),
                        ContactNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(),
                        LogoUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        JobTypeId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.JobTypes", t => t.JobTypeId, cascadeDelete: true)
                .Index(t => t.CompanyId)
                .Index(t => t.JobTypeId);
            
            CreateTable(
                "dbo.JobTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Insurances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TaxId = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Total = c.Double(nullable: false),
                        Tax = c.Double(nullable: false),
                        BillNumber = c.String(),
                        CompanyId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        CarId = c.Int(nullable: false),
                        InsuranceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Insurances", t => t.InsuranceId, cascadeDelete: true)
                .Index(t => t.CarId)
                .Index(t => t.ClientId)
                .Index(t => t.CompanyId)
                .Index(t => t.InsuranceId);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Year = c.Int(nullable: false),
                        Revenues = c.Double(nullable: false),
                        Expenses = c.Double(nullable: false),
                        Profit = c.Double(nullable: false),
                        ProfitAfterTax = c.Double(nullable: false),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reports", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Jobs", "InsuranceId", "dbo.Insurances");
            DropForeignKey("dbo.Jobs", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Jobs", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Jobs", "CarId", "dbo.Cars");
            DropForeignKey("dbo.People", "JobTypeId", "dbo.JobTypes");
            DropForeignKey("dbo.People", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Reports", new[] { "CompanyId" });
            DropIndex("dbo.Jobs", new[] { "InsuranceId" });
            DropIndex("dbo.Jobs", new[] { "CompanyId" });
            DropIndex("dbo.Jobs", new[] { "ClientId" });
            DropIndex("dbo.Jobs", new[] { "CarId" });
            DropIndex("dbo.People", new[] { "JobTypeId" });
            DropIndex("dbo.People", new[] { "CompanyId" });
            DropTable("dbo.Reports");
            DropTable("dbo.Jobs");
            DropTable("dbo.Insurances");
            DropTable("dbo.JobTypes");
            DropTable("dbo.People");
            DropTable("dbo.Companies");
            DropTable("dbo.Clients");
            DropTable("dbo.Cars");
        }
    }
}
