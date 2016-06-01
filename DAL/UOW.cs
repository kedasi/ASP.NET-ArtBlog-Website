using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace DAL
{
    public class UOW : IUOW, IDisposable
    {
        private readonly string _instanceId = Guid.NewGuid().ToString();

        private IDbContext DbContext { get; set; }
        protected IEFRepositoryProvider RepositoryProvider { get; set; }

        public UOW(IEFRepositoryProvider repositoryProvider, IDbContext dbContext)
        {

            DbContext = dbContext;

            repositoryProvider.DbContext = dbContext;
            RepositoryProvider = repositoryProvider;
        }

        // UoW main feature - atomic commit at the end of work
        public void Commit()
        {
            ((DbContext)DbContext).SaveChanges();
        }

        public void RefreshAllEntities()
        {
            foreach (var entity in ((DbContext)DbContext).ChangeTracker.Entries())
            {
                entity.Reload();
            }
        }

        //standard repos
        //public IEFRepository<MultiLangString> MultiLangStrings => GetStandardRepo<MultiLangString>();

        //standard end

        // repo with custom methods
        // add it also in EFRepositoryFactories.cs, in method GetCustomFactories

        //public IArticleRepository Articles => GetRepo<IArticleRepository>();
        public IBlogEntryRepository BlogEntries => GetRepo<IBlogEntryRepository>();
        public ICommentRepository Comments => GetRepo<ICommentRepository>();
        public IPictureRatingRepository PictureRatings => GetRepo<IPictureRatingRepository>();
        public IPictureRepository Pictures => GetRepo<IPictureRepository>();
        public IRatingRepository Ratings => GetRepo<IRatingRepository>();
        public IUserRepository Users => GetRepo<IUserRepository>();




        //custom end

        // calling standard EF repo provider
        private IEFRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }

        // calling custom repo provier
        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        // try to find repository
        public T GetRepository<T>() where T : class
        {
            var res = GetRepo<T>() ?? GetStandardRepo<T>() as T;
            if (res == null)
            {
                throw new NotImplementedException("No repository for type, " + typeof(T).FullName);
            }
            return res;
        }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        #endregion
    }
}
