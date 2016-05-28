using System;

namespace TaskPaperParser
{
	public class TodoItem
	{
		public string name {
			get;
			private set;
		}

		public int indent {
			get;
			private set;
		}

		public TodoItem (string name, int indent)
		{
			this.indent = indent;
			this.name = name;
		}
	}
}

