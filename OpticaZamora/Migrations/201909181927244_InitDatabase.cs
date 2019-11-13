namespace OpticaZamora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Categoria",
                c => new
                    {
                        IdCategoria = c.String(nullable: false, maxLength: 128),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.IdCategoria);
            
            CreateTable(
                "dbo.Consulta",
                c => new
                    {
                        IdConsul = c.String(nullable: false, maxLength: 128),
                        NumeroVneta = c.String(),
                        Fecha = c.DateTime(nullable: false),
                        DEsfera = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DCilindro = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DEje = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IEsfera = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ICilindro = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IEje = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PacienteId = c.String(nullable: false, maxLength: 128),
                        DoctorId = c.String(nullable: false, maxLength: 128),
                        ProductoId = c.String(nullable: false, maxLength: 128),
                        Precio = c.Single(nullable: false),
                        Total = c.Single(nullable: false),
                        Diagnostico = c.String(),
                    })
                .PrimaryKey(t => t.IdConsul)
                .ForeignKey("dbo.Doctor", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Paciente", t => t.PacienteId, cascadeDelete: true)
                .ForeignKey("dbo.Producto", t => t.ProductoId, cascadeDelete: true)
                .Index(t => t.PacienteId)
                .Index(t => t.DoctorId)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.Doctor",
                c => new
                    {
                        IdDoctor = c.String(nullable: false, maxLength: 128),
                        Codigo = c.String(),
                        Nombres = c.String(),
                        Apellidos = c.String(),
                        Celular = c.Int(nullable: false),
                        Especialidad = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdDoctor);
            
            CreateTable(
                "dbo.Paciente",
                c => new
                    {
                        IdPaciente = c.String(nullable: false, maxLength: 128),
                        TipoDocumento = c.Int(nullable: false),
                        NumeroDocumento = c.Int(nullable: false),
                        Nombres = c.String(),
                        Apellidos = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Correo = c.String(),
                        Direccion = c.String(),
                        TipoGenero = c.Int(nullable: false),
                        Telefono = c.Int(nullable: false),
                        Celular = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPaciente);
            
            CreateTable(
                "dbo.Producto",
                c => new
                    {
                        IdProducto = c.String(nullable: false, maxLength: 128),
                        CodigoProducto = c.String(),
                        Nombre = c.String(),
                        Precio = c.Single(nullable: false),
                        Stock = c.Int(nullable: false),
                        Descripcion = c.String(),
                        CategoriaId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.IdProducto)
                .ForeignKey("dbo.Categoria", t => t.CategoriaId, cascadeDelete: true)
                .Index(t => t.CategoriaId);
            
            CreateTable(
                "dbo.DetalleConsulta",
                c => new
                    {
                        IdDetalleConsulta = c.String(nullable: false, maxLength: 128),
                        ProductoId = c.String(),
                        Cantidad = c.Single(nullable: false),
                        Precio = c.Single(nullable: false),
                        Total = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.IdDetalleConsulta);
            
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
                "dbo.Usuario",
                c => new
                    {
                        IdUsuario = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Surname = c.String(),
                        TypeDocument = c.Int(nullable: false),
                        DocumentNumber = c.Int(nullable: false),
                        DateBirth = c.DateTime(nullable: false),
                        Address = c.String(),
                        Telephone = c.Int(nullable: false),
                        Mobile = c.Int(nullable: false),
                        Email = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Rol = c.String(),
                    })
                .PrimaryKey(t => t.IdUsuario);
            
            CreateTable(
                "dbo.Venta",
                c => new
                    {
                        IdVenta = c.String(nullable: false, maxLength: 128),
                        NumeroVneta = c.String(),
                        Fecha = c.DateTime(nullable: false),
                        DEsfera = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DCilindro = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DEje = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IEsfera = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ICilindro = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IEje = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Precio = c.Single(nullable: false),
                        Total = c.Single(nullable: false),
                        Diagnostico = c.String(),
                    })
                .PrimaryKey(t => t.IdVenta);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Consulta", "ProductoId", "dbo.Producto");
            DropForeignKey("dbo.Producto", "CategoriaId", "dbo.Categoria");
            DropForeignKey("dbo.Consulta", "PacienteId", "dbo.Paciente");
            DropForeignKey("dbo.Consulta", "DoctorId", "dbo.Doctor");
            DropIndex("dbo.Producto", new[] { "CategoriaId" });
            DropIndex("dbo.Consulta", new[] { "ProductoId" });
            DropIndex("dbo.Consulta", new[] { "DoctorId" });
            DropIndex("dbo.Consulta", new[] { "PacienteId" });
            DropTable("dbo.Venta");
            DropTable("dbo.Usuario");
            DropTable("dbo.Sucursal");
            DropTable("dbo.DetalleConsulta");
            DropTable("dbo.Producto");
            DropTable("dbo.Paciente");
            DropTable("dbo.Doctor");
            DropTable("dbo.Consulta");
            DropTable("dbo.Categoria");
            DropTable("dbo.AnteojoIzquierdo");
            DropTable("dbo.AnteojoDerecho");
            DropTable("dbo.Admin");
        }
    }
}
