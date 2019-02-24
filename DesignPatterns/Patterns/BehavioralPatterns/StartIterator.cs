using System;
using System.Collections;
using System.Collections.Generic;

namespace Patterns.BehavioralPatterns
{
	internal class StartIterator
	{
		public void Start ()
		{
			IEnumerable bank = new Bank ();
			IEnumerator cashier = bank.GetEnumerator ();

			while (cashier.MoveNext ())
			{
				Banknote banknote = cashier.Current as Banknote;
				Console.WriteLine (banknote.Nominal);
			}
		}
	}

	#region Iterator
	internal abstract class Aggregate
	{
		public abstract Iterator CreateIterator ();
		public abstract int Count { get; }
		public abstract object this[int index] { get; set; }
	}

	internal abstract class Iterator
	{
		public abstract object First ();
		public abstract object Next ();
		public abstract bool IsDone ();
		public abstract object CurrentItem ();
	}

	internal class ConcreteAggregate : Aggregate
	{
		private ArrayList m_Items = new ArrayList ();

		public override object this[int index]
		{
			get => m_Items[index];
			set => m_Items.Insert (index, value);
		}

		public override int Count => m_Items.Count;

		public override Iterator CreateIterator ()
		{
			return new ConcreteIterator (this);
		}
	}

	internal class ConcreteIterator : Iterator
	{
		private Aggregate m_Aggregate;
		private int m_Current = 0;

		public ConcreteIterator (Aggregate aggregate)
		{
			m_Aggregate = aggregate;
		}

		#region Iterator Implementation

		public override object CurrentItem ()
		{
			return m_Aggregate[m_Current];
		}

		public override object First ()
		{
			return m_Aggregate[0];
		}

		public override bool IsDone ()
		{
			if (m_Current < m_Aggregate.Count) return false;
			m_Current = 0;
			return true;
		}

		public override object Next ()
		{
			if (m_Current++ < m_Aggregate.Count - 1)
				return m_Aggregate[m_Current];
			return null;
		}

		#endregion
	}
	#endregion

	#region Bank Example
	internal interface IEnumerable
	{
		IEnumerator GetEnumerator ();
	}

	internal interface IEnumerator
	{
		bool MoveNext ();
		void Reset ();
		object Current { get; }
	}

	internal class Bank : IEnumerable
	{
		private List<Banknote> m_BankValue = new List<Banknote> ()
		{
			new Banknote(),
			new Banknote(),
			new Banknote(),
			new Banknote()
		};

		public Banknote this[int index]
		{
			get { return m_BankValue[index]; }
			set { m_BankValue.Insert (index, value); }
		}

		public int Count { get { return m_BankValue.Count; } }

		public IEnumerator GetEnumerator ()
		{
			return new Cashier (this);
		}
	}

	internal class Cashier : IEnumerator
	{
		private Bank m_Bank;
		private int m_Current = -1;

		public Cashier (Bank enumerable)
		{
			m_Bank = enumerable;
		}

		public object Current => m_Bank[m_Current];

		public bool MoveNext ()
		{
			if (m_Current < m_Bank.Count - 1)
			{
				m_Current++;
				return true;
			}
			return false;
		}

		public void Reset ()
		{
			m_Current = -1;
		}
	}

	internal class Banknote
	{
		private string money = "Money";
		public string Nominal => money;
	}
	#endregion
}
