namespace OpticaZamora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paciente01 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Paciente", "Celular", c => c.String());
            DropColumn("dbo.Paciente", "Telefono");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Paciente", "Telefono", c => c.Int(nullable: false));
            AlterColumn("dbo.Paciente", "Celular", c => c.Int(nullable: false));
        }
    }
}
