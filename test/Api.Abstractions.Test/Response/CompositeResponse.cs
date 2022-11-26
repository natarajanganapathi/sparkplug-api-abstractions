namespace SparkPlug.Api.Abstractions.Test.Common;

public class Test_CompositeResponse
{
    [Fact]
    public void Create_CompositeResponse_With_No_Constructor_Perameter()
    {
        var qr = new CompositeResponse();
        Assert.NotNull(qr);
        Assert.Null(qr.Data);
        Assert.Null(qr.Message);
    }
}