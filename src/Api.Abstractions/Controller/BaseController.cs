namespace SparkPlug.Sample.DemoApi.Controllers;

[Route("[controller]")]
public abstract class BaseController<TRepository, TEntity> : ControllerBase where TRepository : IRepository<String, TEntity>
{
    protected readonly TRepository _repository;
    protected readonly ILogger<BaseController<TRepository, TEntity>> _logger;

    public BaseController(ILogger<BaseController<TRepository, TEntity>> logger, TRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpGet]
    public async Task<IEnumerable<TEntity>> Get(IQueryRequest request)
    {
        var recs = await _repository.ListAsync(request);
        return recs;
    }

    [HttpPost]
    public async Task Post([FromBody] CommandRequest<TEntity> rec)
    {
        await _repository.CreateAsync(rec);
    }

    [HttpPut("{id}")]
    public async Task Put(String id, [FromBody] CommandRequest<TEntity> rec)
    {
        await _repository.UpdateAsync(id, rec);
    }

    [HttpPatch("{id}")]
    public async Task Patch(String id, [FromBody] CommandRequest<TEntity> rec)
    {
        await _repository.PatchAsync(id, rec);
    }

    [HttpDelete("{id}")]
    public async Task Delete(String id)
    {
        await _repository.DeleteAsync(id);
    }
}
