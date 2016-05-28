using System;

namespace TaskPaperParser
{
	public class Parser
	{
		public static object ParsePage() {
			throw new NotImplementedException ();
		}

		public static object ParseLine(string line)
		{
			return ParseLine (line.ToCharArray ());
		}

		public static object ParseLine (char[] line){
			IState state = new IndentState();

			foreach (char c in line) {
				state = state.readChar (c);
			}

			if (!(state is DoneState)) {
				throw new InvalidOperationException ("State was not correct. State was: " + state.GetType ().FullName);
			} else {
				return ((DoneState)state).result;
			}

		}
		public static void Main(string[] args) {

		}
	}
}

