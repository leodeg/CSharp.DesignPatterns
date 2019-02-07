namespace Patterns.CreatinalPatterns
{
	internal class StartSingleton
	{
		public void Start ()
		{
			Singleton instance_1 = Singleton.Instance();
			Singleton instance_2 = Singleton.Instance ();
			System.Console.WriteLine (ReferenceEquals(instance_1, instance_2));

			instance_1.SingletonOperation ();

			string data = instance_1.GetSingletonData ();
			System.Console.WriteLine (data);

			string data2 = instance_2.GetSingletonData ();
			System.Console.WriteLine (data2);
		}
	}

	internal class Singleton
	{
		private static Singleton m_Instance;
		private string m_SingletonData = string.Empty;

		protected Singleton () { }

		public static Singleton Instance ()
		{
			if (m_Instance == null)
			{
				m_Instance = new Singleton ();
			}
			return m_Instance;
		}

		public void SingletonOperation ()
		{
			m_SingletonData = "Make some operation...";
		}

		public string GetSingletonData ()
		{
			return m_SingletonData;
		}
	}
}
