using System;

namespace CreationalPatterns.FactoryMethods
{
    public class StartFactoryMethod
    {
        public void Start ()
        {
            Factory factory = null;
            Product product = null;

            factory = new ConcreteFactory ();
            product = factory.CreateProduct ();

            factory.Operation ();
        }
    }

    public abstract class Product { }

    public abstract class Factory
    {
        private Product Product;

        public abstract Product CreateProduct ();

        public void Operation ()
        {
            Product = CreateProduct ();
        }
    }

    public class ConcreteFactory : Factory
    {
        public override Product CreateProduct ()
        {
            return new ConcreteProduct ();
        }
    }

    public class ConcreteProduct : Product
    {
        public ConcreteProduct ()
        {
            Console.WriteLine ("{0}:: Product created", GetType ().FullName);
        }
    }
}
