using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns.Factory
{
	class PepsiFactory : AbstractFactory
	{
		public override AbstractBottle CreateBottle ()
		{
			return new PepsiBottle ();
		}

		public override AbstractWater CreateWater ()
		{
			return new PepsiWater ();
		}
	}

	class PepsiWater : AbstractWater { }

	class PepsiBottle : AbstractBottle
	{
		public override void Interact (AbstractWater water)
		{
			Console.WriteLine (this + " interact with " + water);
		}
	}

	class PepsiCover : AbstractCover { }

}
