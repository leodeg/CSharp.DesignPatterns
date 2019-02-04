using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
	class Client
	{
		private AbstractWater m_Water;
		private AbstractBottle m_Bottle;

		public Client (AbstractFactory factory)
		{
			m_Water = factory.CreateWater ();
			m_Bottle = factory.CreateBottle ();
		}

		public void Run ()
		{
			m_Bottle.Interact (m_Water);
		}
	}
}
