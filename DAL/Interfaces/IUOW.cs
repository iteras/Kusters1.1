using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Interfaces;
using Dal.Repositories;
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
        IEFRepository<ContactType> ContactTypes { get; }
        IEFRepository<MultiLangString> MultiLangStrings { get; }
        IEFRepository<Translation> Translations { get; }

        ICampaignRepository Campaigns { get; }
        IChatRepository Chats { get; }
        IContractRepository Contracts { get; }
        IDealRepository Deals { get; }
        IDescriptionRepository Descriptions { get; }
        IPersonInChatRepository PersonInChats { get; }
        IPersonInContractRepository PersonInContracts { get; }
        IPersonInDealRepository PersonInDeals { get; }
        IPersonInPretensionRepository PersonInPretensions { get; }
        IProductRepository Products { get; }
        IPictureRepository Pictures { get; }
        IRoleRepository Roles { get; }
        IPretensionRepository Pretensions { get; }
        IPersonRepository Persons { get; }
        IContactRepository Contacts { get; }
        IArticleRepository Articles { get; }


        // Identity, PK - string
        //IUserRepository Users { get; }
        //IUserRoleRepository UserRoles { get; }
        //IRoleRepository Roles { get; }
        //IUserClaimRepository UserClaims { get; }
        //IUserLoginRepository UserLogins { get; }

        // Identity, PK - int
        IUserIntRepository UsersInt { get; }
        IUserRoleIntRepository UserRolesInt { get; }
        IRoleIntRepository RolesInt { get; }
        IUserClaimIntRepository UserClaimsInt { get; }
        IUserLoginIntRepository UserLoginsInt { get; }
    }
}