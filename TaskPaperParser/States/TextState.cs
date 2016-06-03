using System;

namespace TaskPaperParser
{
	public class TextState : IState
	{
		public IndentState indent;
		public TodoState todoState;

		public string text {
			get;
			private set;
		}

		public TextState (IndentState indentState)
		{
			this.indent = indentState;
		}

		public TextState (IndentState indentState, string str)
		{
			this.text = str;
			this.indent = indentState;
		}

		public TextState (IndentState indent, TodoState todoState)
		{
			this.indent = indent;
			this.todoState = todoState;
		}

		IState addText (char c)
		{
			text += c;
			return this;
		}

		public IState readChar (char c)
		{
			switch (c) {
				case ':':
					return new ProjectState (indent, this);
				case '\n':
					return new DoneState (this);
				default:
					return this.addText(c);
			}
		}
	}
}

