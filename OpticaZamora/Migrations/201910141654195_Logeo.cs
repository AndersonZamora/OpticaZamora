namespace OpticaZamora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Logeo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UsuarioLogeadoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UsuarioLogeadoes");
        }
    }
}
