namespace OpticaZamora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nuevo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctor", "TipoDocumento", c => c.Int(nullable: false));
            AddColumn("dbo.Doctor", "NumeroDocumento", c => c.String());
            AlterColumn("dbo.Doctor", "Celular", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Doctor", "Celular", c => c.Int(nullable: false));
            DropColumn("dbo.Doctor", "NumeroDocumento");
            DropColumn("dbo.Doctor", "TipoDocumento");
        }
    }
}
