using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.StructuralPatterns
{
	class StartProxy
	{
		public void Start ()
		{
			Subject realMan = new RealSubject ();
			Subject robotBody = new Proxy (realMan as RealSubject);
			robotBody.Request ();
		}
	}

	#region Proxy

	abstract class Subject
	{
		public abstract void Request ();
	}

	class RealSubject : Subject
	{
		public override void Request ()
		{
			Console.WriteLine ("Real Subject");
		}
	}

	class Proxy : Subject
	{
		RealSubject subject;

		public Proxy (RealSubject subject)
		{
			this.subject = subject;
		}

		public override void Request ()
		{
			if (subject == null)
			{
				subject = new RealSubject ();
			}

			subject.Request ();
		}
	}

	#endregion
}
