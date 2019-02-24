using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.StructuralPatterns
{
	public class StartBridge
	{

	}

	#region First Example

	public abstract class Shape
	{
		public LineStyle m_LineStyle;
		public abstract void Draw ();
	}

	public abstract class LineStyle
	{
		public abstract void Draw ();
	}

	public class DotLine : LineStyle
	{
		public override void Draw ()
		{
			Console.WriteLine ("Draw Dot Line");
		}
	}

	public class DashDotLine : LineStyle
	{
		public override void Draw ()
		{
			Console.WriteLine ("Draw Dash Dot Line");
		}
	}

	public class Pentagon : Shape
	{
		public override void Draw ()
		{
			Console.WriteLine ("Draw Pentagon");
		}
	}

	public class Square : Shape
	{
		public override void Draw ()
		{
			Console.WriteLine ("Draw Square");
		}
	}

	public class Triangle : Shape
	{
		public override void Draw ()
		{
			Console.WriteLine ("Draw Triangle");
		}
	}

	#endregion

	#region Second Example

	abstract class Abstraction
	{
		protected Implementator implementator;

		public Abstraction (Implementator imp)
		{
			implementator = imp;
		}

		public virtual void Operation ()
		{
			implementator.OperationImp ();
		}
	}

	class RefinedAbstraction : Abstraction
	{
		public RefinedAbstraction (Implementator imp) : base (imp) { }

		public override void Operation ()
		{
			base.Operation ();
			Console.WriteLine ("RefinedAbstraction Operation...");
		}
	}


	abstract class Implementator
	{
		public abstract void OperationImp ();
	}

	class ConcreteImplementatorA : Implementator
	{
		public override void OperationImp ()
		{
			Console.WriteLine ("ConcreteImplementatorA");
		}
	}

	class ConcreteImplementatorB : Implementator
	{
		public override void OperationImp ()
		{
			Console.WriteLine ("ConcreteImplementatorB");
		}
	}

	#endregion
}
