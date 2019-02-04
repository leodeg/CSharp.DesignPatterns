using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{

	internal class Door : MapSite
	{
		private Room m_Room1 = null;
		private Room m_Room2 = null;
		private bool m_IsOpen;

		public Door (Room room1, Room room2)
		{
			m_Room1 = room1;
			m_Room2 = room2;
		}

		public override void Enter ()
		{
			Console.WriteLine ("Door.");
		}

		/// <summary>
		/// Return other side the from current room.
		/// </summary>
		public Room OtherSideFrom (Room room)
		{
			return ( room == m_Room1 ) ? m_Room2 : m_Room1;
		}
	}
}
