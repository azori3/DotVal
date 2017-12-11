namespace Volunteer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "pidev.action",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        adresseMapAction = c.String(maxLength: 255, storeType: "nvarchar"),
                        dateDebutAction = c.DateTime(precision: 0),
                        dateFinAction = c.DateTime(precision: 0),
                        discriptionAction = c.String(maxLength: 255, storeType: "nvarchar"),
                        imageAction = c.String(maxLength: 255, storeType: "nvarchar"),
                        titreAction = c.String(maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "pidev.rating",
                c => new
                    {
                        idAction = c.Int(nullable: false),
                        idUser = c.Int(nullable: false),
                        description = c.String(maxLength: 255, storeType: "nvarchar"),
                        nbEtoile = c.Int(nullable: false),
                        action_id = c.Int(),
                        users_id = c.Int(),
                    })
                .PrimaryKey(t => new { t.idAction, t.idUser })
                .ForeignKey("pidev.action", t => t.action_id)
                .ForeignKey("pidev.users", t => t.users_id)
                .Index(t => t.action_id)
                .Index(t => t.users_id);
            
            CreateTable(
                "pidev.users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        firstName = c.String(maxLength: 255, storeType: "nvarchar"),
                        idUser = c.Int(),
                        lastName = c.String(maxLength: 255, storeType: "nvarchar"),
                        mail = c.String(maxLength: 255, storeType: "nvarchar"),
                        signalisation_id = c.Int(),
                        signalisation_id1 = c.Int(),
                        signalisation1_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("pidev.signalisation", t => t.signalisation_id1)
                .ForeignKey("pidev.signalisation", t => t.signalisation1_id)
                .Index(t => t.signalisation_id1)
                .Index(t => t.signalisation1_id);
            
            CreateTable(
                "pidev.category",
                c => new
                    {
                        idCategory = c.Int(nullable: false, identity: true),
                        contentCat = c.String(maxLength: 255, storeType: "nvarchar"),
                        users_id = c.Int(),
                        users_id1 = c.Int(),
                    })
                .PrimaryKey(t => t.idCategory)
                .ForeignKey("pidev.users", t => t.users_id1)
                .Index(t => t.users_id1);
            
            CreateTable(
                "pidev.comment",
                c => new
                    {
                        idComment = c.Int(nullable: false, identity: true),
                        content = c.String(maxLength: 255, storeType: "nvarchar"),
                        dateComment = c.DateTime(precision: 0),
                        users_id = c.Int(),
                        users_id1 = c.Int(),
                    })
                .PrimaryKey(t => t.idComment)
                .ForeignKey("pidev.users", t => t.users_id1)
                .Index(t => t.users_id1);
            
            CreateTable(
                "pidev.job",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        adresseJob = c.String(maxLength: 255, storeType: "nvarchar"),
                        contacter = c.String(maxLength: 255, storeType: "nvarchar"),
                        contenutJob = c.String(maxLength: 255, storeType: "nvarchar"),
                        dateDebJob = c.DateTime(precision: 0),
                        dureJob = c.String(maxLength: 255, storeType: "nvarchar"),
                        finDePublication = c.DateTime(precision: 0),
                        indexationJob = c.String(maxLength: 255, storeType: "nvarchar"),
                        infosCompl = c.String(maxLength: 255, storeType: "nvarchar"),
                        nbrPOste = c.Int(nullable: false),
                        profil = c.String(maxLength: 255, storeType: "nvarchar"),
                        recevoirCv = c.String(maxLength: 255, storeType: "nvarchar"),
                        servActivite = c.Int(),
                        titre = c.String(maxLength: 255, storeType: "nvarchar"),
                        typeContrat = c.Int(),
                        users_id = c.Int(),
                        emailJob = c.String(maxLength: 255, storeType: "nvarchar"),
                        duréeJob = c.String(maxLength: 255, storeType: "nvarchar"),
                        users_id1 = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("pidev.users", t => t.users_id1)
                .Index(t => t.users_id1);
            
            CreateTable(
                "pidev.signalisation",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        contenu = c.String(maxLength: 255, storeType: "nvarchar"),
                        email = c.String(maxLength: 255, storeType: "nvarchar"),
                        job_id = c.Int(),
                        users_id = c.Int(),
                        job_id1 = c.Int(),
                        users_id1 = c.Int(),
                        users_id2 = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("pidev.job", t => t.job_id1)
                .ForeignKey("pidev.users", t => t.users_id1)
                .ForeignKey("pidev.users", t => t.users_id2)
                .Index(t => t.job_id1)
                .Index(t => t.users_id1)
                .Index(t => t.users_id2);
            
            CreateTable(
                "pidev.message",
                c => new
                    {
                        idMessage = c.Int(nullable: false, identity: true),
                        content = c.String(maxLength: 255, storeType: "nvarchar"),
                        date = c.DateTime(precision: 0),
                        topic_id = c.Int(),
                        users_id = c.Int(),
                        topic_id1 = c.Int(),
                        users_id1 = c.Int(),
                    })
                .PrimaryKey(t => t.idMessage)
                .ForeignKey("pidev.topic", t => t.topic_id1)
                .ForeignKey("pidev.users", t => t.users_id1)
                .Index(t => t.topic_id1)
                .Index(t => t.users_id1);
            
            CreateTable(
                "pidev.topic",
                c => new
                    {
                        id = c.Int(nullable: false),
                        title = c.String(maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "pidev.donation",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        TitreDonation = c.String(maxLength: 255, storeType: "nvarchar"),
                        TypeDonation = c.String(maxLength: 255, storeType: "nvarchar"),
                        lieuDonation = c.String(maxLength: 255, storeType: "nvarchar"),
                        image = c.String(maxLength: 255, storeType: "nvarchar"),
                        email = c.String(maxLength: 255, storeType: "nvarchar"),
                        dateajout = c.DateTime(precision: 0),
                        disponibilite = c.String(maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.usersactions",
                c => new
                    {
                        users_id = c.Int(nullable: false),
                        action_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.users_id, t.action_id })
                .ForeignKey("pidev.users", t => t.users_id, cascadeDelete: true)
                .ForeignKey("pidev.action", t => t.action_id, cascadeDelete: true)
                .Index(t => t.users_id)
                .Index(t => t.action_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("pidev.users", "signalisation1_id", "pidev.signalisation");
            DropForeignKey("pidev.signalisation", "users_id2", "pidev.users");
            DropForeignKey("pidev.rating", "users_id", "pidev.users");
            DropForeignKey("pidev.message", "users_id1", "pidev.users");
            DropForeignKey("pidev.message", "topic_id1", "pidev.topic");
            DropForeignKey("pidev.job", "users_id1", "pidev.users");
            DropForeignKey("pidev.users", "signalisation_id1", "pidev.signalisation");
            DropForeignKey("pidev.signalisation", "users_id1", "pidev.users");
            DropForeignKey("pidev.signalisation", "job_id1", "pidev.job");
            DropForeignKey("pidev.comment", "users_id1", "pidev.users");
            DropForeignKey("pidev.category", "users_id1", "pidev.users");
            DropForeignKey("dbo.usersactions", "action_id", "pidev.action");
            DropForeignKey("dbo.usersactions", "users_id", "pidev.users");
            DropForeignKey("pidev.rating", "action_id", "pidev.action");
            DropIndex("dbo.usersactions", new[] { "action_id" });
            DropIndex("dbo.usersactions", new[] { "users_id" });
            DropIndex("pidev.message", new[] { "users_id1" });
            DropIndex("pidev.message", new[] { "topic_id1" });
            DropIndex("pidev.signalisation", new[] { "users_id2" });
            DropIndex("pidev.signalisation", new[] { "users_id1" });
            DropIndex("pidev.signalisation", new[] { "job_id1" });
            DropIndex("pidev.job", new[] { "users_id1" });
            DropIndex("pidev.comment", new[] { "users_id1" });
            DropIndex("pidev.category", new[] { "users_id1" });
            DropIndex("pidev.users", new[] { "signalisation1_id" });
            DropIndex("pidev.users", new[] { "signalisation_id1" });
            DropIndex("pidev.rating", new[] { "users_id" });
            DropIndex("pidev.rating", new[] { "action_id" });
            DropTable("dbo.usersactions");
            DropTable("pidev.donation");
            DropTable("pidev.topic");
            DropTable("pidev.message");
            DropTable("pidev.signalisation");
            DropTable("pidev.job");
            DropTable("pidev.comment");
            DropTable("pidev.category");
            DropTable("pidev.users");
            DropTable("pidev.rating");
            DropTable("pidev.action");
        }
    }
}
