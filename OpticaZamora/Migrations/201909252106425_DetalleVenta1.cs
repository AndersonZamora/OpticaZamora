namespace OpticaZamora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DetalleVenta1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DetalleVenta", "ProductoPrecio", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DetalleVenta", "ProductoPrecio", c => c.String());
        }
    }
}
