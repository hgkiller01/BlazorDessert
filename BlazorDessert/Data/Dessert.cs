using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BlazorDessert.Data
 {
//	[JsonConverter(typeof(StringEnumConverter))]
//	public enum DessertKind
//    {
//		Pie ,
//		Cookie ,
//		Cake 
//    }
	public class Dessert
	{
		public string DessertID { get; set; }
		public string DessertName { get; set; }
		public int DessertPrice { get; set; }
		public string DessertKind { get; set; }
		public string DessertIntroduction { get; set; }
		public string DessertImage { get; set; }
		public bool IsOnSale { get; set; }
	}
}
