using System;
using System.Collections;

namespace CreationalPatterns.Builder
{
	public class StartBuilder
	{
		public void StartBuilding ()
		{
			Builder builder = new ConcreteBuilder ();
			Director director = new Director (builder);
			director.Construct ();

			Product product = builder.GetProduct ();
			product.Show ();
		}
	}

	internal class Director
	{
		private Builder m_Builder;

		public Director (Builder builder)
		{
			m_Builder = builder;
		}

		public void Construct ()
		{
			m_Builder.BuildPartA ();
			m_Builder.BuildPartB ();
			m_Builder.BuildPartC ();
		}
	}

	internal abstract class Builder
	{
		public abstract void BuildPartA ();
		public abstract void BuildPartB ();
		public abstract void BuildPartC ();
		public abstract Product GetProduct ();
	}

	internal class ConcreteBuilder : Builder
	{
		private Product m_Product = new Product ();

		public override void BuildPartA ()
		{
			m_Product.Add ("Part A");
		}

		public override void BuildPartB ()
		{
			m_Product.Add ("Part B");
		}

		public override void BuildPartC ()
		{
			m_Product.Add ("Part C");
		}

		public override Product GetProduct ()
		{
			return m_Product;
		}
	}

	internal class Product
	{
		private ArrayList m_Parts = new ArrayList ();

		public void Add (string part)
		{
			m_Parts.Add (part);
		}

		public void Show ()
		{
			foreach (string part in m_Parts)
			{
				Console.WriteLine (part);
			}
		}
	}
}
