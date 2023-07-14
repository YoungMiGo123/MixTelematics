namespace MixTelematics.Utilities
{
    public class Logger
    {
        public static void Log(string input)
        {
            Console.WriteLine(input);
        }
        public static void Log(object input)
        {
            Console.WriteLine(input);
        }
        public static void Log(params object[] input)
        {
            foreach (var inputItem in input)
            {
                Console.WriteLine(inputItem);
            }
        }
        public static string? ReadInput() => Console.ReadLine();
    }
}
