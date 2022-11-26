namespace SparkPlug.Api.Abstractions.Test.Common;

public class Test_ErrorResponse
{
    [Fact]
    public void Create_ErrorResponse_With_No_Constructor_Perameter()
    {
        var qr = new ErrorResponse();
        Assert.NotNull(qr);
        Assert.Null(qr.StackTrace);
        Assert.Null(qr.Message);
    }
}