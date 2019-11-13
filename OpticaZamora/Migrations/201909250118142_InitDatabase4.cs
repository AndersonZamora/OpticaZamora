namespace OpticaZamora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Expediente", "Doctor_IdDoctor", "dbo.Doctor");
            DropIndex("dbo.Expediente", new[] { "Doctor_IdDoctor" });
            DropColumn("dbo.Expediente", "DoctorId");
            RenameColumn(table: "dbo.Expediente", name: "Doctor_IdDoctor", newName: "DoctorId");
            AlterColumn("dbo.Expediente", "DoctorId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Expediente", "DoctorId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Expediente", "DoctorId");
            AddForeignKey("dbo.Expediente", "DoctorId", "dbo.Doctor", "IdDoctor", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expediente", "DoctorId", "dbo.Doctor");
            DropIndex("dbo.Expediente", new[] { "DoctorId" });
            AlterColumn("dbo.Expediente", "DoctorId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Expediente", "DoctorId", c => c.String());
            RenameColumn(table: "dbo.Expediente", name: "DoctorId", newName: "Doctor_IdDoctor");
            AddColumn("dbo.Expediente", "DoctorId", c => c.String());
            CreateIndex("dbo.Expediente", "Doctor_IdDoctor");
            AddForeignKey("dbo.Expediente", "Doctor_IdDoctor", "dbo.Doctor", "IdDoctor");
        }
    }
}
