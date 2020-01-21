using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TaskPaperParser;
using TaskPaperParser.Types;

namespace TaskPaperTest
{
    class ParseTodoTest
    {
        [Test]
        public void SimpleTodoTest()
        {
            TaskPaperSolution p = Parser.Parse("Test:\n - Test");
            Project project = p.Projects.First();
            Assert.AreEqual("Test", project.Todos.First().Name);
        }

        [Test]
        public void SimpleTodoWithNewLineTest()
        {
            TaskPaperSolution p = Parser.Parse("Test:\n - Test\n");
            Project project = p.Projects.First();
            Assert.AreEqual("Test", project.Todos.First().Name);
        }

        [Test]
        public void Todo2DashesTest()
        {
            TaskPaperSolution p = Parser.Parse("Test:\n - Test - Test");
            Project project = p.Projects.First();
            Assert.AreEqual("Test - Test", project.Todos.First().Name);
        }

        [Test]
        public void TwoSimpleTodoTest()
        {
            TaskPaperSolution p = Parser.Parse("Test:\n - Test\n - Test2");
            Project project = p.Projects.First();
            Assert.AreEqual("Test", project.Todos[0].Name);
            Assert.AreEqual("Test2", project.Todos[1].Name);
        }

        [Test]
        public void ThreeSimpleTodoTest()
        {
            TaskPaperSolution p = Parser.Parse("Test:\n - Test\n - Test2\n - Test3");
            Project project = p.Projects.First();
            Assert.AreEqual("Test", project.Todos[0].Name);
            Assert.AreEqual("Test2", project.Todos[1].Name);
            Assert.AreEqual("Test3", project.Todos[2].Name);
        }

        [Test]
        public void TodoIndentTest()
        {
            TaskPaperSolution p = Parser.Parse(@"Test:
 - Test
     - Test2
 - Test3");
            Project project = p.Projects.First();
            Assert.AreEqual("Test", project.Todos[0].Name);
            Assert.AreEqual(0, project.Todos[2].Indent);
            Assert.AreEqual("Test2", project.Todos[1].Name);
            Assert.AreEqual(1, project.Todos[1].Indent);
            Assert.AreEqual("Test3", project.Todos[2].Name);
            Assert.AreEqual(0, project.Todos[2].Indent);
        }
    }
}
