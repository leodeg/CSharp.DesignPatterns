using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns.Prototype
{
	public class StartPrototype
	{
		public void Start ()
		{
			Prototype prototype;
			Prototype clone;

			prototype = new ManPrototype (1);
			clone = prototype.Clone ();

			prototype = new WomenPrototype (2);
			clone = prototype.Clone ();
		}
	}

	internal abstract class Prototype
	{
		public int Id { get; private set; }

		public Prototype (int id)
		{
			Id = id;
		}

		public abstract Prototype Clone ();
	}

	internal class ManPrototype : Prototype
	{
		public ManPrototype (int id) : base (id) { }

		public override Prototype Clone ()
		{
			return new ManPrototype (this.Id);
		}
	}

	internal class WomenPrototype : Prototype
	{
		public WomenPrototype (int id) : base (id) { }

		public override Prototype Clone ()
		{
			return new WomenPrototype (this.Id);
		}
	}
}
