namespace Core.Test;

public class ServiceTests
{
    [Fact]
    public void GivenAFile_FetchNoOfBytes_EnsureItIsCorrect()
    {
        //ARRANGE
        string filePath = Path.Combine("TestData","test.txt");

        //ACT
        long result = Service.GetNumberOfBytesInFile(filePath);

        //ASSERT
        Assert.Equal(342190, result);

    }


    [Fact]
    public void GivenAFile_FetchNoOfLines_EnsureItIsCorrect()
    {
        //ARRANGE
        string filePath = Path.Combine("TestData", "test.txt");

        //ACT
        long result = Service.GetNumberOfLinesInAFile(filePath);

        //ASSERT
        Assert.Equal(7145, result);

    }

    [Fact]
    public void GivenAFile_FetchNoOfWords_EnsureItIsCorrect()
    {
        //ARRANGE
        string filePath = Path.Combine("TestData", "test.txt");

        //ACT
        long result = Service.GetNumberOfWordsInAFile(filePath);

        //ASSERT
        Assert.Equal(58164, result);

    }

    [Fact]
    public void GivenAFile_FetchNoOfCharacters_EnsureItIsCorrect()
    {
        //ARRANGE
        string filePath = Path.Combine("TestData", "test.txt");

        //ACT
        long result = Service.GetNumberOfCharactersInAFile(filePath);

        //ASSERT
        Assert.Equal(339292, result);

    }
}