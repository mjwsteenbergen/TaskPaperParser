using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TaskPaperParser;
using TaskPaperParser.Types;

namespace TaskPaperTest
{
    class ParseTagTest
    {
        [Test]
        public void TodoWithTagTest()
        {
            TaskPaperSolution p = Parser.Parse("Test:\n - Test @Test");
            Project project = p.Projects.First();
            Assert.AreEqual("Test ", project.Todos[0].Name);
            Assert.AreEqual("Test", project.Todos[0].Tags[0].Name);
        }

        [Test]
        public void TodoWithTagInTextTest()
        {
            TaskPaperSolution p = Parser.Parse("Test:\n - Test@Test");
            Project project = p.Projects.First();
            Assert.AreEqual("Test@Test", project.Todos[0].Name);
            Assert.AreEqual(0, project.Todos[0].Tags.Count);
        }

        [Test]
        public void TodoWithTagTest2()
        {
            TaskPaperSolution p = Parser.Parse("Test:\n - Test @TestTag");
            Project project = p.Projects.First();
            Assert.AreEqual("Test ", project.Todos[0].Name);
            Assert.AreEqual("TestTag", project.Todos[0].Tags[0].Name);
        }

        [Test]
        public void TodoWithTwoTagsTest()
        {
            TaskPaperSolution p = Parser.Parse("Test:\n - Test @TestTag @Tag2");
            Project project = p.Projects.First();
            Assert.AreEqual("Test ", project.Todos[0].Name);
            Assert.AreEqual("TestTag", project.Todos[0].Tags[0].Name);
            Assert.AreEqual("Tag2", project.Todos[0].Tags[1].Name);
        }

        [Test]
        public void TodoWithTagWithValueTest()
        {
            TaskPaperSolution p = Parser.Parse("Test:\n - Test @Test(value)");
            Project project = p.Projects.First();
            Assert.AreEqual("Test ", project.Todos[0].Name);
            Assert.AreEqual("value", project.Todos[0].Tags[0].Values[0]);
        }

        [Test]
        public void TodoWithTagWithTwoValueTest()
        {
            TaskPaperSolution p = Parser.Parse("Test:\n - Test @Test(value,value2)");
            Project project = p.Projects.First();
            Assert.AreEqual("Test ", project.Todos[0].Name);
            Assert.AreEqual("value", project.Todos[0].Tags[0].Values[0]);
            Assert.AreEqual("value2", project.Todos[0].Tags[0].Values[1]);
        }

        [Test]
        public void TodoWithTagAtStartTest()
        {
            TaskPaperSolution p = Parser.Parse("Test:\n - @Test");
            Project project = p.Projects.First();
            Assert.AreEqual("", project.Todos[0].Name);
            Assert.AreEqual("Test", project.Todos[0].Tags[0].Name);
        }
    }
}
