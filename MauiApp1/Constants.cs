using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1;

public static class Constants
{

	public const string DatabaseFilename = "CardsSQLite.db3";
	public const SQLite.SQLiteOpenFlags Flags =
		SQLite.SQLiteOpenFlags.ReadWrite |
		SQLite.SQLiteOpenFlags.Create |
		SQLite.SQLiteOpenFlags.SharedCache;

	public static string DatabasePath
	{
		get
		{
			var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			return Path.Combine(basePath, DatabaseFilename);
		}
	}
}
