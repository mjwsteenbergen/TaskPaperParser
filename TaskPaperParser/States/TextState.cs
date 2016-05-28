using System;

namespace TaskPaperParser
{
	public class TextState : IState
	{
		IndentState indent;
		public string text {
			get;
			private set;
		}

		public TextState (IndentState indentState)
		{
			this.indent = indentState;
			this.text = "";
		}

		public TextState (IndentState indentState, string text)
		{
			this.indent = indentState;
			this.text = text;
		}


		public IState readChar (char c)
		{
			switch (c) {
				case ':':
					return new ProjectIndicatorState (indent, this);

				default:
					return new TextState(indent, text + c);
			}
		}
	}
}

