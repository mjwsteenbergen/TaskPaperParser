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
        public int Indent { get; set; }

        public override (bool, int) TryParse(char[] input, int index, TaskPaperSolution solution)
        {
            int indent = 0;
            var originalIndex = index;

            while(true) {
                var s = Get(input, index) switch {
                    ' ' => 1,
                    '\t' => 3,
                    '-' => 0,
                    _ => -1
                };

                if(s == -1) {
                    return (false, originalIndex);
                }

                if(s == 0) {
                    break;
                }

                indent += s;

                index++;
            }

            if (Get(input, index -1 ) == ' ' && Get(input, index) == '-' && Get(input, index + 1) == ' ')
            {
                List<Tag> tags = new List<Tag>();
                index = index + 2;
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
                                    Tags = tags,
                                    Indent = indent / 3
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

            return (false, originalIndex);
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