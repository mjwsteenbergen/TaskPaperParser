using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskPaperParser.Types
{
    public class Project : TPType
    {
        public Project()
        {
            Todos = new List<Todo>();
            Tags = new List<Tag>();
        }

        public string Name { get; set; }
        public List<Todo> Todos { get; set; }
        public List<Tag> Tags { get; set; }


        public override (bool, int) TryParse(char[] input, int index, TaskPaperSolution solution)
        {
            string projectName = "";
            List<Tag> tags = new List<Tag>();

            while (input.Length > index && !EndOfLine(input, index))
            {
                if (input[index] == ':' && EndOfLine(input, index + 1))
                {
                    solution.Add(new Project
                    {
                        Name = projectName,
                        Tags = tags
                    });
                    return (true, index);
                }

                (bool dibs, int newIndex) = new Tag().TryParse(input, index, tags);

                if (dibs)
                {
                    index = newIndex;
                }
                else
                {
                    projectName += input[index];
                    index++;
                }
            }

            return (false, index);
        }

        
        public void Add(Todo todo)
        {
            Todos.Add(todo);
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
