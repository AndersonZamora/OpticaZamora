namespace OpticaZamora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class venta : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Venta", "NombreProducto", c => c.String());
            AddColumn("dbo.Venta", "CategoriaProducto", c => c.String());
            AddColumn("dbo.Venta", "CodigoExpediente", c => c.String());
            AddColumn("dbo.Venta", "PrecioProducto", c => c.String());
            AddColumn("dbo.Venta", "CantidadProductos", c => c.String());
            AddColumn("dbo.Venta", "Deposito", c => c.String());
            AddColumn("dbo.Venta", "EstadoPago", c => c.Int(nullable: false));
            AlterColumn("dbo.Venta", "Total", c => c.String());
            DropColumn("dbo.Venta", "Precio");
            DropColumn("dbo.Venta", "Diagnostico");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Venta", "Diagnostico", c => c.String());
            AddColumn("dbo.Venta", "Precio", c => c.Single(nullable: false));
            AlterColumn("dbo.Venta", "Total", c => c.Single(nullable: false));
            DropColumn("dbo.Venta", "EstadoPago");
            DropColumn("dbo.Venta", "Deposito");
            DropColumn("dbo.Venta", "CantidadProductos");
            DropColumn("dbo.Venta", "PrecioProducto");
            DropColumn("dbo.Venta", "CodigoExpediente");
            DropColumn("dbo.Venta", "CategoriaProducto");
            DropColumn("dbo.Venta", "NombreProducto");
        }
    }
}
