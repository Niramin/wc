using Core;
using LaYumba.Functional;
using OneOf;
using System.Reflection.Metadata.Ecma335;
using static LaYumba.Functional.F;
using static Core.Service;
namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Option<string> commandOption = args.Length > 0 ? args[0] : null;
            Option<string> filePath = args.Length>1 ? args[1] : null;


            OneOf<FileContent, FilePath> file =
                filePath
                .Match<OneOf<FileContent, FilePath>>
                ( () => new FileContent(GetInputFromConsole()),
                    some => new FilePath(some)
                    );

            _ =
                commandOption
                .Match
                (
                    () => printNoOfAll(file),
                    some => DoWorkAsPerCommandOption(some, file)
                    );




        }


        private static int DoWorkAsPerCommandOption(string commandOption, OneOf<FileContent, FilePath> filePath)
            => commandOption switch
            {
                "-c" => printNoOfBytes(filePath),
                "-l" => printNoOfLines(filePath),
                "-w" => printNoOfWords(filePath),
                _ => throw new NotImplementedException()
            };

        private static int printNoOfBytes(OneOf<FileContent, FilePath> file)
        {
           long result =
                GetNumberOfBytes(file);
            _ =
                file
                .Match
                (
                    fileContent => { Console.WriteLine($"{result}"); return 0; },
                    filePath => { Console.WriteLine($"{result} {filePath.value}"); return 0; }
                    );
            return 0;
        }

        private static int printNoOfLines(OneOf<FileContent, FilePath> file)
        {
            long result =
                GetNumberOfLines(file);
            _ =
                file
                .Match
                (
                    fileContent => { Console.WriteLine($"{result}"); return 0; },
                    filePath => { Console.WriteLine($"{result} {filePath.value}"); return 0; }
                    );
            return 0;

        }

        private static int printNoOfWords(OneOf<FileContent, FilePath> file)
        {

            long result =
               GetNumberOfCharacters(file);
            _ =
                file
                .Match
                (
                    fileContent => { Console.WriteLine($"{result}"); return 0; },
                    filePath => { Console.WriteLine($"{result} {filePath.value}"); return 0; }
                    );
            return 0;
        }

        private static int printNoOfAll(OneOf<FileContent, FilePath> file)
        {

            var result =
                (GetNumberOfBytes(file), GetNumberOfLines(file), GetNumberOfCharacters(file));
            _ =
                file
                .Match
                (
                    fileContent => { Console.WriteLine($"{result.Item1} {result.Item2} {result.Item3}"); return 0; },
                    filePath => { Console.WriteLine($"{result} {filePath.value}"); return 0; }
                    );
            return 0;
        }

        private static string GetInputFromConsole()
        {
            string ans = "";
            var contentLine = Console.ReadLine();
            while ( contentLine != null )
            {
                ans += "\n" + contentLine;
                contentLine = Console.ReadLine();
            }
            return ans;
        }
    }
}
