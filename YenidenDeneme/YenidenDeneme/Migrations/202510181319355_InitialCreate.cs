namespace YenidenDeneme.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gelirs",
                c => new
                    {
                        GelirID = c.Int(nullable: false, identity: true),
                        GelirMiktari = c.Int(nullable: false),
                        GelirTuruID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GelirID)
                .ForeignKey("dbo.GelirTurus", t => t.GelirTuruID, cascadeDelete: true)
                .Index(t => t.GelirTuruID);
            
            CreateTable(
                "dbo.GelirTurus",
                c => new
                    {
                        GelirTuruID = c.Int(nullable: false, identity: true),
                        Tur = c.String(),
                    })
                .PrimaryKey(t => t.GelirTuruID);
            
            CreateTable(
                "dbo.Giders",
                c => new
                    {
                        GiderID = c.Int(nullable: false, identity: true),
                        GiderMiktari = c.Int(nullable: false),
                        GiderTuruID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GiderID)
                .ForeignKey("dbo.GiderTurus", t => t.GiderTuruID, cascadeDelete: true)
                .Index(t => t.GiderTuruID);
            
            CreateTable(
                "dbo.GiderTurus",
                c => new
                    {
                        GiderTuruID = c.Int(nullable: false, identity: true),
                        Tur = c.String(),
                    })
                .PrimaryKey(t => t.GiderTuruID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Giders", "GiderTuruID", "dbo.GiderTurus");
            DropForeignKey("dbo.Gelirs", "GelirTuruID", "dbo.GelirTurus");
            DropIndex("dbo.Giders", new[] { "GiderTuruID" });
            DropIndex("dbo.Gelirs", new[] { "GelirTuruID" });
            DropTable("dbo.GiderTurus");
            DropTable("dbo.Giders");
            DropTable("dbo.GelirTurus");
            DropTable("dbo.Gelirs");
        }
    }
}
