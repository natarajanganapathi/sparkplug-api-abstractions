namespace SparkPlug.Api.Abstractions.Test.Common;

public class Test_CommandResponse
{
    [Fact]
    public void Create_CommandResponse_With_No_Constructor_Perameter()
    {
        var qr = new CommandResponse<Int32>();
        Assert.NotNull(qr);
        Assert.Equal(0, qr.Data);
        Assert.Null(qr.Message);
    }
}