using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.BehavioralPatterns
{
	internal class StartMediator
	{
		public void Start ()
		{

			throw new NotImplementedException ();
		}

		public void StartBusiness ()
		{
			var mediator = new ConcreteMediator ();
			var farmer = new Farmer (mediator);
			var cannery = new Cannery (mediator);
			var shop = new Shop (mediator);

			mediator.Farmer = farmer;
			mediator.Cannery = cannery;
			mediator.Shop = shop;

			farmer.GrowTomate ();
		}
	}

	#region Business example

	internal abstract class Mediator
	{
		public abstract void Send (string msg, Colleague colleague);
	}

	internal abstract class Colleague
	{
		protected Mediator m_Mediator;

		public Colleague (Mediator mediator)
		{
			this.m_Mediator = mediator;
		}
	}

	internal class ConcreteMediator : Mediator
	{
		public Farmer Farmer { get; set; }
		public Cannery Cannery { get; set; }
		public Shop Shop { get; set; }

		public override void Send (string message, Colleague colleague)
		{
			if (colleague == Farmer)
			{
				Cannery.MakeKetchup (message);
			}
			else if (colleague == Cannery)
			{
				Shop.SellKetchup (message);
			}
		}
	}

	internal class Farmer : Colleague
	{
		public Farmer (Mediator mediator) : base (mediator) { }

		public void GrowTomate ()
		{
			string tomato = "Tomato";
			Console.WriteLine (this.GetType ().Name + " raised " + tomato);
			m_Mediator.Send (tomato, this);
		}
	}

	class Cannery : Colleague
	{
		public Cannery (Mediator mediator) : base (mediator) { }

		public void MakeKetchup (string message)
		{
			string ketchup = message + "Ketchup";
			Console.WriteLine (this.GetType ().Name + " produced " + ketchup);
			m_Mediator.Send (ketchup, this);
		}
	}

	class Shop : Colleague
	{
		public Shop (Mediator mediator) : base (mediator) { }

		public void SellKetchup (string message)
		{
			Console.WriteLine (this.GetType ().Name + " sold " + message);
		}
	}

	#endregion
}
