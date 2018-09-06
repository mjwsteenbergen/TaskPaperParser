using System;
using System.Collections.Generic;
using TaskPaperParser.Types;

namespace TaskPaperParser
{
    public class Parser
    {
        public static TaskPaperSolution Parse(string input)
        {
            TaskPaperSolution solution = new TaskPaperSolution();

            List<TPType> taskPaperTypes = new List<TPType>
            {
                new Todo(),
                new Project()
            };

            var splitInput = input.Replace("\r", "").ToCharArray();
            int index = 0;

            do
            {
                foreach (TPType tpType in taskPaperTypes)
                {
                    (bool dibs, int newIndex) = tpType.TryParse(splitInput, index, solution);
                    if (dibs)
                    {
                        index = newIndex;
                        break;
                    }
                }

                index++;
            } while (index < splitInput.Length);

            return solution;
        }
    }
}
