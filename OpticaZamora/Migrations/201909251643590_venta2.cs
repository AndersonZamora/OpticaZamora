namespace OpticaZamora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class venta2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Venta", "NombrePacienteExpediente", c => c.String());
            AddColumn("dbo.Venta", "ApellidoPacienteExpediente", c => c.String());
            AddColumn("dbo.Venta", "DNIPacienteExpediente", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Venta", "DNIPacienteExpediente");
            DropColumn("dbo.Venta", "ApellidoPacienteExpediente");
            DropColumn("dbo.Venta", "NombrePacienteExpediente");
        }
    }
}
