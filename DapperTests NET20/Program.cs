#region Usings
using System;
using System.Data.SqlClient;
using System.Reflection;


#endregion


namespace DapperTests_NET20
{
	internal class Program
	{
		public static readonly string connectionString = "Data Source=.;Initial Catalog=tempdb;Integrated Security=True";

		private static void Main()
		{
			RunTests();
			Console.WriteLine("(end of tests; press any key)");

			Console.ReadKey();
		}

		public static SqlConnection GetOpenConnection()
		{
			var connection = new SqlConnection(connectionString);
			connection.Open();
			return connection;
		}

		private static void RunTests()
		{
			var tester = new Tests();
			foreach (var method in typeof (Tests).GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
			{
				Console.Write("Running " + method.Name);
				method.Invoke(tester, null);
				Console.WriteLine(" - OK!");
			}
		}
	}
}