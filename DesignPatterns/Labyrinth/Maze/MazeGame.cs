using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
	internal class MazeGame
	{
		MazeFactory m_Factory = null;

		public Maze CreateMaze (MazeFactory factory)
		{
			m_Factory = factory;

			Maze maze = m_Factory.MakeMaze ();
			Room room = m_Factory.MakeRoom (1);
			Room room2 = m_Factory.MakeRoom (2);
			Door door = m_Factory.MakeDoor (room, room2);

			maze.AddRoom (room);
			maze.AddRoom (room2);

			room.SetSide (Direction.North, m_Factory.MakeWall());
			room.SetSide (Direction.East,  m_Factory.MakeWall());
			room.SetSide (Direction.South, m_Factory.MakeWall());
			room.SetSide (Direction.West,  m_Factory.MakeWall());

			room2.SetSide (Direction.North, m_Factory.MakeWall ());
			room2.SetSide (Direction.East,  m_Factory.MakeWall ());
			room2.SetSide (Direction.South, m_Factory.MakeWall ());
			room2.SetSide (Direction.West,  m_Factory.MakeWall ());

			return maze;
		}
	}
}
