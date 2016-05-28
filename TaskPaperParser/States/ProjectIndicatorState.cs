using System;

namespace TaskPaperParser
{
	public class ProjectIndicatorState : IState
	{
		TextState text;
		IndentState indent;

		public ProjectIndicatorState (IndentState indent, TextState text)
		{
			this.text = text;
			this.indent = indent;
		}

		public IState readChar (char c)
		{
			switch (c) {
				case '\n':
				return new DoneState(new Project () { name = this.text.text, indentLevel = this.indent.indented });
			default:
				return new TextState (indent, text.text + ':' + c.ToString());
				
			}
		}
	}
}

