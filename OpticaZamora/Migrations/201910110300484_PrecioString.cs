namespace OpticaZamora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrecioString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Producto", "Precio", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Producto", "Precio", c => c.Single(nullable: false));
        }
    }
}
