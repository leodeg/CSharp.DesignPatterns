using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.StructuralPatterns
{
	internal class StartDecorator
	{
		public void Start ()
		{
			Component component = new ConcreteComponent ();
			Decorator decoderA = new ConcreteDecoratorA ();
			Decorator decoderB = new ConcreteDecoratorB ();

			decoderA.m_Component = component;
			decoderB.m_Component = decoderA;
			decoderB.Operation ();
		}
	}

	#region Decorator

	public abstract class Component
	{
		public abstract void Operation ();
	}

	public class ConcreteComponent : Component
	{
		public override void Operation ()
		{
			Console.WriteLine ("Concrete Component");
		}
	}

	public abstract class Decorator : Component
	{
		public Component m_Component { get; set; }

		public override void Operation ()
		{
			if (m_Component != null)
			{
				m_Component.Operation ();
			}
		}
	}

	public class ConcreteDecoratorA : Decorator
	{
		private string addedState = "State";

		public override void Operation ()
		{
			base.Operation ();
			Console.WriteLine (addedState);
		}
	}

	public class ConcreteDecoratorB : Decorator
	{
		private void AddedBehavior ()
		{
			Console.WriteLine ("Behavior");
		}

		public override void Operation ()
		{
			base.Operation ();
			AddedBehavior ();
		}
	}

	#endregion
}
