namespace SparkPlug.Api.Abstractions;

public enum Direction { Ascending, Descending }

public class Order
{
    public Order(string field, Direction direction)
    {
        Field = field;
        Direction = direction;
    }
    public string Field { get; set; }
    public Direction Direction { get; set; }
}
