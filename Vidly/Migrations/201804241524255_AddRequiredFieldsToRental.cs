namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredFieldsToRental : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rentals", "customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Rentals", "movie_Id", "dbo.Movies");
            DropIndex("dbo.Rentals", new[] { "customer_Id" });
            DropIndex("dbo.Rentals", new[] { "movie_Id" });
            AlterColumn("dbo.Rentals", "customer_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Rentals", "movie_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Rentals", "customer_Id");
            CreateIndex("dbo.Rentals", "movie_Id");
            AddForeignKey("dbo.Rentals", "customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Rentals", "movie_Id", "dbo.Movies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Rentals", "customer_Id", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "movie_Id" });
            DropIndex("dbo.Rentals", new[] { "customer_Id" });
            AlterColumn("dbo.Rentals", "movie_Id", c => c.Int());
            AlterColumn("dbo.Rentals", "customer_Id", c => c.Int());
            CreateIndex("dbo.Rentals", "movie_Id");
            CreateIndex("dbo.Rentals", "customer_Id");
            AddForeignKey("dbo.Rentals", "movie_Id", "dbo.Movies", "Id");
            AddForeignKey("dbo.Rentals", "customer_Id", "dbo.Customers", "Id");
        }
    }
}
