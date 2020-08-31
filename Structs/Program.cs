namespace Structs
{
    /// <summary>
    /// Main class
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Starting point of the program
        /// </summary>
        /// <param name="args">String arguments</param>
        static void Main(string[] args)
        {
            ProgramProvider provider = ProgramProvider.GetInstance();
            provider.Start();
        }
    }
}
