namespace OpticaZamora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modificaciones : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Admin");
            DropTable("dbo.AnteojoDerecho");
            DropTable("dbo.AnteojoIzquierdo");
            DropTable("dbo.DetalleConsulta");
            DropTable("dbo.Sucursal");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Sucursal",
                c => new
                    {
                        IdSucursal = c.String(nullable: false, maxLength: 128),
                        Nombre = c.String(),
                        Telefono = c.Int(nullable: false),
                        Telefono2 = c.Int(nullable: false),
                        Direccion = c.String(),
                        Correo = c.String(),
                    })
                .PrimaryKey(t => t.IdSucursal);
            
            CreateTable(
                "dbo.DetalleConsulta",
                c => new
                    {
                        IdDetalleConsulta = c.String(nullable: false, maxLength: 128),
                        ProductoId = c.String(),
                        Cantidad = c.Int(nullable: false),
                        Precio = c.Single(nullable: false),
                        Total = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.IdDetalleConsulta);
            
            CreateTable(
                "dbo.AnteojoIzquierdo",
                c => new
                    {
                        IdAnteojoIzquierdo = c.String(nullable: false, maxLength: 128),
                        IEsfera = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ICilindro = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IEje = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IdAnteojoIzquierdo);
            
            CreateTable(
                "dbo.AnteojoDerecho",
                c => new
                    {
                        IdAnteojoDerecho = c.String(nullable: false, maxLength: 128),
                        DEsfera = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DCilindro = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DEje = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IdAnteojoDerecho);
            
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        IdAdmin = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Surname = c.String(),
                        TypeDocument = c.Int(nullable: false),
                        DocumentNumber = c.Int(nullable: false),
                        Genero = c.Int(nullable: false),
                        FechaIngreso = c.DateTime(nullable: false),
                        Telephone = c.Int(nullable: false),
                        Mobile = c.Int(nullable: false),
                        Email = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdAdmin);
            
        }
    }
}
