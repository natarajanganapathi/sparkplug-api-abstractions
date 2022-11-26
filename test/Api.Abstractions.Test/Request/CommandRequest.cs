namespace SparkPlug.Api.Abstractions.Test.Request;

public class Test_CommmandRequest
{
    [Fact]
    public void Create_CommandRequest_With_No_Constructor_Perameter()
    {
        var cr = new CommandRequest<Int32>();
        Assert.NotNull(cr);
        Assert.Equal(0, cr.Data);
    }
    [Fact]
    public void Create_CommandRequest_With_Constructor_Perameter()
    {
        var cr = new CommandRequest<Int32>(100);
        Assert.NotNull(cr);
        Assert.Equal(100, cr.Data);
    }
}