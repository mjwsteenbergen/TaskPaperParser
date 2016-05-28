using System;

namespace TaskPaperParser
{
	public interface IState
	{
		IState readChar (char c);
	}
}

