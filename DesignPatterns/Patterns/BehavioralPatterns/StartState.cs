using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.BehavioralPatterns
{
	class StartState
	{

	}

	#region Example

	class Context
	{
		public State State { get; set; }

		public Context (State state)
		{
			this.State = state;
		}

		public void Request ()
		{
			this.State.Handle (this);
		}
	}

	abstract class State
	{
		public abstract void Handle (Context context);
	}

	class StateA : State
	{
		public override void Handle (Context context)
		{
			context.State = new StateA ();
		}
	}

	class StateB : State
	{
		public override void Handle (Context context)
		{
			context.State = new StateB ();
		}
	}

	#endregion
}
