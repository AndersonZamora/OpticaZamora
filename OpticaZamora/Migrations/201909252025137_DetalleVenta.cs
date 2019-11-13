namespace OpticaZamora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DetalleVenta : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DetalleVenta",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        VentaId = c.String(),
                        Cantidad = c.String(),
                        ProductoId = c.String(),
                        ProductoNombre = c.String(),
                        ProductoCategoria = c.String(),
                        ProductoPrecio = c.String(),
                        Total = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DetalleVenta");
        }
    }
}
