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

		public DoneState(object obj)
		{
			this.result = obj;
		}
	}
}

