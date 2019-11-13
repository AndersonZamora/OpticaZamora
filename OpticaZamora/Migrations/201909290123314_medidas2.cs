namespace OpticaZamora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class medidas2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Expediente", "AnchuraTotal", c => c.String());
            AddColumn("dbo.Expediente", "Puente", c => c.String());
            AddColumn("dbo.Expediente", "Calibre", c => c.String());
            AddColumn("dbo.Expediente", "LongitudVarilla", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Expediente", "LongitudVarilla");
            DropColumn("dbo.Expediente", "Calibre");
            DropColumn("dbo.Expediente", "Puente");
            DropColumn("dbo.Expediente", "AnchuraTotal");
        }
    }
}
