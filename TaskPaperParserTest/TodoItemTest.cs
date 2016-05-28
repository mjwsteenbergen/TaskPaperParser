using System;
using NUnit.Framework;
using TaskPaperParser;

namespace TaskPaperParserTest
{
	public class TodoItemTest
	{
		[Test]
		public void SimpleItemTest ()
		{
			TodoItem t = ParseTodo ("\t - Test");
			Assert.AreEqual ("Test", t.name);
		}

		public static TodoItem ParseTodo(string s) {
			object obj = Parser.ParseLine(s);
			if (obj is TodoItem) {
				return (obj as TodoItem);
			} else {
				Assert.Fail("Was not TodoItem. Was: " + obj.GetType().FullName);
				throw new Exception ("Womp");
			}
		}
	}
}

