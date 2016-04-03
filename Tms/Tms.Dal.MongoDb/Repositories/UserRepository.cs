using MongoDB.Bson;
using MongoDB.Driver;
using Tms.Contracts.Dal.Repositories;
using Tms.Dal.MongoDb.Base;
using Tms.Domain.Models;

namespace Tms.Dal.MongoDb.Repositories
{
    public sealed class UserRepository : MongoRepositoryBase<User, string>, IUserRepository
    {
        public UserRepository(IMongoDatabase database) 
            : base(database)
        {

        }
    }
}