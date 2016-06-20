using System;
using Poncho;
using PonchoMonogame;

namespace PonchoMonogameTest
{
	/// <summary>
	/// The main class.
	/// </summary>
	public static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			App.Init(new MonogameApp( () => new MonogameTest() ));
		}
	}
}
