using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace TaskPaperParser.Types
{
    public class Todo : TPType
    {
        public Todo()
        {
            Tags = new List<Tag>();
        }

        public List<Tag> Tags { get; set; }
        public string Name { get; set; }

        public override (bool, int) TryParse(char[] input, int index, TaskPaperSolution solution)
        {
            if (Get(input, index) == ' ' && Get(input, index + 1) == '-' && Get(input, index + 2) == ' ')
            {
                List<Tag> tags = new List<Tag>();
                index = index + 3;
                Todo todo = new Todo();
                string name = "";
                do
                {
                    (bool dibs, int newIndex) = new Tag().TryParse(input, index, tags);

                    if (dibs)
                    {
                        index = newIndex;
                    }
                    else
                    {
                        switch (Get(input, index))
                        {
                            case '\n':
                            case null:
                                solution.Add(new Todo
                                {
                                    Name = name,
                                    Tags = tags
                                });
                                return (true, index);
                            default:
                                name += Get(input, index);
                                break;
                        }
                    }

                    index++;
                } while (true);
            }

            return (false, index);
        }


        public void Add(Tag tag)
        {
            Tags.Add(tag);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}