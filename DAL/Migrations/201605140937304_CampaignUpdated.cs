namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CampaignUpdated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Article",
                c => new
                    {
                        ArticleId = c.Int(nullable: false, identity: true),
                        ArticleName = c.String(maxLength: 255),
                        ArticleHeadlineId = c.Int(nullable: false),
                        ArticleBodyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArticleId)
                .ForeignKey("dbo.MultiLangString", t => t.ArticleBodyId)
                .ForeignKey("dbo.MultiLangString", t => t.ArticleHeadlineId)
                .Index(t => t.ArticleHeadlineId)
                .Index(t => t.ArticleBodyId);
            
            CreateTable(
                "dbo.MultiLangString",
                c => new
                    {
                        MultiLangStringId = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        Owner = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.MultiLangStringId);
            
            CreateTable(
                "dbo.Translation",
                c => new
                    {
                        TranslationId = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        MultiLangStringId = c.Int(nullable: false),
                        Culture = c.String(maxLength: 12),
                    })
                .PrimaryKey(t => t.TranslationId)
                .ForeignKey("dbo.MultiLangString", t => t.MultiLangStringId)
                .Index(t => t.MultiLangStringId);
            
            CreateTable(
                "dbo.Campaign",
                c => new
                    {
                        CampaignId = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 2048),
                        Percentage = c.Double(nullable: false),
                        From = c.String(nullable: false, maxLength: 32),
                        Until = c.String(nullable: false, maxLength: 32),
                    })
                .PrimaryKey(t => t.CampaignId);
            
            CreateTable(
                "dbo.Contract",
                c => new
                    {
                        ContractId = c.Int(nullable: false, identity: true),
                        CampaignId = c.Int(),
                        Content = c.String(),
                        Title = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ContractId)
                .ForeignKey("dbo.Campaign", t => t.CampaignId)
                .Index(t => t.CampaignId);
            
            CreateTable(
                "dbo.DealInContract",
                c => new
                    {
                        DealInContractId = c.Int(nullable: false, identity: true),
                        DealId = c.Int(),
                        ContractId = c.Int(),
                    })
                .PrimaryKey(t => t.DealInContractId)
                .ForeignKey("dbo.Contract", t => t.ContractId)
                .ForeignKey("dbo.Deal", t => t.DealId)
                .Index(t => t.DealId)
                .Index(t => t.ContractId);
            
            CreateTable(
                "dbo.Deal",
                c => new
                    {
                        DealId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        From = c.String(maxLength: 32),
                        Until = c.String(maxLength: 32),
                        DealDone = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DealId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.DealInCampaign",
                c => new
                    {
                        DealInCampaignId = c.Int(nullable: false, identity: true),
                        DealId = c.Int(),
                        Deal = c.Int(nullable: false),
                        CampaignId = c.Int(),
                        Campaign = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DealInCampaignId)
                .ForeignKey("dbo.Deal", t => t.DealId)
                .ForeignKey("dbo.Campaign", t => t.CampaignId)
                .Index(t => t.DealId)
                .Index(t => t.CampaignId);
            
            CreateTable(
                "dbo.PersonInDeal",
                c => new
                    {
                        PersonInDealId = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(),
                        DealId = c.Int(),
                        Date = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.PersonInDealId)
                .ForeignKey("dbo.Deal", t => t.DealId)
                .ForeignKey("dbo.Person", t => t.PersonId)
                .Index(t => t.PersonId)
                .Index(t => t.DealId);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 128),
                        LastName = c.String(nullable: false, maxLength: 128),
                        Registered = c.DateTime(nullable: false, storeType: "date"),
                        Sex = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 50),
                        Password = c.String(maxLength: 32),
                        TelNr = c.String(maxLength: 20),
                        BankNr = c.String(maxLength: 64),
                        Locked = c.Boolean(nullable: false),
                        Money = c.Double(nullable: false),
                        Invited = c.Int(nullable: false),
                        Raiting = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.UserInt", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PersonInChat",
                c => new
                    {
                        PersonInChatId = c.Int(nullable: false, identity: true),
                        ChatId = c.Int(),
                        PersonId = c.Int(),
                        Time = c.String(),
                    })
                .PrimaryKey(t => t.PersonInChatId)
                .ForeignKey("dbo.Chat", t => t.ChatId)
                .ForeignKey("dbo.Person", t => t.PersonId)
                .Index(t => t.ChatId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Chat",
                c => new
                    {
                        ChatId = c.Int(nullable: false, identity: true),
                        Message = c.String(maxLength: 255),
                        DateTime = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.ChatId);
            
            CreateTable(
                "dbo.ChatInPretension",
                c => new
                    {
                        ChatInPretensionId = c.Int(nullable: false, identity: true),
                        ChatId = c.Int(),
                        PretensionId = c.Int(),
                    })
                .PrimaryKey(t => t.ChatInPretensionId)
                .ForeignKey("dbo.Chat", t => t.ChatId)
                .ForeignKey("dbo.Pretension", t => t.PretensionId)
                .Index(t => t.ChatId)
                .Index(t => t.PretensionId);
            
            CreateTable(
                "dbo.Pretension",
                c => new
                    {
                        PretensionId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Content = c.String(maxLength: 255),
                        Title = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.PretensionId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.PersonInPretension",
                c => new
                    {
                        PersonInPretensionId = c.Int(nullable: false, identity: true),
                        PretensionId = c.Int(),
                        PersonId = c.Int(),
                        From = c.String(maxLength: 32),
                        Until = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.PersonInPretensionId)
                .ForeignKey("dbo.Person", t => t.PersonId)
                .ForeignKey("dbo.Pretension", t => t.PretensionId)
                .Index(t => t.PretensionId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        Title = c.String(maxLength: 128),
                        Content = c.String(maxLength: 1024),
                        Price = c.Double(nullable: false),
                        TrackingCode = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Person", t => t.PersonId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Description",
                c => new
                    {
                        DescriptionId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Content = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.DescriptionId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Picture",
                c => new
                    {
                        PictureId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Location = c.String(maxLength: 255),
                        Description = c.String(maxLength: 255),
                        Title = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.PictureId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.PersonInContract",
                c => new
                    {
                        PersonInContractId = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(),
                        ContractId = c.Int(),
                        From = c.String(maxLength: 32),
                        Until = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.PersonInContractId)
                .ForeignKey("dbo.Contract", t => t.ContractId)
                .ForeignKey("dbo.Person", t => t.PersonId)
                .Index(t => t.PersonId)
                .Index(t => t.ContractId);
            
            CreateTable(
                "dbo.UserInt",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 7, storeType: "datetime2"),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        FirstName = c.String(maxLength: 128),
                        LastName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.UserClaimInt",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserInt", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserLoginInt",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.UserInt", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserRoleInt",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.RoleInt", t => t.RoleId)
                .ForeignKey("dbo.UserInt", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.RoleInt",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        ContactValue = c.String(nullable: false, maxLength: 128),
                        PersonId = c.Int(nullable: false),
                        ContactTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContactId)
                .ForeignKey("dbo.ContactType", t => t.ContactTypeId)
                .ForeignKey("dbo.Person", t => t.PersonId)
                .Index(t => t.PersonId)
                .Index(t => t.ContactTypeId);
            
            CreateTable(
                "dbo.ContactType",
                c => new
                    {
                        ContactTypeId = c.Int(nullable: false, identity: true),
                        ContactTypeNameId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContactTypeId)
                .ForeignKey("dbo.MultiLangString", t => t.ContactTypeNameId)
                .Index(t => t.ContactTypeNameId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contact", "PersonId", "dbo.Person");
            DropForeignKey("dbo.ContactType", "ContactTypeNameId", "dbo.MultiLangString");
            DropForeignKey("dbo.Contact", "ContactTypeId", "dbo.ContactType");
            DropForeignKey("dbo.DealInCampaign", "CampaignId", "dbo.Campaign");
            DropForeignKey("dbo.Person", "UserId", "dbo.UserInt");
            DropForeignKey("dbo.UserRoleInt", "UserId", "dbo.UserInt");
            DropForeignKey("dbo.UserRoleInt", "RoleId", "dbo.RoleInt");
            DropForeignKey("dbo.UserLoginInt", "UserId", "dbo.UserInt");
            DropForeignKey("dbo.UserClaimInt", "UserId", "dbo.UserInt");
            DropForeignKey("dbo.PersonInDeal", "PersonId", "dbo.Person");
            DropForeignKey("dbo.PersonInContract", "PersonId", "dbo.Person");
            DropForeignKey("dbo.PersonInContract", "ContractId", "dbo.Contract");
            DropForeignKey("dbo.PersonInChat", "PersonId", "dbo.Person");
            DropForeignKey("dbo.PersonInChat", "ChatId", "dbo.Chat");
            DropForeignKey("dbo.Pretension", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Picture", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Product", "PersonId", "dbo.Person");
            DropForeignKey("dbo.Description", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Deal", "ProductId", "dbo.Product");
            DropForeignKey("dbo.PersonInPretension", "PretensionId", "dbo.Pretension");
            DropForeignKey("dbo.PersonInPretension", "PersonId", "dbo.Person");
            DropForeignKey("dbo.ChatInPretension", "PretensionId", "dbo.Pretension");
            DropForeignKey("dbo.ChatInPretension", "ChatId", "dbo.Chat");
            DropForeignKey("dbo.PersonInDeal", "DealId", "dbo.Deal");
            DropForeignKey("dbo.DealInContract", "DealId", "dbo.Deal");
            DropForeignKey("dbo.DealInCampaign", "DealId", "dbo.Deal");
            DropForeignKey("dbo.DealInContract", "ContractId", "dbo.Contract");
            DropForeignKey("dbo.Contract", "CampaignId", "dbo.Campaign");
            DropForeignKey("dbo.Article", "ArticleHeadlineId", "dbo.MultiLangString");
            DropForeignKey("dbo.Article", "ArticleBodyId", "dbo.MultiLangString");
            DropForeignKey("dbo.Translation", "MultiLangStringId", "dbo.MultiLangString");
            DropIndex("dbo.ContactType", new[] { "ContactTypeNameId" });
            DropIndex("dbo.Contact", new[] { "ContactTypeId" });
            DropIndex("dbo.Contact", new[] { "PersonId" });
            DropIndex("dbo.RoleInt", "RoleNameIndex");
            DropIndex("dbo.UserRoleInt", new[] { "RoleId" });
            DropIndex("dbo.UserRoleInt", new[] { "UserId" });
            DropIndex("dbo.UserLoginInt", new[] { "UserId" });
            DropIndex("dbo.UserClaimInt", new[] { "UserId" });
            DropIndex("dbo.UserInt", "UserNameIndex");
            DropIndex("dbo.PersonInContract", new[] { "ContractId" });
            DropIndex("dbo.PersonInContract", new[] { "PersonId" });
            DropIndex("dbo.Picture", new[] { "ProductId" });
            DropIndex("dbo.Description", new[] { "ProductId" });
            DropIndex("dbo.Product", new[] { "PersonId" });
            DropIndex("dbo.PersonInPretension", new[] { "PersonId" });
            DropIndex("dbo.PersonInPretension", new[] { "PretensionId" });
            DropIndex("dbo.Pretension", new[] { "ProductId" });
            DropIndex("dbo.ChatInPretension", new[] { "PretensionId" });
            DropIndex("dbo.ChatInPretension", new[] { "ChatId" });
            DropIndex("dbo.PersonInChat", new[] { "PersonId" });
            DropIndex("dbo.PersonInChat", new[] { "ChatId" });
            DropIndex("dbo.Person", new[] { "UserId" });
            DropIndex("dbo.PersonInDeal", new[] { "DealId" });
            DropIndex("dbo.PersonInDeal", new[] { "PersonId" });
            DropIndex("dbo.DealInCampaign", new[] { "CampaignId" });
            DropIndex("dbo.DealInCampaign", new[] { "DealId" });
            DropIndex("dbo.Deal", new[] { "ProductId" });
            DropIndex("dbo.DealInContract", new[] { "ContractId" });
            DropIndex("dbo.DealInContract", new[] { "DealId" });
            DropIndex("dbo.Contract", new[] { "CampaignId" });
            DropIndex("dbo.Translation", new[] { "MultiLangStringId" });
            DropIndex("dbo.Article", new[] { "ArticleBodyId" });
            DropIndex("dbo.Article", new[] { "ArticleHeadlineId" });
            DropTable("dbo.ContactType");
            DropTable("dbo.Contact");
            DropTable("dbo.RoleInt");
            DropTable("dbo.UserRoleInt");
            DropTable("dbo.UserLoginInt");
            DropTable("dbo.UserClaimInt");
            DropTable("dbo.UserInt");
            DropTable("dbo.PersonInContract");
            DropTable("dbo.Picture");
            DropTable("dbo.Description");
            DropTable("dbo.Product");
            DropTable("dbo.PersonInPretension");
            DropTable("dbo.Pretension");
            DropTable("dbo.ChatInPretension");
            DropTable("dbo.Chat");
            DropTable("dbo.PersonInChat");
            DropTable("dbo.Person");
            DropTable("dbo.PersonInDeal");
            DropTable("dbo.DealInCampaign");
            DropTable("dbo.Deal");
            DropTable("dbo.DealInContract");
            DropTable("dbo.Contract");
            DropTable("dbo.Campaign");
            DropTable("dbo.Translation");
            DropTable("dbo.MultiLangString");
            DropTable("dbo.Article");
        }
    }
}
