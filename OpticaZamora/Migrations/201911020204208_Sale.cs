namespace OpticaZamora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sale : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SaleDetail",
                c => new
                    {
                        IdSaleDatail = c.String(nullable: false, maxLength: 128),
                        SaleId = c.String(nullable: false, maxLength: 128),
                        ProductoId = c.String(nullable: false, maxLength: 128),
                        Cantidad = c.String(),
                    })
                .PrimaryKey(t => t.IdSaleDatail)
                .ForeignKey("dbo.Producto", t => t.ProductoId, cascadeDelete: true)
                .ForeignKey("dbo.Sale", t => t.SaleId, cascadeDelete: true)
                .Index(t => t.SaleId)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.Sale",
                c => new
                    {
                        IdSALE = c.String(nullable: false, maxLength: 128),
                        PacienteId = c.String(nullable: false, maxLength: 128),
                        FechaVenta = c.DateTime(nullable: false),
                        Total = c.String(),
                    })
                .PrimaryKey(t => t.IdSALE)
                .ForeignKey("dbo.Paciente", t => t.PacienteId, cascadeDelete: true)
                .Index(t => t.PacienteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaleDetail", "SaleId", "dbo.Sale");
            DropForeignKey("dbo.Sale", "PacienteId", "dbo.Paciente");
            DropForeignKey("dbo.SaleDetail", "ProductoId", "dbo.Producto");
            DropIndex("dbo.Sale", new[] { "PacienteId" });
            DropIndex("dbo.SaleDetail", new[] { "ProductoId" });
            DropIndex("dbo.SaleDetail", new[] { "SaleId" });
            DropTable("dbo.Sale");
            DropTable("dbo.SaleDetail");
        }
    }
}
