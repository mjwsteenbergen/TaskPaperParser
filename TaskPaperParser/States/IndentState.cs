using System;

namespace TaskPaperParser
{
	public class IndentState : IState
	{
		public int indented {
			get;
			private set;
		}

		int space {
			get;
			set;
		}

		public IndentState ()
		{
			indented = 0;
			space = 0;
		}

		public IndentState(int indent, int space) {
			indented = indent;
			this.space = space;
		}

		public IState readChar (char c)
		{
			switch (c) {
				case '\t': {
					return new IndentState (indented + 1, space);
				}
				case ' ':
				{
					if (space == 3) {
						return new IndentState (indented + 1, 0);
					} else {
						return new IndentState (indented, space + 1);
					}
				}
				default: {
					return new TextState(this, c.ToString());
				}
			}
		}
	}
}

