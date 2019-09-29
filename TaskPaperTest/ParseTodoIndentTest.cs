using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TaskPaperParser;
using TaskPaperParser.Types;

namespace TaskPaperTest
{
    class ParseTodoIntentTest
    {
        [Test]
        public void SimpleIndentTest()
        {
            TaskPaperSolution p = Parser.Parse("Test:\n - Test");
            Project project = p.Projects.First();
            Assert.AreEqual(0, project.Todos.First().Indent);
        }

        [Test]
        public void FirstIndentTest()
        {
            TaskPaperSolution p = Parser.Parse("Test:\n     - Test\n");
            Project project = p.Projects.First();
            Assert.AreEqual(1, project.Todos.First().Indent);
            Assert.AreEqual("Test", project.Todos.First().Name);
        }

        [Test]
        public void TabIndentTest()
        {
            TaskPaperSolution p = Parser.Parse("Test:\n\t - Test\n");
            Project project = p.Projects.First();
            Assert.AreEqual(1, project.Todos.First().Indent);
            Assert.AreEqual("Test", project.Todos.First().Name);
        }

        [Test]
        public void TwoSimpleTodoTest()
        {
            TaskPaperSolution p = Parser.Parse("Test:\n - Test\n    - Test2");
            Project project = p.Projects.First();
            Assert.AreEqual(0, project.Todos[0].Indent);
            Assert.AreEqual(1, project.Todos[1].Indent);
        }
    }
}
