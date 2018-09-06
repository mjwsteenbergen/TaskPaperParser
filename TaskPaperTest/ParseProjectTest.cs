using System;
using System.Linq;
using NUnit.Framework;
using TaskPaperParser;
using TaskPaperParser.Types;

namespace TaskPaperTest
{
    public class ParseProjectTest
    {
        [Test]
        public void SimpleProjectNameTest()
        {
            TaskPaperSolution p = Parser.Parse("Test:\n");
            Assert.AreEqual("Test", p.Projects.First().Name);
        }

        [Test]
        public void SimpleProjectNameAtEndTest()
        {
            TaskPaperSolution p = Parser.Parse("Test:");
            Assert.AreEqual("Test", p.Projects.First().Name);
        }

        [Test]
        public void ProjectNameTest()
        {
            TaskPaperSolution p = Parser.Parse("Test Name:\n");
            Assert.AreEqual("Test Name", p.Projects.First().Name);
        }

        [Test]
        public void ProjectWithTagTest()
        {
            TaskPaperSolution p = Parser.Parse("Test @Name:\n");
            Assert.AreEqual("Test ", p.Projects[0].Name);
            Assert.AreEqual("Name", p.Projects[0].Tags[0].Name);
        }

        [Test]
        public void ProjectNameWithSemiColonTest()
        {
            TaskPaperSolution p = Parser.Parse("Test: Name:\n");
            Assert.AreEqual("Test: Name", p.Projects.First().Name);
        }

        [Test]
        public void TwoSimpleProjectNameTest()
        {
            TaskPaperSolution p = Parser.Parse("Test:\nTest2:\n");
            Assert.AreEqual("Test", p.Projects.First().Name);
            Assert.AreEqual("Test2", p.Projects[1].Name);
        }

        [Test]
        public void ThreeSimpleProjectNameTest()
        {
            TaskPaperSolution p = Parser.Parse("Test:\nTest2:\nTest3:\n");
            Assert.AreEqual("Test", p.Projects.First().Name);
            Assert.AreEqual("Test2", p.Projects[1].Name);
            Assert.AreEqual("Test3", p.Projects[2].Name);
        }

        //        [Test]
        //        public void SimpleProjectNoIndentTest()
        //        {
        //            TaskPaperSolution p = Parser.Parse("Test:\n");
        //            Assert.AreEqual(0, p.indentLevel);
        //        }
        //
        //        [Test]
        //        public void SimpleProject1IndentTest()
        //        {
        //            TaskPaperSolution p = Parser.Parse("\tTest:\n");
        //            Assert.AreEqual(1, p.indentLevel);
        //        }
        //
        //        [Test]
        //        public void SimpleProject2IndentTest()
        //        {
        //            TaskPaperSolution p = Parser.Parse("\t\tTest:\n");
        //            Assert.AreEqual(2, p.indentLevel);
        //        }
        //
        //        [Test]
        //        public void SimpleProject3SpacesTest()
        //        {
        //            TaskPaperSolution p = Parser.Parse("   Test:\n");
        //            Assert.AreEqual(0, p.indentLevel);
        //        }
        //
        //        [Test]
        //        public void SimpleProject4SpacesTest()
        //        {
        //            TaskPaperSolution p = Parser.Parse("    Test:\n");
        //            Assert.AreEqual(1, p.indentLevel);
        //        }
        //
        //        [Test]
        //        public void SimpleProject5SpacesTest()
        //        {
        //            TaskPaperSolution p = Parser.Parse("     Test:\n");
        //            Assert.AreEqual(1, p.indentLevel);
        //        }
        //
        //        [Test]
        //        public void SimpleProject8SpacesTest()
        //        {
        //            TaskPaperSolution p = Parser.Parse("        Test:\n");
        //            Assert.AreEqual(2, p.indentLevel);
        //        }
    }
}
