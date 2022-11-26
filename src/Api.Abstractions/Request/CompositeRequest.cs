namespace SparkPlug.Api.Abstractions;

public class CompositeRequest : ApiRequest, ICompositeRequest
{
    public CompositeRequest()
    {
        Requests = new Dictionary<string, IApiRequest>();
    }
    public Dictionary<string, IApiRequest>? Requests { get; set; }
}

public static partial class Extensions
{
    #region CompositeRequest
    public static ICompositeRequest Add(this ICompositeRequest source, string key, IApiRequest value)
    {
        if (source.Requests == null)
        {
            source.Requests = new Dictionary<string, IApiRequest>();
        }
        source.Requests.Add(key, value);
        return source;
    }
    #endregion
}