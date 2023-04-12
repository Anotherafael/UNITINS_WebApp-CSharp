namespace a1_hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EntryDate = c.DateTime(nullable: false),
                        DepartureDate = c.DateTime(nullable: false),
                        Guests = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        ClientID = c.Int(nullable: false),
                        RoomID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clients", t => t.ClientID, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomID, cascadeDelete: true)
                .Index(t => t.ClientID)
                .Index(t => t.RoomID);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Cpf = c.String(nullable: false, maxLength: 14),
                        Email = c.String(nullable: false, maxLength: 120),
                        PhoneNumber = c.String(nullable: false, maxLength: 13),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Cpf, unique: true)
                .Index(t => t.Email, unique: true)
                .Index(t => t.PhoneNumber, unique: true);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Price_per_night = c.Double(nullable: false),
                        Available = c.Boolean(nullable: false),
                        RoomTypeID = c.Int(nullable: false),
                        BranchID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Branches", t => t.BranchID, cascadeDelete: true)
                .ForeignKey("dbo.RoomTypes", t => t.RoomTypeID, cascadeDelete: true)
                .Index(t => t.RoomTypeID)
                .Index(t => t.BranchID);
            
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 80),
                        Email = c.String(maxLength: 100),
                        Address = c.String(maxLength: 100),
                        PhoneNumber = c.String(maxLength: 13),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Email, unique: true)
                .Index(t => t.PhoneNumber, unique: true);
            
            CreateTable(
                "dbo.RoomTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        PaymentDate = c.DateTime(),
                        BookingID = c.Int(nullable: false),
                        PaymentStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Bookings", t => t.BookingID, cascadeDelete: true)
                .Index(t => t.BookingID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "BookingID", "dbo.Bookings");
            DropForeignKey("dbo.Rooms", "RoomTypeID", "dbo.RoomTypes");
            DropForeignKey("dbo.Rooms", "BranchID", "dbo.Branches");
            DropForeignKey("dbo.Bookings", "RoomID", "dbo.Rooms");
            DropForeignKey("dbo.Bookings", "ClientID", "dbo.Clients");
            DropIndex("dbo.Payments", new[] { "BookingID" });
            DropIndex("dbo.Branches", new[] { "PhoneNumber" });
            DropIndex("dbo.Branches", new[] { "Email" });
            DropIndex("dbo.Rooms", new[] { "BranchID" });
            DropIndex("dbo.Rooms", new[] { "RoomTypeID" });
            DropIndex("dbo.Clients", new[] { "PhoneNumber" });
            DropIndex("dbo.Clients", new[] { "Email" });
            DropIndex("dbo.Clients", new[] { "Cpf" });
            DropIndex("dbo.Bookings", new[] { "RoomID" });
            DropIndex("dbo.Bookings", new[] { "ClientID" });
            DropTable("dbo.Payments");
            DropTable("dbo.RoomTypes");
            DropTable("dbo.Branches");
            DropTable("dbo.Rooms");
            DropTable("dbo.Clients");
            DropTable("dbo.Bookings");
        }
    }
}
