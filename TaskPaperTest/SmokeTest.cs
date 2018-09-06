using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;
using TaskPaperParser;

namespace TaskPaperTest
{
    class SmokeTest
    {
        [Test]
        public void Test()
        {
            string text = File.ReadAllText("../../../examples/example.txt");
            var res = Parser.Parse(text);
        }
    }
}
