namespace OpticaZamora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class venta31 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Paciente", "Venta_IdVenta", "dbo.Venta");
            DropIndex("dbo.Paciente", new[] { "Venta_IdVenta" });
            DropColumn("dbo.Paciente", "Venta_IdVenta");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Paciente", "Venta_IdVenta", c => c.String(maxLength: 128));
            CreateIndex("dbo.Paciente", "Venta_IdVenta");
            AddForeignKey("dbo.Paciente", "Venta_IdVenta", "dbo.Venta", "IdVenta");
        }
    }
}
