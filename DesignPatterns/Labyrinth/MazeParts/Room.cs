using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{

	internal class Room : MapSite
	{
		private int m_RoomNumber = 0;
		private const int k_WallNumber = 4;

		Dictionary<Direction, MapSite> m_Sides;

		public Room (int roomNumber)
		{
			m_RoomNumber = roomNumber;
			m_Sides = new Dictionary<Direction, MapSite> (k_WallNumber);
		}

		public int RoomNumber
		{
			get { return m_RoomNumber; }
			set { m_RoomNumber = value; }
		}

		public override void Enter ()
		{
			Console.WriteLine ("Enter to room.");
		}

		public MapSite GetSide (Direction direction)
		{
			return m_Sides[direction];
		}

		public void SetSide (Direction direction, MapSite mapSide)
		{
			m_Sides.Add (direction, mapSide);
		}
	}
}
