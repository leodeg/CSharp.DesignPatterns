using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.BehavioralPatterns
{
	class StartMemento
	{
		public void Start ()
		{
			Man man = new Man ();
			Robot robot = new Robot ();

			man.Clothes = "Some...";
			robot.Backpack = man.Undress ();

			man.Clothes = "Something else...";
			man.Dress (robot.Backpack);
		}
	}

	#region Example

	public class Man
	{
		public string Clothes { get; set; }

		public void Dress (Backpack backpack)
		{
			Clothes = backpack.Contents;
		}

		public Backpack Undress ()
		{
			return new Backpack (Clothes);
		}
	}

	public class Backpack
	{
		public string Contents { get; set; }

		public Backpack (string contents)
		{
			Contents = contents;
		}
	}

	public class Robot
	{
		public Backpack Backpack { get; set; }
	}

	#endregion
}
