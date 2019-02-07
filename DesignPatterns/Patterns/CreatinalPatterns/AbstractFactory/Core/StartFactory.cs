using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns.Factory
{
	public class StartFactory
	{
		public void Start ()
		{
			Client client = null;

			client = new Client (new CocaColaFactory ());
			client.Run ();

			client = new Client (new PepsiFactory ());
			client.Run ();
		}
	}
}
