using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.BehavioralPatterns
{
	public class StartCommand
	{
		public void Start ()
		{
			var calculator = new Calculator ();
			int result = 0;

			result = calculator.Add (5);
			Console.WriteLine (result);

			result = calculator.Sub (3);
			Console.WriteLine (result);

			result = calculator.Undo (2);
			Console.WriteLine (result);

			result = calculator.Redo (1);
			Console.WriteLine (result);
		}
	}

	#region Command Example
	internal class Invoker
	{
		private Command m_Command;

		public void StoreCommand (Command command)
		{
			m_Command = command;
		}

		public void ExecuteCommand ()
		{
			m_Command.Execute ();
		}
	}

	internal class Receiver
	{
		public void Action ()
		{
			Console.WriteLine ("Receiver");
		}
	}

	internal abstract class Command
	{
		protected Receiver m_Receiver;

		public Command (Receiver receiver)
		{
			m_Receiver = receiver;
		}

		public abstract void Execute ();
	}

	internal class ConcreteCommand : Command
	{
		public ConcreteCommand (Receiver receiver) : base (receiver) { }

		public override void Execute ()
		{
			m_Receiver.Action ();
		}
	}
	#endregion

	#region Calculator Command Example
	internal abstract class CalcCommand
	{
		protected ArithmeticUnit m_Unit;
		protected int m_Operand;

		public abstract void Execute ();
		public abstract void UnExecute ();
	}


	internal class Add : CalcCommand
	{
		public Add (ArithmeticUnit unit, int operand)
		{
			m_Unit = unit;
			m_Operand = operand;
		}

		public override void Execute ()
		{
			m_Unit.Run ('+', m_Operand);
		}

		public override void UnExecute ()
		{
			m_Unit.Run ('-', m_Operand);
		}
	}
	internal class Div : CalcCommand
	{
		public Div (ArithmeticUnit unit, int operand)
		{
			m_Unit = unit;
			m_Operand = operand;
		}

		public override void Execute ()
		{
			m_Unit.Run ('/', m_Operand);
		}

		public override void UnExecute ()
		{
			m_Unit.Run ('*', m_Operand);
		}
	}
	internal class Sub : CalcCommand
	{
		public Sub (ArithmeticUnit unit, int operand)
		{
			m_Unit = unit;
			m_Operand = operand;
		}

		public override void Execute ()
		{
			m_Unit.Run ('-', m_Operand);
		}

		public override void UnExecute ()
		{
			m_Unit.Run ('+', m_Operand);
		}
	}
	internal class Mul : CalcCommand
	{
		public Mul (ArithmeticUnit unit, int operand)
		{
			m_Unit = unit;
			m_Operand = operand;
		}

		public override void Execute ()
		{
			m_Unit.Run ('*', m_Operand);
		}

		public override void UnExecute ()
		{
			m_Unit.Run ('/', m_Operand);
		}
	}


	internal class ArithmeticUnit
	{
		public int Register { get; private set; }

		public void Run (char operationCode, int operand)
		{
			switch (operationCode)
			{
				case '+':
					Register += operand;
					break;

				case '-':
					Register -= operand;
					break;

				case '*':
					Register *= operand;
					break;

				case '/':
					Register /= operand;
					break;

				default:
					throw new ArgumentOutOfRangeException ();
			}
		}
	}
	internal class ControlUnit
	{
		private List<CalcCommand> m_Commands = new List<CalcCommand> ();
		private int m_Current = 0;

		public void StoreCommand (CalcCommand command)
		{
			m_Commands.Add (command);
		}

		public void ExecuteCommand ()
		{
			m_Commands[m_Current].Execute ();
			++m_Current;
		}

		public void Undo (int levels)
		{
			for (int i = 0; i < levels; i++)
			{
				if (m_Current > 0)
				{
					m_Commands[m_Current--].UnExecute ();
				}
			}
		}

		public void Redo (int levels)
		{
			for (int i = 0; i < levels; i++)
			{
				if (m_Current < m_Commands.Count - 1)
				{
					m_Commands[m_Current++].Execute ();
				}
			}
		}
	}
	internal class Calculator
	{
		private ArithmeticUnit m_Arithmetic;
		private ControlUnit m_Control;

		public Calculator ()
		{
			m_Arithmetic = new ArithmeticUnit ();
			m_Control = new ControlUnit ();
		}

		public int Run (CalcCommand command)
		{
			m_Control.StoreCommand (command);
			m_Control.ExecuteCommand ();
			return m_Arithmetic.Register;
		}

		#region Math Operations

		public int Add (int operand)
		{
			return Run (new Add (m_Arithmetic, operand));
		}

		public int Sub (int operand)
		{
			return Run (new Sub (m_Arithmetic, operand));
		}

		public int Mul (int operand)
		{
			return Run (new Mul (m_Arithmetic, operand));
		}

		public int Div (int operand)
		{
			return Run (new Div (m_Arithmetic, operand));
		}

		public int Undo (int levels)
		{
			m_Control.Undo (levels);
			return m_Arithmetic.Register;
		}

		public int Redo (int levels)
		{
			m_Control.Redo (levels);
			return m_Arithmetic.Register;
		}

		#endregion
	}
	#endregion

}