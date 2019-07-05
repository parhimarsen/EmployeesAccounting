namespace EmployeesAccounting.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class DataInput : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT [dbo].[Departments] ON " +
                 "INSERT INTO[dbo].[Departments]([DepartmentId], [Name], [DateOfAdding], [DateInfoChanging]) VALUES(1, N'Marketing Department', N'04-07-2015', N'04-07-2019') " +
                 "INSERT INTO[dbo].[Departments]([DepartmentId], [Name], [DateOfAdding], [DateInfoChanging]) VALUES(2, N'Advertising Department', N'29-03-2012', N'23-06-2018') " +
                 "INSERT INTO[dbo].[Departments]([DepartmentId], [Name], [DateOfAdding], [DateInfoChanging]) VALUES(3, N'Programmers Department', N'16-11-2013', N'18-01-2019') " +
                 "SET IDENTITY_INSERT [dbo].[Departments] OFF ");

            Sql("SET IDENTITY_INSERT [dbo].[Employees] ON " +
                "INSERT INTO[dbo].[Employees]([EmployeeId], [Name], [DateOfAdding], [DateInfoChanging], [DateOfEmployment], [DepartmentId]) VALUES(1, N'Parhim Arsen Yrich', N'24-04-2015', N'04-07-2019', N'25-04-2015', 1) " +
                "INSERT INTO[dbo].[Employees]([EmployeeId], [Name], [DateOfAdding], [DateInfoChanging], [DateOfEmployment], [DepartmentId]) VALUES(2, N'Mamchur Ales Valerich', N'16-05-2016', N'04-07-2019', N'16-05-2016', 1) " +
                "INSERT INTO[dbo].[Employees]([EmployeeId], [Name], [DateOfAdding], [DateInfoChanging], [DateOfEmployment], [DepartmentId]) VALUES(3, N'Linik Pavel Andreich', N'19-10-2018', N'12-03-2019', N'20-10-2018', 1) " +
                "INSERT INTO[dbo].[Employees]([EmployeeId], [Name], [DateOfAdding], [DateInfoChanging], [DateOfEmployment], [DepartmentId]) VALUES(4, N'Tereshko Mark Valerich', N'14-10-2013', N'11-06-2018', N'20-10-2013', 2) " +
                "INSERT INTO[dbo].[Employees]([EmployeeId], [Name], [DateOfAdding], [DateInfoChanging], [DateOfEmployment], [DepartmentId]) VALUES(5, N'Onishuk Anton Zibabvich', N'21-08-2015', N'02-02-2019', N'23-08-2015', 2) " +
                "INSERT INTO[dbo].[Employees]([EmployeeId], [Name], [DateOfAdding], [DateInfoChanging], [DateOfEmployment], [DepartmentId]) VALUES(6, N'Kurilenko Vlad Dmitrich', N'13-03-2014', N'02-02-2019', N'13-03-2014', 2) " +
                "INSERT INTO[dbo].[Employees]([EmployeeId], [Name], [DateOfAdding], [DateInfoChanging], [DateOfEmployment], [DepartmentId]) VALUES(7, N'Bogdan Anton Igroich', N'16-02-2014', N'05-01-2019', N'17-02-2014', 3) " +
                "INSERT INTO[dbo].[Employees]([EmployeeId], [Name], [DateOfAdding], [DateInfoChanging], [DateOfEmployment], [DepartmentId]) VALUES(8, N'Manchyk Pavel Alexandrich', N'22-11-2013', N'12-11-2018', N'23-11-2013', 3) " +
                "INSERT INTO[dbo].[Employees]([EmployeeId], [Name], [DateOfAdding], [DateInfoChanging], [DateOfEmployment], [DepartmentId]) VALUES(9, N'Kaguro Alex Arsenievich', N'22-11-2013', N'12-11-2018', N'23-11-2013', 3) " +
                "SET IDENTITY_INSERT [dbo].[Employees] OFF ");
        }

        public override void Down()
        {
            Sql("DELETE FROM [dbo].[Employees] WHERE [EmployeeId] = 1");
            Sql("DELETE FROM [dbo].[Employees] WHERE [EmployeeId] = 2");
            Sql("DELETE FROM [dbo].[Employees] WHERE [EmployeeId] = 3");
            Sql("DELETE FROM [dbo].[Employees] WHERE [EmployeeId] = 4");
            Sql("DELETE FROM [dbo].[Employees] WHERE [EmployeeId] = 5");
            Sql("DELETE FROM [dbo].[Employees] WHERE [EmployeeId] = 6");
            Sql("DELETE FROM [dbo].[Employees] WHERE [EmployeeId] = 7");
            Sql("DELETE FROM [dbo].[Employees] WHERE [EmployeeId] = 8");
            Sql("DELETE FROM [dbo].[Employees] WHERE [EmployeeId] = 9");
            Sql("DELETE FROM [dbo].[Departments] WHERE [DepartmentId] = 1");
            Sql("DELETE FROM [dbo].[Departments] WHERE [DepartmentId] = 2");
            Sql("DELETE FROM [dbo].[Departments] WHERE [DepartmentId] = 3");
        }
    }
}
