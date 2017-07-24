using System;
using System.IO;
using System.Text;

namespace FizzBuzzConsole
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var options = new Options();

            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                if (options.Verbose)
                {
                    Console.WriteLine($"Output to {options.Output:G} {(options.Output == Options.OutputType.File ? options.FileName : string.Empty)}");
                    Console.WriteLine($"Counting from 1 to {options.N}\n");
                }

                if (options.N <= 0)
                {
                    Console.WriteLine($"The value of N cannot be less then 1 (it was {options.N})\n");
                }

                var fizzBuzz = FizzBuzz.Generate(options.N);

                if (options.Output == Options.OutputType.File)
                {
                    var outputPath = Path.GetFullPath(options.FileName);
                    var outputDir = Path.GetDirectoryName(outputPath);

                    if (!Directory.Exists(outputDir))
                    {
                        Console.WriteLine($"ERROR: the directory \"{outputDir}\" does not exist or can't be accessed!");
                        return (int)ErrorCode.DirectoryNotFound;
                    }

                    if (File.Exists(outputPath))
                    {
                        Console.WriteLine($"WARNING: the file \"{outputPath}\" already exists and will be overwritten.");
                    }

                    using (var writer = new StreamWriter(outputPath, false, Encoding.UTF8))
                    {
                        foreach (var item in fizzBuzz)
                        {
                            writer.WriteLine(item);
                        }
                    }
                }
                else
                {
                    foreach (var item in fizzBuzz)
                    {
                        Console.WriteLine(item);
                    }
                }

                return (int)ErrorCode.Sucess;
            }

            return (int)ErrorCode.CommandLineError;
        }
    }
}
