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
            int oldIndex = index;
            int indent = 0;
            while(Get(input, index) == ' ' || Get(input, index) == '\t') {
                if(Get(input, index) == '\t') {
                    indent+=3;
                }
                indent++;
                index++;
            }
            
            if (Get(input, index) == '-' && Get(input, index + 1) == ' ')
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
                                    Indent = indent / 4
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

            return (false, oldIndex);
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