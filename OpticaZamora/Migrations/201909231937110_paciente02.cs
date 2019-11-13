namespace OpticaZamora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paciente02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Paciente", "Edad", c => c.String());
            DropColumn("dbo.Paciente", "FechaNacimiento");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Paciente", "FechaNacimiento", c => c.DateTime(nullable: false));
            DropColumn("dbo.Paciente", "Edad");
        }
    }
}
