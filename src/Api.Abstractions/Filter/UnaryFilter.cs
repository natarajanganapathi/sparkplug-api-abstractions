namespace SparkPlug.Api.Abstractions;

public enum UnaryOperator
{
    IsNull,
    IsNotNull
}

public class UnaryFilter : IUnaryFilter
{
    public UnaryFilter( String field, UnaryOperator op)
    {
        Op = op;
        Field = field;
    }
    public UnaryOperator Op { get; set; }
    public string Field { get; set; }
}