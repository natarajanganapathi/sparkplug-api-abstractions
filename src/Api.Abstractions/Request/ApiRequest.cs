namespace SparkPlug.Api.Abstractions;

public abstract class ApiRequest : IApiRequest
{
    public string[]? Depends { get; set; }
}

public static partial class Extensions
{
    #region Depends
    public static IApiRequest Depends(this IApiRequest request, params string[] depends)
    {
        request.Depends = request.Depends?.Concat(depends).ToArray() ?? depends;
        return request;
    }
    #endregion
}
