using OneOf;
using System.Text;

namespace Core;

public static class Service
{
    public static long GetNumberOfBytesInFile(string filePath)
    {
        return new FileInfo(filePath).Length;

    }

    public static long GetNumberOfLinesInAFile(string filePath)
    {
        return File.ReadAllLines(filePath).Length;
    }

    public static long GetNumberOfWordsInAFile(string filePath)
    => 
        File
        .ReadAllText(filePath)
        .Split(new char[] { ' ', '\r', '\n','\t' }, StringSplitOptions.RemoveEmptyEntries)
        .Count();

    public static long GetNumberOfCharactersInAFile(string filePath)
    => File
        .ReadAllText(filePath)
        .Length;


    public static long GetNumberOfBytes(OneOf<FileContent, FilePath> eitherFileOrContent)
    => eitherFileOrContent
        .Match
        (
            fileContent => Encoding.ASCII.GetByteCount(fileContent.Content),
            filePath => GetNumberOfBytesInFile(filePath.value)
        );

    public static long GetNumberOfLines(OneOf<FileContent, FilePath> eitherFileOrContent)
    => eitherFileOrContent
        .Match
        (
            fileContent => fileContent.Content.Split('\n').Length,
            filePath => GetNumberOfLinesInAFile(filePath.value)
        );

    public static long GetNumberOfCharacters(OneOf<FileContent, FilePath> eitherFileOrContent)
    => eitherFileOrContent
        .Match
        (
            fileContent => fileContent.Content.Length,
            filePath => GetNumberOfCharactersInAFile(filePath.value)
        );
}
