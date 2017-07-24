using CommandLine;
using CommandLine.Text;

namespace FizzBuzzConsole
{
    class Options
    {
        public enum OutputType
        {
            Console,
            File
        }

        [Option('o', "out", Required = false, DefaultValue = OutputType.Console, HelpText = "The output type (Console or File).")]
        public OutputType Output { get; set; }

        [Option('f', "file-name", Required = false, DefaultValue = "result.txt", HelpText = "The output file name.")]
        public string FileName { get; set; }

        [Option("N", Required = true, HelpText = "The number of output items to print.")]
        public int N { get; set; }

        [Option("verbose", DefaultValue = false, HelpText = "Prints all messages to standard output.")]
        public bool Verbose { get; set; }

        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this, (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
