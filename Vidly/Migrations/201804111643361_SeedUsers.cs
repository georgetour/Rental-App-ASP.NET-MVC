namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2ac14dd7-a957-4543-8f0b-b2c2405175d6', N'guest@vidly.com', 0, N'AEFRxemvAmBAak3vZN49b9rMkJ0TZobNEdh+LrMPWAOmITCUHki9BDSgYVKEufeItQ==', N'3ba7f22f-a566-4903-ab4f-13f372a06f2e', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a14dafcf-9e41-436f-bf29-27b7517905ab', N'storemanager@vidly.com', 0, N'ADMyvV97WPqu5yO5ZYkxfK4oLbJuPP/TYFwyH33UKwUR+a5LLHS8QeSgXDmIzws2GA==', N'9bbb1695-8353-42df-a940-91fe2e1934ee', NULL, 0, 0, NULL, 1, 0, N'storemanager@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'196c07ca-1033-4ce5-bfd9-686e6eb271aa', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a14dafcf-9e41-436f-bf29-27b7517905ab', N'196c07ca-1033-4ce5-bfd9-686e6eb271aa')

");

        }
        
        public override void Down()
        {
        }
    }
}
