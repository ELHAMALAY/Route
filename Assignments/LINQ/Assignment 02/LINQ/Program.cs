//using static LINQ.DataSources.Source;
using LINQ.Models;
using LINQ.DataSources;

namespace LINQ
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Part_01

			#region Q03
			//var result = Source.ProductList
			//			.OrderBy(p => p.Category);
			//foreach(var product in result)
			//{
			//	Console.WriteLine($"{product.ProductName} - {product.UnitPrice}");
			//};
			#endregion

			#region Q08
			//var result = Source.ProductList
			//			.OrderBy(p => p.Category)
			//			.ThenByDescending(p => p.UnitPrice);
			#endregion

			#region Q09
			//var result = Source.ProductList
			//			.Where(p => p.Category == "Beverages")
			//			.OrderByDescending(p => p.UnitsInStock);

			//foreach (var p in result)
			//	Console.WriteLine($"{p.ProductName} - Stock: {p.UnitsInStock}");
			#endregion

			#region Q12
			//string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

			//var result = Arr
			//	.OrderBy(s => s.Length)
			//	.ThenBy(s => s, StringComparer.OrdinalIgnoreCase);
			#endregion

			#endregion

			#region Part_02

			#region Q01
			//var top3ExpensiveProducts = Source.ProductList.OrderByDescending(p => p.UnitPrice).Take(3);
			#endregion

			#region Q02
			//int pageNumber = 2;
			//int pageSize = 5;
			//var page2 = Source.ProductList.Skip((pageNumber - 1) * pageSize).Take(pageSize);
			#endregion

			#region Q03
			//var cheapUntil25 = Source.ProductList.OrderBy(P => P.UnitPrice).TakeWhile(P => P.UnitPrice < 25m);
			#endregion

			#region Q04
			//bool allSeafoodInStock = Source.ProductList.Where(p => p.Category == "Seafood").All(p => p.UnitsInStock > 0);
			#endregion

			#region Q05
			//int[] ids = { 3, 9, 13, 18 };
			//bool containsNine  = ids.Contains(9);
			#endregion

			#region Q06
			//var byCategory = Source.ProductList.GroupBy(p => p.Category);

			//foreach(var categoryGroup in byCategory)
			//{
			//	Console.WriteLine($"{categoryGroup.Key}: {categoryGroup.Count()}");
			//}
			#endregion

			#region Q07
			//var byCategory = Source.ProductList.GroupBy(p => p.Category);
			//foreach(var categoryGroub in byCategory)
			//{
			//	Console.WriteLine($"---------{categoryGroub.Key}-------------");
			//	foreach(var product in categoryGroub)
			//	{
			//		Console.WriteLine($"{product.ProductName}");
			//	}
			//}
			#endregion

			#region Q08
			//var bigCategories = Source.ProductList
			//					.GroupBy(p => p.Category)
			//					.Where(g => g.Count() > 10)
			//					.Select(g => g.Key);
			#endregion

			#region Q09
			//var customersByCountry = from c in Source.CustomerList
			//						 group c by c.Country into countryGroup
			//						 select new
			//						 {
			//							 Country = countryGroup.Key,
			//							 Count = countryGroup.Count(),
			//							 TotalOrderValue = countryGroup.SelectMany(c => c.Orders).Sum(o => o.Total)
			//						 };

			//foreach (var item in customersByCountry)
			//{
			//	Console.WriteLine($"Country: {item.Country}");
			//	Console.WriteLine($"Count: {item.Count}");
			//	Console.WriteLine($"Total Order Value: {item.TotalOrderValue}");
			//	Console.WriteLine("--------------------");
			//}
			#endregion

			#region Q10
			//var totalUnitsInStock = Source.ProductList.Sum(p => p.UnitsInStock);
			#endregion

			#region Q11
			//var cheapestPrice = Source.ProductList.Min(p => p.UnitPrice);
			//var mostExpensivePrice = Source.ProductList.Max(p => p.UnitPrice);
			#endregion

			#region Q12
			//var distinctCategories = Source.ProductList
			//						.Select(p => p.Category)
			//						.Distinct();
			#endregion

			#region Q13
			//int[] setA = { 1, 3, 5, 7, 9, 11, 13 };
			//int[] setB = { 3, 6, 9, 12, 15, 13 };
			//var idsOnlyInA = setA.Except(setB);
			#endregion

			#region Q14
			//string[] list1 = { "Germany", "France", "UK", "Spain" };
			//string[] list2 = { "france", "SPAIN", "Italy" };
			//var countriesOnlyInList1 = list1.Except(list2, StringComparer.OrdinalIgnoreCase);
			#endregion

			#region Q15
			//Dictionary <int , Product> productsById = Source.ProductList.ToDictionary(p => p.ProductID);
			//Product product18 = productsById[18];
			#endregion

			#region Q16
			//var firstOver50 = Source.ProductList.FirstOrDefault(p => p.UnitPrice > 50m);
			#endregion

			#region Q17
			//var firstOver500 = Source.ProductList.FirstOrDefault(p => p.UnitPrice > 500m);
			#endregion

			#region Q18
			//var tableOf7 = Enumerable.Range(1, 10)
			//			   .Select(i => $"7 x {i} = {7 * i}");
			#endregion

			#region Q19
			//var evenNumbers = Enumerable.Range(1, 30)
			//				 .Where(n => n % 2 == 0);
			#endregion

			#region Q20
			//var namesConcatenated = Source.ProductList
			//					   .Take(3)
			//					   .Select(p => p.ProductName)
			//					   .Concat(Source.CustomerList.Take(3).Select(c => c.CompanyName));
			#endregion

			#region Q21
			//var productCustomerPairs = Source.ProductList
			//						  .Zip(Source.CustomerList, (product, customer) => $"{product.ProductName} sold to {customer.CompanyName}");
			#endregion

			#endregion
		}
	}
}
