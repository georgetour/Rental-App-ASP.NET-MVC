namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDataGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Name) VALUES " +
                "('Action')," +
                "('Comedy')," +
                "('Drama')," +
                "('Documentary')," +
                "('Thriller')," +
                "('Horror')," +
                "('Romance')," +
                "('Sci-fi')," +
                "('Animation')" );
                
        }
        
        public override void Down()
        {
        }
    }
}
