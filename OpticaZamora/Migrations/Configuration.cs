namespace OpticaZamora.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Mvc;
    
    internal sealed class Configuration : DbMigrationsConfiguration<OpticaZamora.DB.OpticaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OpticaZamora.DB.OpticaContext context)
        {
            //var userStore = new UserStore<ApplicationUser>(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
