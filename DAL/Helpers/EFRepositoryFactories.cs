using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Interfaces;
using Dal.Repositories;
using DAL.Interfaces;
using DAL.Repositories;
using Domain;

namespace DAL.Helpers
{
    public class EFRepositoryFactories : IDisposable
    {
        private readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly string _instanceId = Guid.NewGuid().ToString();

        private readonly IDictionary<Type, Func<IDbContext, object>> _repositoryFactories;

        public EFRepositoryFactories()
        {
            _logger.Debug("InstanceId: " + _instanceId);

            _repositoryFactories = GetCustomFactories();
        }

        //this ctor is for testing only, you can give here an arbitrary list of repos
        public EFRepositoryFactories(IDictionary<Type, Func<IDbContext, object>> factories)
        {
            _logger.Debug("InstanceId: " + _instanceId);

            _repositoryFactories = factories;
        }

        //special repos with custom interfaces are registered here
        private static IDictionary<Type, Func<IDbContext, object>> GetCustomFactories()
        {
            return new Dictionary<Type, Func<IDbContext, object>>
            {
                //{typeof(IUserRepository), dbContext => new UserRepository(dbContext)},
                //{typeof(IUserRoleRepository), dbContext => new UserRoleRepository(dbContext)},
                //{typeof(IUserClaimRepository), dbContext => new UserClaimRepository(dbContext)},
                //{typeof(IUserLoginRepository), dbContext => new UserLoginRepository(dbContext)},
                //{typeof(IRoleRepository), dbContext => new RoleRepository(dbContext)},
                {typeof (IChatRepository), dbContext => new ChatRepository(dbContext) },
                {typeof (IContractRepository), dbContext => new ContractRepository(dbContext) },
                {typeof (IDealRepository), dbContext => new DealRepository(dbContext) },
                {typeof (IDescriptionRepository), dbContext => new DescriptionRepository(dbContext) },
                {typeof (IPersonInChatRepository), dbContext => new PersonInChatRepository(dbContext) },
                {typeof (IPersonInContractRepository), dbContext => new PersonInContractRepository(dbContext) },
                {typeof (IPersonInDealRepository), dbContext => new PersonInDealRepository(dbContext) },
                {typeof (IPersonInPretensionRepository), dbContext => new PersonInPretensionRepository(dbContext) },
                {typeof (IPictureRepository), dbContext => new PictureRepository(dbContext) },
                {typeof (IPretensionRepository), dbContext => new PretensionRepository(dbContext) },
                {typeof (IProductRepository), dbContext => new ProductRepository(dbContext) },
                {typeof (ICampaignRepository), dbContext => new CampaignRepository(dbContext) },
                {typeof (IPersonRepository), dbContext => new PersonRepository(dbContext)},
                {typeof (IContactRepository), dbContext => new ContactRepository(dbContext)},
                {typeof (IArticleRepository), dbContext => new ArticleRepository(dbContext)},
                {typeof (IUserIntRepository), dbContext => new UserIntRepository(dbContext)},
                {typeof (IUserRoleIntRepository), dbContext => new UserRoleIntRepository(dbContext)},
                {typeof (IUserClaimIntRepository), dbContext => new UserClaimIntRepository(dbContext)},
                {typeof (IUserLoginIntRepository), dbContext => new UserLoginIntRepository(dbContext)},
                {typeof (IRoleIntRepository), dbContext => new RoleIntRepository(dbContext)},
                {typeof (IVideoRepository), dbContext => new VideoRepository(dbContext)},
                {typeof (IPlaylistRepository), dbContext => new PlaylistRepository(dbContext) }
            };
        }

        public Func<IDbContext, object> GetRepositoryFactory<T>()
        {
            Func<IDbContext, object> factory;
            _repositoryFactories.TryGetValue(typeof (T), out factory);
            return factory;
        }

        public Func<IDbContext, object> GetRepositoryFactoryForEntityType<T>() where T : class
        {
            // if we already have this repository in list, return it
            // if not, create new instance of EFRepository
            return GetRepositoryFactory<T>() ?? DefaultEntityRepositoryFactory<T>();
        }

        protected virtual Func<IDbContext, object> DefaultEntityRepositoryFactory<T>() where T : class
        {
            // create new instance of EFRepository<T>
            return dbContext => new EFRepository<T>(dbContext);
        }

        public void Dispose()
        {
            _logger.Debug("InstanceId: " + _instanceId);
        }
    }
}