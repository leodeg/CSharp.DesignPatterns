using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
	internal abstract class MazeBuilder
	{
		public abstract void BuildMaze ();
		public abstract void BuildRoom (int roomNumber);
		public abstract void BuildDoor (int roomFrom, int roomTo);
		public abstract Maze GetMaze ();
	}

	internal class StandartMazeBuilder : MazeBuilder
	{
		private Maze m_CurrentMaze;

		public StandartMazeBuilder ()
		{
			m_CurrentMaze = null;
		}

		public override void BuildMaze ()
		{
			m_CurrentMaze = new Maze ();
		}

		public override void BuildRoom (int roomNumber)
		{
			Room room = new Room (roomNumber);
			m_CurrentMaze.AddRoom (room);

			room.SetSide (Direction.North, new Wall ());
			room.SetSide (Direction.South, new Wall ());
			room.SetSide (Direction.East, new Wall ());
			room.SetSide (Direction.West, new Wall ());
		}

		public override void BuildDoor (int roomFrom, int roomTo)
		{
			Room firstRoom = m_CurrentMaze.GetRoom (roomFrom);
			Room secondRoom = m_CurrentMaze.GetRoom (roomTo);

			Door door = new Door (firstRoom, secondRoom);

			firstRoom.SetSide (CommonWall (firstRoom, secondRoom), door);
			secondRoom.SetSide (CommonWall (secondRoom, firstRoom), door);
		}

		public override Maze GetMaze ()
		{
			return m_CurrentMaze;
		}

		private Direction CommonWall (Room room1, Room room2)
		{
			if (room1.GetSide (Direction.North) is Wall &&
				room1.GetSide (Direction.South) is Wall &&
				room1.GetSide (Direction.East) is Wall &&
				room1.GetSide (Direction.West) is Wall &&

				room2.GetSide (Direction.North) is Wall &&
				room2.GetSide (Direction.South) is Wall &&
				room2.GetSide (Direction.East) is Wall &&
				room2.GetSide (Direction.West) is Wall)
			{
				return Direction.East;
			}
			else
			{
				return Direction.West;
			}
		}
	}
}
