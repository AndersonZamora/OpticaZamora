namespace OpticaZamora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Logeo2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UsuarioLogeadoes", newName: "UsuarioLogeado");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.UsuarioLogeado", newName: "UsuarioLogeadoes");
        }
    }
}
