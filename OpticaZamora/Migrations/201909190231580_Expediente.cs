namespace OpticaZamora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Expediente : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Expediente",
                c => new
                    {
                        IdExpediente = c.String(nullable: false, maxLength: 128),
                        CodigoExpediente = c.String(),
                        Fecha = c.DateTime(nullable: false),
                        DEsfera = c.String(),
                        DCilindro = c.String(),
                        DEje = c.String(),
                        IEsfera = c.String(),
                        ICilindro = c.String(),
                        IEje = c.String(),
                        Recomendacion = c.String(),
                        DoctorId = c.String(),
                        PacienteId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.IdExpediente)
                .ForeignKey("dbo.Doctor", t => t.PacienteId, cascadeDelete: true)
                .ForeignKey("dbo.Paciente", t => t.PacienteId, cascadeDelete: true)
                .Index(t => t.PacienteId);
            
            AddColumn("dbo.Venta", "ProductoId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Venta", "ExpedienteId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Venta", "ProductoId");
            CreateIndex("dbo.Venta", "ExpedienteId");
            AddForeignKey("dbo.Venta", "ExpedienteId", "dbo.Expediente", "IdExpediente", cascadeDelete: true);
            AddForeignKey("dbo.Venta", "ProductoId", "dbo.Producto", "IdProducto", cascadeDelete: true);
            DropColumn("dbo.Venta", "DEsfera");
            DropColumn("dbo.Venta", "DCilindro");
            DropColumn("dbo.Venta", "DEje");
            DropColumn("dbo.Venta", "IEsfera");
            DropColumn("dbo.Venta", "ICilindro");
            DropColumn("dbo.Venta", "IEje");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Venta", "IEje", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Venta", "ICilindro", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Venta", "IEsfera", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Venta", "DEje", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Venta", "DCilindro", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Venta", "DEsfera", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.Venta", "ProductoId", "dbo.Producto");
            DropForeignKey("dbo.Venta", "ExpedienteId", "dbo.Expediente");
            DropForeignKey("dbo.Expediente", "PacienteId", "dbo.Paciente");
            DropForeignKey("dbo.Expediente", "PacienteId", "dbo.Doctor");
            DropIndex("dbo.Venta", new[] { "ExpedienteId" });
            DropIndex("dbo.Venta", new[] { "ProductoId" });
            DropIndex("dbo.Expediente", new[] { "PacienteId" });
            DropColumn("dbo.Venta", "ExpedienteId");
            DropColumn("dbo.Venta", "ProductoId");
            DropTable("dbo.Expediente");
        }
    }
}
