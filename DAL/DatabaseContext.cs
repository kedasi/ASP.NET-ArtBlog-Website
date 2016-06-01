using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Ninject;

namespace DAL
{
    public class DataBaseContext : DbContext, IDbContext
    {
        private readonly string _instanceId = Guid.NewGuid().ToString();

        [Inject]
        public DataBaseContext() : base("name=DataBaseConnectionStr")
        {


            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataBaseContext,Migrations.Configuration>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataBaseContext>());
            Database.SetInitializer(new DatabaseInitializer());

#if DEBUG
            this.Database.Log = s => Trace.Write(s);
#endif

            //DbInterception.Add(new NLogCommandInterceptor(_logger));

            //Database.SetInitializer(new DatabaseInitializer());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataBaseContext>());
        }



        //public IDbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            // remove tablename pluralizing
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // remove cascade delete
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // convert all datetime and datetime? properties to datetime2 in ms sql
            // ms sql datetime has min value of 1753-01-01 00:00:00.000
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));

        }

        public override int SaveChanges()
        {

            // Custom exception - gives much more details why EF Validation failed
            // or watch this inside exception ((System.Data.Entity.Validation.DbEntityValidationException)$exception).EntityValidationErrors
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
        }

        public System.Data.Entity.DbSet<Domain.Models.BlogEntry> BlogEntries { get; set; }

        public System.Data.Entity.DbSet<Domain.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<Domain.Models.Comment> Comments { get; set; }

        public System.Data.Entity.DbSet<Domain.Models.Picture> Pictures { get; set; }

        public System.Data.Entity.DbSet<Domain.Models.PictureRating> PictureRatings { get; set; }

        public System.Data.Entity.DbSet<Domain.Models.Rating> Ratings { get; set; }

        //public System.Data.Entity.DbSet<Domain.Models.Warehouse> Warehouses { get; set; }

        //public System.Data.Entity.DbSet<Domain.Models.WarehouseItem> WarehouseItems { get; set; }

        //public System.Data.Entity.DbSet<Domain.Models.Item> Items { get; set; }

        //public System.Data.Entity.DbSet<Domain.Models.Category> Categories { get; set; }
    }
}
