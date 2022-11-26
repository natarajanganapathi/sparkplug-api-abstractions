namespace SparkPlug.Api.Abstractions;

public interface IPageContext
{
    int PageNo { get; set; }
    int PageSize { get; }
    int Skip { get; }
}
