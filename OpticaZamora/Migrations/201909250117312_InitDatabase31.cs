namespace OpticaZamora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase31 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Expediente", "Paciente_IdPaciente", "dbo.Paciente");
            DropIndex("dbo.Expediente", new[] { "Paciente_IdPaciente" });
            DropColumn("dbo.Expediente", "PacienteId");
            RenameColumn(table: "dbo.Expediente", name: "Paciente_IdPaciente", newName: "PacienteId");
            AlterColumn("dbo.Expediente", "PacienteId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Expediente", "PacienteId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Expediente", "PacienteId");
            AddForeignKey("dbo.Expediente", "PacienteId", "dbo.Paciente", "IdPaciente", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expediente", "PacienteId", "dbo.Paciente");
            DropIndex("dbo.Expediente", new[] { "PacienteId" });
            AlterColumn("dbo.Expediente", "PacienteId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Expediente", "PacienteId", c => c.String());
            RenameColumn(table: "dbo.Expediente", name: "PacienteId", newName: "Paciente_IdPaciente");
            AddColumn("dbo.Expediente", "PacienteId", c => c.String());
            CreateIndex("dbo.Expediente", "Paciente_IdPaciente");
            AddForeignKey("dbo.Expediente", "Paciente_IdPaciente", "dbo.Paciente", "IdPaciente");
        }
    }
}
