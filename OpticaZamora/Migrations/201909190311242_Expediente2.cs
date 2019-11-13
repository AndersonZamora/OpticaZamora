namespace OpticaZamora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Expediente2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Paciente", "NumeroDocumento", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Paciente", "NumeroDocumento", c => c.Int(nullable: false));
        }
    }
}
