namespace OpticaZamora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class venta1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Venta", "ExpedienteId", "dbo.Expediente");
            DropIndex("dbo.Venta", new[] { "ExpedienteId" });
            AddColumn("dbo.Venta", "PacienteId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Venta", "Nombre", c => c.String());
            AddColumn("dbo.Venta", "Apellidos", c => c.String());
            AddColumn("dbo.Venta", "DNI", c => c.String());
            CreateIndex("dbo.Venta", "PacienteId");
            AddForeignKey("dbo.Venta", "PacienteId", "dbo.Paciente", "IdPaciente", cascadeDelete: true);
            DropColumn("dbo.Venta", "ExpedienteId");
            DropColumn("dbo.Venta", "CodigoExpediente");
            DropColumn("dbo.Venta", "NombrePacienteExpediente");
            DropColumn("dbo.Venta", "ApellidoPacienteExpediente");
            DropColumn("dbo.Venta", "DNIPacienteExpediente");
            DropColumn("dbo.Venta", "Deposito");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Venta", "Deposito", c => c.String());
            AddColumn("dbo.Venta", "DNIPacienteExpediente", c => c.String());
            AddColumn("dbo.Venta", "ApellidoPacienteExpediente", c => c.String());
            AddColumn("dbo.Venta", "NombrePacienteExpediente", c => c.String());
            AddColumn("dbo.Venta", "CodigoExpediente", c => c.String());
            AddColumn("dbo.Venta", "ExpedienteId", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.Venta", "PacienteId", "dbo.Paciente");
            DropIndex("dbo.Venta", new[] { "PacienteId" });
            DropColumn("dbo.Venta", "DNI");
            DropColumn("dbo.Venta", "Apellidos");
            DropColumn("dbo.Venta", "Nombre");
            DropColumn("dbo.Venta", "PacienteId");
            CreateIndex("dbo.Venta", "ExpedienteId");
            AddForeignKey("dbo.Venta", "ExpedienteId", "dbo.Expediente", "IdExpediente", cascadeDelete: true);
        }
    }
}
