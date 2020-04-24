namespace Vidly3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMovieDateWithDates : DbMigration
    {
        public override void Up()
        {
            Sql(@" UPDATE Movies
                   SET ReleaseDate = '2009-11-06',
                       DateAdded = '2016-05-04',
                       NumberOfStock = 5
                   WHERE Id = 1 ");

            Sql(@" UPDATE Movies
                   SET ReleaseDate = '2010-12-01',
                       DateAdded = '2018-01-01',
                       NumberOfStock = 3
                   WHERE Id = 2 ");

            Sql(@" UPDATE Movies
                   SET ReleaseDate = '2003-11-14',
                       DateAdded = '2008-10-11',
                       NumberOfStock = 6
                   WHERE Id = 3 ");

            Sql(@" UPDATE Movies
                   SET ReleaseDate = '2011-02-28',
                       DateAdded = '2012-01-31',
                       NumberOfStock = 2
                   WHERE Id = 4 ");

            Sql(@" UPDATE Movies
                   SET ReleaseDate = '2012-12-14',
                       DateAdded = '2013-06-30',
                       NumberOfStock = 3
                   WHERE Id = 5 ");
        }
        
        public override void Down()
        {
        }
    }
}
