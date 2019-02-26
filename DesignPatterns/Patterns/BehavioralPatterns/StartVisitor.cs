using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.BehavioralPatterns
{
	public class StartVisitor
	{
		public void Start ()
		{
			Village village = new Village ();
			village.Add (new BoysHouse ());
			village.Add (new GirlsHouse ());
			village.Accept (new Santa ());
		}
	}

	#region Example

	public abstract class OwnDelegate <T>
	{
		public abstract void DoAction (params T[] args);
	}

	public class Village
	{
		private ArrayList elements = new ArrayList ();

		public void Add (Element element)
		{
			elements.Add (element);
		}

		public void Remove (Element element)
		{
			elements.Remove (element);
		}

		public void Accept (Visitor visitor)
		{
			foreach (Element element in elements)
			{
				element.Accept (visitor);
			}
		}
	}

	public abstract class Visitor
	{
		public abstract void VisitBoysHouse (BoysHouse house);
		public abstract void VisitGirlsHouse (GirlsHouse house);

	}

	public abstract class Element
	{
		public abstract void Accept (Visitor visitor);
	}

	public class GirlsHouse : Element
	{
		public override void Accept (Visitor visitor)
		{
			visitor.VisitGirlsHouse (this);
		}

		public void GiveDress ()
		{
			Console.WriteLine ("Dress as a gift...");
		}
	}

	public class BoysHouse : Element
	{
		public override void Accept (Visitor visitor)
		{
			visitor.VisitBoysHouse (this);
		}

		public void TellFairyTail ()
		{
			Console.WriteLine ("Fairy Tale...");
		}
	}

	public class Santa : Visitor
	{
		public override void VisitBoysHouse (BoysHouse house)
		{
			house.TellFairyTail ();
		}

		public override void VisitGirlsHouse (GirlsHouse house)
		{
			house.GiveDress ();
		}
	}

	#endregion
}
