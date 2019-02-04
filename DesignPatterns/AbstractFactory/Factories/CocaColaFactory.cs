using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
	class CocaColaFactory : AbstractFactory
	{
		public override AbstractBottle CreateBottle ()
		{
			return new CocaColaBottle ();
		}

		public override AbstractWater CreateWater ()
		{
			return new CocaColaWater ();
		}
	}

	class CocaColaWater : AbstractWater { }

	class CocaColaBottle : AbstractBottle
	{
		public override void Interact (AbstractWater water)
		{
			Console.WriteLine (this + " interacts with " + water);
		}
	}

	class CocaColaCover : AbstractCover { }
}
