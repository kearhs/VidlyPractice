namespace Vidly3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@" INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0181f26a-4889-49c1-a540-464a760233ba', N'guest@vidly.com', 0, N'AAG4SPsYTgkWNas08Jal1pLeKjv2EMGa2A4Tadj6JQn/OEbR6SRtkUvllRYG30C0Og==', N'a5c77dfc-2d4a-49ca-96e9-dfc4982e6d6c', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                   INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6211fffe-a982-44e1-a6e6-6bad150b879c', N'admin@vidly.com', 0, N'ACVa9kuxbFT8uDrIcpS+96dz66Ema/nXaLKzIeoTNVsFpc1c8eI/jx62ulzD7oob0Q==', N'ae0ca35d-1ae8-475a-96a0-97c2f8e96d10', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com') ");

            Sql(@" INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'09188caa-c46c-42c2-b58f-e81e269ae321', N'CanManageMovies') ");

            Sql(@" INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6211fffe-a982-44e1-a6e6-6bad150b879c', N'09188caa-c46c-42c2-b58f-e81e269ae321') ");
        }
        
        public override void Down()
        {
        }
    }
}
