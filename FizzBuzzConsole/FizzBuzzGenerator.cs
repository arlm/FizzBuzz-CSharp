using System.Collections.Generic;
using System.Text;

namespace FizzBuzzConsole
{
    public class FizzBuzz
    {
        public static IEnumerable<string> Generate(int count)
        {
            for (int index = 1; index <= count; index++)
            {
                var div3 = index % 3 == 0;
                var div5 = index % 5 == 0;

                if (!div3 && !div5)
                {
                    yield return index.ToString();
                }
                else
                {
                    var sb = new StringBuilder();

                    if (div3)
                    {
                        sb.Append("Fizz");
                    }

                    if (div5)
                    {
                        sb.Append("Buzz");
                    }

                    yield return sb.ToString();
                }
            }
        }
    }
}
