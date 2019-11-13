namespace OpticaZamora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Consulta", "DoctorId", "dbo.Doctor");
            DropForeignKey("dbo.Consulta", "PacienteId", "dbo.Paciente");
            DropForeignKey("dbo.Consulta", "ProductoId", "dbo.Producto");
            DropIndex("dbo.Consulta", new[] { "PacienteId" });
            DropIndex("dbo.Consulta", new[] { "DoctorId" });
            DropIndex("dbo.Consulta", new[] { "ProductoId" });
            DropTable("dbo.Consulta");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Consulta",
                c => new
                    {
                        IdConsul = c.String(nullable: false, maxLength: 128),
                        NumeroVneta = c.String(),
                        Fecha = c.DateTime(nullable: false),
                        DEsfera = c.String(),
                        DCilindro = c.String(),
                        DEje = c.String(),
                        IEsfera = c.String(),
                        ICilindro = c.String(),
                        IEje = c.String(),
                        PacienteId = c.String(nullable: false, maxLength: 128),
                        DoctorId = c.String(nullable: false, maxLength: 128),
                        ProductoId = c.String(nullable: false, maxLength: 128),
                        Precio = c.Single(nullable: false),
                        Total = c.Single(nullable: false),
                        Diagnostico = c.String(),
                    })
                .PrimaryKey(t => t.IdConsul);
            
            CreateIndex("dbo.Consulta", "ProductoId");
            CreateIndex("dbo.Consulta", "DoctorId");
            CreateIndex("dbo.Consulta", "PacienteId");
            AddForeignKey("dbo.Consulta", "ProductoId", "dbo.Producto", "IdProducto", cascadeDelete: true);
            AddForeignKey("dbo.Consulta", "PacienteId", "dbo.Paciente", "IdPaciente", cascadeDelete: true);
            AddForeignKey("dbo.Consulta", "DoctorId", "dbo.Doctor", "IdDoctor", cascadeDelete: true);
        }
    }
}
