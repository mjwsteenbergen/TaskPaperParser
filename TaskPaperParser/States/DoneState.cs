using System;

namespace TaskPaperParser
{
	public class DoneState : IState
	{
		public object result {
			get;
			private set;
		}

		public IState readChar (char c)
		{
			return this; //Should do nothing
		}

		public DoneState(IState state)
		{
			if(state is TextState) {
				TextState tstate = state as TextState;
				if (tstate.todoState != null) {
					result = new TodoItem (tstate.text, tstate.indent.indented);
				} else {
					result = new Comment (tstate.text, tstate.indent.indented);
				}
			} else if (state is ProjectState) {
				ProjectState pstate = state as ProjectState;
				result = new Project () { name = pstate.text.text , indentLevel = pstate.indent.indented };
			} else {
				throw new InvalidProgramException ("Invalid state");
			}
		}
	}
}

