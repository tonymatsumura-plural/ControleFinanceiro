﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{	
	public class Card
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string Nome { get; set; }
		public decimal Gasto { get; set; }
		public decimal TetoGastos { get; set; }		
	}
}
