namespace OpticaZamora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Consulta", "DEsfera", c => c.String());
            AlterColumn("dbo.Consulta", "DCilindro", c => c.String());
            AlterColumn("dbo.Consulta", "DEje", c => c.String());
            AlterColumn("dbo.Consulta", "IEsfera", c => c.String());
            AlterColumn("dbo.Consulta", "ICilindro", c => c.String());
            AlterColumn("dbo.Consulta", "IEje", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Consulta", "IEje", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Consulta", "ICilindro", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Consulta", "IEsfera", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Consulta", "DEje", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Consulta", "DCilindro", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Consulta", "DEsfera", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
