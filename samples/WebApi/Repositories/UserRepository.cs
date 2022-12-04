namespace WebApi.Repositories;

public class UserRepository : MongoRepository<String, UserModel>
{
    public UserRepository(IMongoDbContext context, ILogger<UserRepository> logger) : base(context, logger) { }
}
