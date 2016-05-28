using System;
using NUnit.Framework;
using TaskPaperParser;

namespace TaskPaperParserTest
{
	public class ProjectTest
	{
		[Test]
		public void SimpleProjectNameTest ()
		{
			Project p = ParseProject ("Test:\n");
			Assert.AreEqual ("Test", p.name);
		}

		[Test]
		public void ProjectNameTest ()
		{
			Project p = ParseProject ("Test Name:\n");
			Assert.AreEqual ("Test Name", p.name);
		}

		[Test]
		public void ProjectNameWithSemiColonTest ()
		{
			Project p = ParseProject ("Test: Name:\n");
			Assert.AreEqual ("Test: Name", p.name);
		}

		[Test]
		public void SimpleProjectNoIndentTest () {
			Project p = ParseProject ("Test:\n");
			Assert.AreEqual (0, p.indentLevel);
		}

		[Test]
		public void SimpleProject1IndentTest () {
			Project p = ParseProject ("\tTest:\n");
			Assert.AreEqual (1, p.indentLevel);
		}

		[Test]
		public void SimpleProject2IndentTest () {
			Project p = ParseProject ("\t\tTest:\n");
			Assert.AreEqual (2, p.indentLevel);
		}

		[Test]
		public void SimpleProject3SpacesTest () {
			Project p = ParseProject ("   Test:\n");
			Assert.AreEqual (0, p.indentLevel);
		}

		[Test]
		public void SimpleProject4SpacesTest () {
			Project p = ParseProject ("    Test:\n");
			Assert.AreEqual (1, p.indentLevel);
		}

		[Test]
		public void SimpleProject5SpacesTest () {
			Project p = ParseProject ("     Test:\n");
			Assert.AreEqual (1, p.indentLevel);
		}

		[Test]
		public void SimpleProject8SpacesTest () {
			Project p = ParseProject ("        Test:\n");
			Assert.AreEqual (2, p.indentLevel);
		}
			
		public static Project ParseProject(string s) {
			object obj = Parser.ParseLine(s);
			if (obj is Project) {
				return (obj as Project);
			} else {
				Assert.Fail("Was not Project. Was: " + obj.GetType().FullName);
				throw new Exception ("Womp");
			}
		}
	}
}

