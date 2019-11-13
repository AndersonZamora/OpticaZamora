namespace OpticaZamora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase21 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Expediente", "PacienteId", "dbo.Doctor");
            DropForeignKey("dbo.Expediente", "PacienteId", "dbo.Paciente");
            DropIndex("dbo.Expediente", new[] { "PacienteId" });
            AddColumn("dbo.Expediente", "Doctor_IdDoctor", c => c.String(maxLength: 128));
            AddColumn("dbo.Expediente", "Paciente_IdPaciente", c => c.String(maxLength: 128));
            AlterColumn("dbo.Expediente", "PacienteId", c => c.String());
            CreateIndex("dbo.Expediente", "Doctor_IdDoctor");
            CreateIndex("dbo.Expediente", "Paciente_IdPaciente");
            AddForeignKey("dbo.Expediente", "Doctor_IdDoctor", "dbo.Doctor", "IdDoctor");
            AddForeignKey("dbo.Expediente", "Paciente_IdPaciente", "dbo.Paciente", "IdPaciente");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expediente", "Paciente_IdPaciente", "dbo.Paciente");
            DropForeignKey("dbo.Expediente", "Doctor_IdDoctor", "dbo.Doctor");
            DropIndex("dbo.Expediente", new[] { "Paciente_IdPaciente" });
            DropIndex("dbo.Expediente", new[] { "Doctor_IdDoctor" });
            AlterColumn("dbo.Expediente", "PacienteId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Expediente", "Paciente_IdPaciente");
            DropColumn("dbo.Expediente", "Doctor_IdDoctor");
            CreateIndex("dbo.Expediente", "PacienteId");
            AddForeignKey("dbo.Expediente", "PacienteId", "dbo.Paciente", "IdPaciente", cascadeDelete: true);
            AddForeignKey("dbo.Expediente", "PacienteId", "dbo.Doctor", "IdDoctor", cascadeDelete: true);
        }
    }
}
