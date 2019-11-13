namespace OpticaZamora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Elmini : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.UsuarioLogeado");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UsuarioLogeado",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
