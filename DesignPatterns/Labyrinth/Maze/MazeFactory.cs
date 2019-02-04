using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
	class MazeFactory
	{
		public virtual Maze MakeMaze ()
		{
			return new Maze();
		}

		public virtual Wall MakeWall ()
		{
			return new Wall ();
		}

		public virtual Room MakeRoom (int number)
		{
			return new Room (number);
		}

		public virtual Door MakeDoor (Room firstRoom, Room secondRoom)
		{
			return new Door (firstRoom, secondRoom);
		}
	}
}
