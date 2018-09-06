using System.Collections.Generic;
using System.Linq;

namespace TaskPaperParser.Types
{
    public class Tag : TPType
    {
        public (bool, int) TryParse(char[] input, int index, List<Tag> tags)
        {
            if ((Get(input, index - 1) != ' ' && !EndOfLine(input, index -1)) || Get(input, index) != '@')
            {
                return (false, index);
            }

            index = index + 1;

            string name = "";
            List<string> values = new List<string>();
            while (Get(input, index) != ' ' && !EndOfLine(input, index) && !(Get(input, index) == ':' && EndOfLine(input, index + 1)))
            {
                char character = input[index];

                switch (character)
                {
                    case '\\':
                        name += Get(input, index++);
                        break;
                    case '(':
                        //Skip '('
                        index++;

                        string value = "";
                        while (Get(input, index) != ')')
                        {
                            switch (Get(input, index))
                            {
                                case '\\':
                                    value += Get(input, index++);
                                    break;
                                case ',':
                                    values.Add(value);
                                    value = "";
                                    break;
                                case '\n':
                                case null:
                                    throw new ParseException("This is not a valid tag. At " + name + " at index " + index);
                                default:
                                    value += Get(input, index);
                                    break;

                            }

                            index++;
                        }

                        values.Add(value);

                        if (Get(input, index + 1) != ' ' && !EndOfLine(input, index + 1) && !(Get(input, index + 1) == ':' && EndOfLine(input, index + 2)))
                        {
                            throw new ParseException("This is not a valid tag. At " + name + " at index " + index);
                        }

                        break;
                    default:
                        name += input[index];
                        break;
                }

                index++;
            }

            tags.Add(new Tag()
            {
                Name = name,
                Values = values
            });

           return (true, index);
        }

        public string Name { get; set; }
        public List<string> Values { get; set; }

        public override (bool, int) TryParse(char[] input, int index, TaskPaperSolution solution)
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return Name + "(" + Values.Aggregate((i,j) => $"{i},{j}") + ")";
        }
    }
}