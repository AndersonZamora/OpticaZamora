namespace OpticaZamora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DetalleConsulta", "Cantidad", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DetalleConsulta", "Cantidad", c => c.Single(nullable: false));
        }
    }
}
