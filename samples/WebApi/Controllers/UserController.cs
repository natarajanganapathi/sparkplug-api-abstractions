namespace WebApi.Controllers;

[ApiController]
public class UserController : BaseController<UserRepository, UserModel>
{
    public UserController(ILogger<UserController> logger, UserRepository repository) : base(logger, repository)
    {
    }
}
