using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.BehavioralPatterns
{
	internal class StartObserver
	{
		public void PullStart ()
		{
			ConcreteSubjectPull subject = new ConcreteSubjectPull ();
			subject.Attach (new ConcreteObserverPull (subject));
			subject.Attach (new ConcreteObserverPull (subject));
			subject.State = "State...";
			subject.Notify ();
		}

		public void PushStart ()
		{

			ConcreteSubjectPush subject = new ConcreteSubjectPush ();
			subject.Attach (new ConcreteObserverPush (subject));
			subject.Attach (new ConcreteObserverPush (subject));
			subject.State = "State...";
			subject.Notify ();
		}
	}

	#region Pull Example

	public abstract class SubjectPull
	{
		private ArrayList observers = new ArrayList ();

		public void Attach (ObserverPull observer)
		{
			observers.Add (observer);
		}

		public void Detach (ObserverPull observer)
		{
			observers.Remove (observer);
		}

		public void Notify ()
		{
			foreach (ObserverPull observer in observers)
			{
				observer.Update ();
			}
		}
	}

	public class ConcreteSubjectPull : SubjectPull
	{
		public string State { get; set; }
	}

	public abstract class ObserverPull
	{
		public abstract void Update ();
	}

	public class ConcreteObserverPull : ObserverPull
	{
		private string observerState;
		private readonly ConcreteSubjectPull subject;

		public ConcreteObserverPull (ConcreteSubjectPull subject)
		{
			this.subject = subject;
		}

		public override void Update ()
		{
			observerState = subject.State;
		}

	}
	#endregion

	#region Push Example

	abstract class SubjectPush
	{
		private ArrayList observers = new ArrayList ();

		public void Attach (ObserverPush observer)
		{
			observers.Add (observer);
		}

		public void Detach (ObserverPush observer)
		{
			observers.Remove (observer);
		}

		public virtual string State { get; set; }

		public void Notify ()
		{
			foreach (ObserverPush observer in observers)
			{
				observer.Update (State);
			}
		}
	}

	abstract class ObserverPush
	{
		public abstract void Update (string state);
	}

	class ConcreteSubjectPush : SubjectPush
	{
		public override string State { get; set; }
	}

	class ConcreteObserverPush : ObserverPush
	{
		string observerState;
		ConcreteSubjectPush concreteSubject;

		public ConcreteObserverPush (ConcreteSubjectPush subject)
		{
			concreteSubject = subject;
		}

		public override void Update (string state)
		{
			observerState = state;
		}
	}


	#endregion
}
