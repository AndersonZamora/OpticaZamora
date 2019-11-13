namespace OpticaZamora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class venta3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Venta", "PrecioProducto");
            DropColumn("dbo.Venta", "CantidadProductos");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Venta", "CantidadProductos", c => c.String());
            AddColumn("dbo.Venta", "PrecioProducto", c => c.String());
        }
    }
}
