namespace SparkPlug.Api.Abstractions.Test;

public class Test_PageContext
{
    [Fact]
    public void Create_PageContext()
    {
        var pc = new PageContext();
        Assert.NotNull(pc);
        Assert.Equal(1, pc.PageNo);
        Assert.Equal(0, pc.Skip);
    }

    [Fact]
    public void Create_PageContext_With_Constructor()
    {
        var pc = new PageContext(10, 100);
        Assert.NotNull(pc);
        Assert.Equal(10, pc.PageNo);
        Assert.Equal(900, pc.Skip);
    }

    [Fact]
    public void NextPage_PageContext()
    {
        var pc = new PageContext();
        pc.NextPage();
        Assert.Equal(2, pc.PageNo);
        Assert.Equal(10, pc.Skip);
    }
}