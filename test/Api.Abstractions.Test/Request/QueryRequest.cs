namespace SparkPlug.Api.Abstractions.Test.Common;

public class Test_QueryRequest
{
    [Fact]
    public void Create_QueryRequest_With_No_Constructor_Perameter()
    {
        var ar = new QueryRequest();
        Assert.NotNull(ar);
        Assert.Null(ar.Select);
        Assert.Null(ar.Where);
        Assert.Null(ar.Sort);
        Assert.Null(ar.Page);
        Assert.Null(ar.Having);
        Assert.Null(ar.Group);
    }

    [Fact]
    public void Create_QueryRequest_With_Constructor_Perameter()
    {
        var ar = new QueryRequest(new string[] { "id", "name" }, new FieldFilter("id", FieldOperator.Equal, "1"), new Order[] { new Order("id", Direction.Ascending) }, new PageContext(10, 100));
        Assert.NotNull(ar);
        var where = ar.Where as FieldFilter;
        Assert.Equal(new string[] { "id", "name" }, ar.Select);
        Assert.Equal("id", where?.Field);
        Assert.Equal("id", ar.Sort?.First().Field);
        Assert.Equal(10, ar.Page?.PageNo);
    }

    [Fact]
    public void Verify_Api_Select()
    {
        var ar = new QueryRequest().Select("id", "name");
        Assert.Equal(new string[] { "id", "name" }, ar.Select);
    }

    [Fact]
    public void Create_Request_Dynamically()
    {
        var ar = new QueryRequest()
            .Select("id", "name")
            .Where("id", FieldOperator.Equal, "1")
            .Sort("id", Direction.Ascending)
            .Page(10, 100);

        var where = ar.Where as FieldFilter;

        Assert.Equal(new string[] { "id", "name" }, ar.Select);
        Assert.Equal("id", where?.Field);
        Assert.Equal("id", ar.Sort?.First().Field);
        Assert.Equal(10, ar.Page?.PageNo);
    }

    [Fact]
    public void Create_Request_Dynamically_With_And_Condition()
    {
        var ar = new QueryRequest()
            .Select("id", "name")
            .Where("id", FieldOperator.Equal, "1")
            .Where("name", FieldOperator.Equal, "test")
            .Sort("id", Direction.Ascending)
            .Page(new PageContext(10, 100));

        var where = ar.Where as CompositeFilter;
        var op = where?.Op;

        Assert.Equal(new string[] { "id", "name" }, ar.Select);
        Assert.Equal("id", (where?.Filters?.First() as FieldFilter)?.Field);
        Assert.Equal("id", ar.Sort?.First().Field);
        Assert.Equal(10, ar.Page?.PageNo);
    }

    [Fact]
    public void ExampleQuery()
    {
        var ar = new QueryRequest()
            .Select("id", "name")
            .Where("id", FieldOperator.Equal, "1")
            .Where("name", FieldOperator.Equal, "test")
            .OrWhere((cf) => cf.AndEqual("id", "2").AndEqual("name", "test2"))
            .Sort("id", Direction.Ascending)
            .Page(new PageContext(10, 100));

    }

    [Fact]
    public void ExampleWhereQueryBuilder()
    {
        var where = new CompositeFilter(CompositeOperator.And)
            .AndEqual("name", "test")
            .And((cf) => cf.AndEqual("id", "2").AndEqual("name", "test2"));
    }
}