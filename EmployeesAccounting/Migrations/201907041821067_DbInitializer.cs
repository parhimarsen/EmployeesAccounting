namespace EmployeesAccounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbInitializer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DateOfAdding = c.String(nullable: false),
                        DateInfoChanging = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId)
                .Index(t => t.DepartmentId, unique: true);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DateOfAdding = c.String(nullable: false),
                        DateInfoChanging = c.String(nullable: false),
                        DateOfEmployment = c.String(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.EmployeeId, unique: true)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            DropIndex("dbo.Employees", new[] { "EmployeeId" });
            DropIndex("dbo.Departments", new[] { "DepartmentId" });
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
