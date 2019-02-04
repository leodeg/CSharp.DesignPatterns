using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{

	internal class Maze
	{
		private Dictionary<int, Room> m_Rooms = null;

		public Maze ()
		{
			m_Rooms = new Dictionary<int, Room> ();
		}

		public int RoomNumbers { get { return m_Rooms.Count; } }

		public void AddRoom (Room room)
		{
			m_Rooms.Add (room.RoomNumber, room);
		}

		public Room GetRoom (int number)
		{
			return m_Rooms[number];
		}
	}
}
