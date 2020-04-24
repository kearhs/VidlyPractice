namespace Vidly3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoviesToMovieTable : DbMigration
    {
        public override void Up()
        {
            Sql(@" INSERT INTO Movies (Name, GenreId) 
                   VALUES ('Hangover', 2),
                          ('Die Hard', 1),
                          ('The Terminator', 1),
                          ('Toy Story', 3),
                          ('Titanic', 4) ");
        }
        
        public override void Down()
        {
        }
    }
}
