namespace eVoting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostID = c.Int(nullable: false, identity: true),
                        PostName = c.String(),
                    })
                .PrimaryKey(t => t.PostID);
            
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        ParticipantID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Vote = c.Int(nullable: false),
                        PostID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ParticipantID)
                .ForeignKey("dbo.Posts", t => t.PostID, cascadeDelete: true)
                .Index(t => t.PostID);
            
            CreateTable(
                "dbo.Voters",
                c => new
                    {
                        VoterID = c.Int(nullable: false, identity: true),
                        MatricNumber = c.String(),
                        Password = c.String(),
                        Voted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.VoterID);
            
            CreateTable(
                "dbo.Electorates",
                c => new
                    {
                        ElectorateID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Passw0rd = c.String(),
                    })
                .PrimaryKey(t => t.ElectorateID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Participants", new[] { "PostID" });
            DropForeignKey("dbo.Participants", "PostID", "dbo.Posts");
            DropTable("dbo.Electorates");
            DropTable("dbo.Voters");
            DropTable("dbo.Participants");
            DropTable("dbo.Posts");
        }
    }
}
