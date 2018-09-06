namespace TaskPaperParser.Types
{
    public abstract class TPType
    {
        public abstract (bool, int) TryParse(char[] input, int index, TaskPaperSolution solution);

        internal static char? Get(char[] input, int index)
        {
            if (input.Length > index && index >= 0)
            {
                return input[index];
            }

            return null;
        }

        internal static bool EndOfLine(char[] input, int index)
        {
            return Get(input, index) == '\n' || Get(input, index) == null;
        }
    }
}