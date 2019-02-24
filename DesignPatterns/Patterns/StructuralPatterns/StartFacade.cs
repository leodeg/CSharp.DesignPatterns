using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.StructuralPatterns
{
	class StartFacade
	{
		public void Start ()
		{
			Facade facade = new Facade ();
			facade.OperationAB ();
			facade.OperationBC ();
		}
	}

	#region Facade

	class Facade
	{
		SubSystemA subSystemA = new SubSystemA ();
		SubSystemB subSystemB = new SubSystemB ();
		SubSystemC subSystemC = new SubSystemC ();

		public void OperationAB ()
		{
			subSystemA.OperationA ();
			subSystemB.OperationB ();
		}

		public void OperationBC ()
		{
			subSystemA.OperationA ();
			subSystemC.OperationC ();
		}
	}

	class SubSystemA
	{
		public void OperationA()
		{
			Console.WriteLine ("SubSystem A");
		}
	}

	class SubSystemB
	{
		public void OperationB ()
		{
			Console.WriteLine ("SubSystem B");
		}
	}

	class SubSystemC
	{
		public void OperationC ()
		{
			Console.WriteLine ("SubSystem C");
		}
	}

	#endregion
}
