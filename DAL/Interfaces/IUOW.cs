using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DAL.Interfaces
{
    public interface IUOW
    {
        //save pending changes to the data store
        void Commit();
        void RefreshAllEntities();

        //UOW Methods, that dont fit into specific repo

        //get repository for type
        T GetRepository<T>() where T : class;

        // standard autocreated repos, since we do not have any special methods in interfaces
        IEFRepository<MultiLangString> MultiLangStrings { get; }
        IEFRepository<Translation> Translations { get; }


        // custom repos
        IArticleRepository Articles { get; }
        IBlogEntryRepository BlogEntries { get; }
        ICommentRepository Comments { get; }
        IPictureRatingRepository PictureRatings { get; }
        IPictureRepository Pictures { get; }
        IRatingRepository Ratings { get; }

        // Identity, PK - int
        IUserIntRepository UsersInt { get; }
        IUserRoleIntRepository UserRolesInt { get; }
        IRoleIntRepository RolesInt { get; }
        IUserClaimIntRepository UserClaimsInt { get; }
        IUserLoginIntRepository UserLoginsInt { get; }

    }
}
