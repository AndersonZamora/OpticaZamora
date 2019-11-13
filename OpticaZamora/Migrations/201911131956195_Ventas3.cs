namespace OpticaZamora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ventas3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SaleDetail", "ProductoId", "dbo.Producto");
            DropForeignKey("dbo.SaleDetail", "SaleId", "dbo.Sale");
            DropForeignKey("dbo.Venta", "PacienteId", "dbo.Paciente");
            DropForeignKey("dbo.Venta", "ProductoId", "dbo.Producto");
            DropIndex("dbo.SaleDetail", new[] { "SaleId" });
            DropIndex("dbo.SaleDetail", new[] { "ProductoId" });
            DropIndex("dbo.Venta", new[] { "ProductoId" });
            DropIndex("dbo.Venta", new[] { "PacienteId" });
            DropTable("dbo.SaleDetail");
            DropTable("dbo.Venta");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Venta",
                c => new
                    {
                        IdVenta = c.String(nullable: false, maxLength: 128),
                        NumeroVneta = c.String(),
                        Fecha = c.DateTime(nullable: false),
                        ProductoId = c.String(nullable: false, maxLength: 128),
                        NombreProducto = c.String(),
                        CategoriaProducto = c.String(),
                        PacienteId = c.String(nullable: false, maxLength: 128),
                        Nombre = c.String(),
                        Apellidos = c.String(),
                        DNI = c.String(),
                        Total = c.String(),
                        EstadoPago = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdVenta);
            
            CreateTable(
                "dbo.SaleDetail",
                c => new
                    {
                        IdSaleDatail = c.String(nullable: false, maxLength: 128),
                        SaleId = c.String(nullable: false, maxLength: 128),
                        ProductoId = c.String(nullable: false, maxLength: 128),
                        Cantidad = c.String(),
                    })
                .PrimaryKey(t => t.IdSaleDatail);
            
            CreateIndex("dbo.Venta", "PacienteId");
            CreateIndex("dbo.Venta", "ProductoId");
            CreateIndex("dbo.SaleDetail", "ProductoId");
            CreateIndex("dbo.SaleDetail", "SaleId");
            AddForeignKey("dbo.Venta", "ProductoId", "dbo.Producto", "IdProducto", cascadeDelete: true);
            AddForeignKey("dbo.Venta", "PacienteId", "dbo.Paciente", "IdPaciente", cascadeDelete: true);
            AddForeignKey("dbo.SaleDetail", "SaleId", "dbo.Sale", "IdSALE", cascadeDelete: true);
            AddForeignKey("dbo.SaleDetail", "ProductoId", "dbo.Producto", "IdProducto", cascadeDelete: true);
        }
    }
}
