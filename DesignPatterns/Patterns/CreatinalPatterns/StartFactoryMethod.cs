using System;

namespace CreationalPatterns.FactoryMethods
{
	public class StartFactoryMethod
	{
		public void Start ()
		{
			Creator creator = null;
			Product product = null;

			creator = new ConcreteCreator ();
			product = creator.FactoryMethod ();

			creator.Operation ();
		}
	}

	public abstract class Product { }

	public abstract class Creator
	{
		Product m_Product;

		public abstract Product FactoryMethod ();

		public void Operation ()
		{
			m_Product = FactoryMethod ();
		}
	}

	public class ConcreteCreator : Creator
	{
		public override Product FactoryMethod ()
		{
			return new ConcreteProduct ();
		}
	}

	public class ConcreteProduct : Product
	{
		public ConcreteProduct ()
		{
			Console.WriteLine ("{0}:: Product created", GetType().FullName);
		}
	}
}
