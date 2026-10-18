//using static LINQ.DataSources.Source;
using LINQ.DataSources;
using LINQ.Models;

namespace LINQ
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Part 01

			#region var vs dynamic vs object 

			//var name = "Salma";
			//// name = 99; //compile error — still a string

			//dynamic value = "Hello";
			//value = 42;
			//value = true;
			//value = new Customer();

			//object age = 30;

			//Console.WriteLine(name.GetType());
			//Console.WriteLine(value.GetType());
			//Console.WriteLine(age.GetType());


			//Console.WriteLine(name.Length);
			//Console.WriteLine(value.CompanyName);
			//Console.WriteLine(((string)age).Length);

			#endregion

			#region Query Syntax vs Method Syntax

			//var students = new List<Student>
			//{
			//	new() { Name = "Sara",  Grade = 90, Major = "CS"   },
			//	new() { Name = "Omar",  Grade = 75, Major = "Math" },
			//	new() { Name = "Layla", Grade = 88, Major = "CS"   },
			//	new() { Name = "Karim", Grade = 60, Major = "CS"   },
			//	new() { Name = "Nour",  Grade = 95, Major = "Math" },
			//};
			//// Filter students with grade >= 80 and major in CS,
			//// order by grade descending,
			//// select name and grade

			//var result = from s in students
			//			 where s.Grade >= 80 && s.Major == "CS"
			//			 orderby s.Grade descending
			//			 select new { s.Name, s.Grade };

			//result = students
			//  .Where(s => s.Grade >= 80 && s.Major == "CS")
			//  .OrderByDescending(s => s.Grade)
			//  .Select(s => new { s.Name, s.Grade });

			//foreach (var s in result)
			//	Console.WriteLine($"{s.Name} => {s.Grade}");

			#endregion

			#region Deferred vs Immediate Execution
			//var numbers = new List<int> { 1, 2, 3, 4, 5 };

			////// DEFERRED — query is defined but NOT executed yet
			////var result01 = numbers.Where(n => n % 2 == 0);
			////numbers.Add(6);
			////Console.WriteLine("After Adding 6");
			////foreach (var num in result01)
			////	Console.WriteLine(num); // 2 4 6

			//// IMMEDIATE — executes right away, captures snapshot
			//var result02 = numbers.Where(n => n % 2 == 0).ToList(); // ToList forces execution
			//numbers.Add(6);
			//Console.WriteLine("After Adding 6");
			//foreach (var num in result02)
			//	Console.WriteLine(num); // 2 4 


			#endregion

			#endregion

			#region Part 02

			#region Filtering - Restriction

			#region Where 
			//// Out Of Stock Products 
			//var result = Source.ProductList.Where(p => p.UnitsInStock == 0);
			//var result = ProductList.Where(p => p.UnitsInStock == 0);

			//result = from p in ProductList
			//		 where p.UnitsInStock == 0
			//		 select p;

			//// in stock AND price > $20
			//result = ProductList.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 20m);
			//result = from p in ProductList
			//		 where p.UnitsInStock > 0 & p.UnitPrice > 20
			//		 select p;
			#endregion

			#region Indexed Where 
			////Get Products Out Of Stock In First 20 Product
			//var result = ProductList.Where((p, i) => p.UnitsInStock == 0 && i < 20);
			#endregion

			#region OfType<>

			//ArrayList mixed = new() { 1, "hello", 3.14, "world", true, "linq" };

			//var result = mixed.OfType<string>();

			#endregion

			#endregion

			#region Projection

			#region Select 
			//// product names only
			//var result = ProductList.Select(p => p.ProductName);

			//// {Name, Category, Price}
			//var result = ProductList.Select(p => new { p.ProductName, p.Category, Price = p.UnitPrice });

			//// indexed overload
			//int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
			//var result = numbers.Select((n, i) => new { Num = n, InPlace = n == i });

			#endregion

			#region SelectMany 

			////var result = Source.CustomerList.Select(c => c.Orders);
			//var result = CustomerList.SelectMany(c => c.Orders);


			//// SelectMany with result selector
			//var result = CustomerList.SelectMany(c => c.Orders, (c, o) => new { c.CustomerID, o.OrderID, o.Total });


			//var result = CustomerList.SelectMany((c, ci) => c.Orders
			//						 .Select(o => $"Customer #{ci + 1} [{c.CustomerID}] =>  Order Id :{o.OrderID}"));

			//var result = CustomerList.SelectMany((c, ci) => c.Orders
			//						 .Select((o, oi) => $"Customer #{ci + 1} [{c.CustomerID}] =>  Order#{oi + 1}  Order Id : {o.OrderID}"));

			//// Query syntax
			//// orders with Total < $500
			//var result = from c in CustomerList
			//			 from o in c.Orders
			//			 where o.Total < 500m
			//			 select new { c.CustomerID, o.OrderID, o.Total };

			#endregion

			#endregion

			#region Ordering
			//// OrderBy(keySelector)
			//var result = ProductList.OrderBy(p => p.ProductName);

			//// OrderBy(keySelector, comparer)
			//string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
			//var result02 = words.OrderBy(w => w, new StringCaseInsensitiveComparer());

			//// OrderByDescending
			//result = ProductList.OrderByDescending(p => p.UnitPrice);

			//// OrderByDescending(keySelector, comparer)
			//result02 = words.OrderByDescending(w => w, new StringCaseInsensitiveComparer());

			//// ThenBy(keySelector)
			//result = ProductList.OrderBy(p => p.Category).ThenBy(p => p.ProductName);
			//result = ProductList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);

			//// Reverse()
			//string[] names = { "Aya", "omar", "Amr", "Mohamed", "Ahmed" };
			//var result03 = names.Where(x => x[0] == 'A').Reverse();

			//// Query Syntax 
			//result = from p in ProductList
			//		 orderby p.Category, p.UnitPrice descending
			//		 select p;

			#endregion

			#region Partitioning Operators only in Method Syntax
			//int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
			#region Take - Skip
			//// First 3 numbers
			//var result = numbers.Take(3); // 5 4 1

			//// First 5 products by price desc
			//var result = ProductList.OrderByDescending(p => p.UnitPrice).Take(5);

			//// Skip first 4 numbers
			//var result = numbers.Skip(4); 
			#endregion

			#region TakeWhile - SkipWhile
			//// Take while less than 6
			//var result = numbers.TakeWhile(n => n < 6);

			//// Take while value >= position
			//var result = numbers.TakeWhile((n, i) => n >= i);

			//// Skip until divisible by 3
			//var result = numbers.SkipWhile(n => n % 3 != 0);

			//// Skip while value >= position
			//var result = numbers.SkipWhile((n, i) => n >= i); 
			#endregion

			#region Hybrid Syntax [Method Syntax + Query Syntax ]

			// (Query Syntax).Linq Operator 

			////// First 5 products by price desc
			////var result = ProductList.OrderByDescending(p => p.UnitPrice).Take(5);

			//var result = (from P in ProductList
			//			  orderby P.UnitPrice descending
			//			  select P).Take(5);

			#endregion

			#endregion

			#region Quantifiers Operators only in Method Syntax 
			//// Any out-of-stock product?
			//var result = ProductList.Any(p => p.UnitsInStock == 0);

			//// All Seafood products in stock?
			//bool allInStock = ProductList
			//				  .Where(p => p.Category == "Seafood")
			//				  .All(p => p.UnitsInStock > 0);

			//int[] nums = { 2, 3, 4, 5 };
			//Console.WriteLine("Contains(4): " + nums.Contains(4));
			//Console.WriteLine("Contains(9): " + nums.Contains(9));

			//string[] fruits = { "Apple", "Banana", "Cherry" };
			//var containsCherry = fruits.Contains("cherry", StringComparer.OrdinalIgnoreCase);

			#endregion

			#region Let And Into [Valid With Query Syntax Only]


			//var Result = from P in ProductList
			//			 where P.UnitPrice * 0.9M < 10
			//			 select new
			//			 {
			//				 P.ProductName,
			//				 P.UnitPrice,
			//				 PriceAfterDisc = P.UnitPrice * 0.9M
			//			 };

			// Let => Continue Query With New Temp Variable 

			//Result = from P in ProductList
			//		 let DiscPrice = P.UnitPrice * 0.9M
			//		 where DiscPrice < 10
			//		 select new
			//		 {
			//			 P.ProductName,
			//			 P.UnitPrice,
			//			 PriceAfterDisc = DiscPrice
			//		 };
			//// Into => Restart Query With New Range Variable 
			//// Used With Group by 

			//var Result02 = from P in ProductList
			//			   select P.UnitPrice * 0.9M
			//			   into DiscPrice
			//			   where DiscPrice < 10
			//			   select DiscPrice;

			//foreach (var item in Result02)
			//	Console.WriteLine(item);

			#endregion

			#region Grouping

			#region Retrieves all products from ProductList That Out Of Stock , and groups the products by their Category

			//var byCategory = ProductList.Where(P => P.UnitsInStock == 0).GroupBy(P => P.Category);

			//byCategory = from P in ProductList
			//			 where P.UnitsInStock == 0
			//			 group P by P.Category;
			//foreach (var group in byCategory)
			//{
			//	Console.WriteLine($"    [{group.Key}]  ({group.Count()} products)");
			//	foreach (var product in group)
			//	{
			//		Console.WriteLine(product.ProductName);
			//	}
			//} 
			#endregion

			#region Example 02
			// Retrieves all products from ProductList That Out of Stock
			// Groups the products by their Category.
			// Filters out categories that contain 2 or fewer products.
			// Returns an anonymous object with two properties:
			// CategoryName 
			// CountOfProducts → the number of products in that category.

			//var result = ProductList.Where(P => P.UnitsInStock == 0)
			//						.GroupBy(P => P.Category)
			//						.Where(G => G.Count() <= 2)
			//						.Select(G => new
			//						{
			//							CategoryName = G.Key,
			//							CountOfProducts = G.Count()
			//						});
			//result = from p in ProductList
			//		 where p.UnitsInStock == 0
			//		 group p by p.Category
			//			 into Categories
			//		 where Categories.Count() <= 2
			//		 select new
			//		 {
			//			 CategoryName = Categories.Key,
			//			 CountOfProducts = Categories.Count()
			//		 };
			#endregion

			#region Group words by first letter (case-insensitive)
			//string[] w = { "Apple", "banana", "Avocado", "Berry", "Cherry", "apricot" };
			//var byLetter = w.GroupBy(s => s[0].ToString(), StringComparer.OrdinalIgnoreCase);
			//foreach (var g in byLetter)
			//	Console.WriteLine($"'{g.Key}': {string.Join(", ", g)}");
			#endregion

			#endregion

			#region Aggregation Operators only in Method Syntax
			// Count / LongCount / Sum / Min / Max / Average / Aggregate

			#region Count - CountLong
			//var productCount = ProductList.Count();
			//productCount = ProductList.Count;

			//var outOfStockCount = ProductList.Count(P => P.UnitsInStock == 0);
			//var outOfStockCountLong = ProductList.LongCount(P => P.UnitsInStock == 0);

			#endregion

			#region Sum

			//var total = ProductList.Sum(p => p.UnitsInStock);

			////  Total stock per category
			//var result = ProductList.GroupBy(p => p.Category)
			//					.Select(g => new { g.Key, TotalStock = g.Sum(p => p.UnitsInStock) })
			//					.OrderByDescending(x => x.TotalStock);

			#endregion

			#region Max - Min - Average
			//// Cheapest and most expensive product prices
			//var cheapestPrice = ProductList.Min(p => p.UnitPrice);
			//var highestPrice = ProductList.Max(p => p.UnitPrice);
			//var productWithHighestPrice = ProductList?.MaxBy(P => P.UnitPrice);
			//var productWithCheapestPrice = ProductList?.MaxBy(P => P.UnitPrice);

			//var productsAvgPrice = ProductList?.Average(p => p.UnitPrice);

			#endregion

			#region Aggregate
			//int[] numbers = [1, 2, 3, 4, 5];
			//int result = numbers.Aggregate((acc, n) => acc * n);
			//Console.WriteLine("1×2×3×4×5 = " + result);

			//decimal totalRevenue = CustomerList.SelectMany(c => c.Orders)
			//						 .Aggregate(0m, (acc, o) => acc + o.Total);
			//Console.WriteLine(totalRevenue); // 1265793.06

			//// Comma-separated product names
			//string result = ProductList
			//			   .Take(5)
			//			   .Select(p => p.ProductName)
			//			   .Aggregate("", (acc, n) => acc == "" ? n : acc + ", " + n,
			//						 result => result.ToUpper());

			//Console.WriteLine(result);
			//// CHAI, CHANG, ANISEED SYRUP, CHEF ANTON'S CAJUN SEASONING, CHEF ANTON'S GUMBO MIX

			#endregion



			#endregion

			#region Set Operations Operators only in Method Syntax
			//// Distinct / Union / Intersect / Except
			//var categories = ProductList.Select(p => p.Category).Distinct();
			//string[] dup = { "apple", "Apple", "APPLE", "cherry", "Cherry" };
			//var withoutDup = dup.Distinct(StringComparer.OrdinalIgnoreCase);


			//int[] a = { 0, 2, 4, 5, 6, 8, 9 };
			//int[] b = { 1, 3, 5, 7, 8 };
			//string[] list1 = { "apple", "banana", "cherry" };
			//string[] list2 = { "Apple", "GRAPE", "CHERRY" };

			#region Union
			//var result = a.Union(b);

			//var prodLetters = ProductList.Select(p => p.ProductName[0].ToString());
			//var custLetters = CustomerList.Select(c => c.CompanyName[0].ToString());
			//var result = prodLetters.Union(custLetters, StringComparer.OrdinalIgnoreCase); 
			#endregion

			#region Intersect

			////var result = a.Intersect(b);

			//var result = list1.Intersect(list2, StringComparer.OrdinalIgnoreCase); 
			#endregion

			#region Except
			//var result = a.Except(b);


			//var result = list1.Except(list2, StringComparer.OrdinalIgnoreCase);

			#endregion

			#endregion

			#region Conversion
			//// ToArray / ToList / ToDictionary / ToLookup / Cast 


			//var array = ProductList.Select(p => p.ProductName).ToArray();

			//var list = ProductList.Where(p => p.Category == "Seafood").ToList();

			//var dic01 = ProductList.ToDictionary(p => p.ProductID);

			//var dic02 = ProductList.ToDictionary(p => p.ProductID, p => p.ProductName);

			//var dic03 = CustomerList.ToDictionary(c => c.CustomerID, c => c.CompanyName, StringComparer.OrdinalIgnoreCase);

			//ArrayList al = new() { 1, 2, 3, 4, 5 };
			//var result = al.Cast<int>();

			//var lookup = ProductList.ToLookup(p => p.Category);
			//var seaFoodCategoryProducts = lookup["Seafood"];
			//foreach (var item in seaFoodCategoryProducts)
			//	Console.WriteLine(item);
			//Console.WriteLine("==============");
			//var nameLookup = ProductList.ToLookup(p => p.Category, p => p.ProductName);
			//var productNames = nameLookup["Seafood"];
			//foreach (var item in productNames)
			//	Console.WriteLine(item);

			#endregion

			#region Element Operators Operators only in Method Syntax
			// First / FirstOrDefault / Last / LastOrDefault / Single / SingleOrDefault / ElementAt / ElementAtOrDefault
			#region First - FirstOrDefault 
			//var result = ProductList.First();
			//result = ProductList.Where(P => P.UnitPrice > 50m).First();
			//result = ProductList.First(p => p.UnitPrice > 50m);
			//result = ProductList.FirstOrDefault(p => p.Category == "Seafood");

			#endregion

			#region Last - LastOrDefault 
			//var result = ProductList.Last();
			//result = ProductList.Where(P => P.UnitPrice > 50m).Last();
			//result = ProductList.Last(p => p.UnitPrice > 50m);
			//result = ProductList.Last(p => p.Category == "Seafood");

			#endregion

			#region Single - SingleOrDefault
			//var result = ProductList.Single(p => p.ProductID == 13);
			////// If Sequence Contains No Element Matching Condition , Will Throw Exception 
			////// If Sequence Contains Just Only One Element Matching Condition , Will Return It 
			////// If Sequence Contains More Than One Element Matching Condition , Will Throw Exception 


			//result = ProductList.Single(p => p.ProductID == 13);
			////// If Sequence Contains No Element Matching Condition , Null 
			////// If Sequence Contains Just Only One Element Matching Condition , Will Return It 
			////// If Sequence Contains More Than One Element Matching Condition , Will Throw Exception 

			#endregion

			#region ElementAt - ElementAtOrDefault
			//var result = ProductList.ElementAt(4);
			//result = ProductList.ElementAtOrDefault(999);
			#endregion
			#endregion

			#region Generation Operators
			//var result = Enumerable.Range(1, 10);
			//var result = Enumerable.Range(0, 5).Select(n => n * n);
			//var result = Enumerable.Repeat("Hello", 4);
			//var result = Enumerable.Empty<Product>();
			//var result = ProductList.Where(p => p.ProductID == 999)
			//				 .DefaultIfEmpty(new Product { ProductName = "Unknown Product", UnitPrice = 0m });
			#endregion

			#region Sequence Operations
			//int[] a = { 1, 2, 3 };
			//int[] b = { 4, 5, 6 };

			//var result = a.Concat(b);
			//var result = ProductList.Select(p => p.ProductName)
			//				 .Concat(CustomerList.Select(c => c.CompanyName));

			//var result = a.Zip(b, (x, y) => x * y); 
			//int[] x1 = { 1, 2, 3 };
			//int[] x2 = { 1, 2, 3 };
			//int[] x3 = { 1, 2, 4 };
			//Console.WriteLine("x1 == x2: " + x1.SequenceEqual(x2));
			//Console.WriteLine("x1 == x3: " + x1.SequenceEqual(x3));

			//string[] s1 = { "Apple", "Banana" };
			//string[] s2 = { "apple", "BANANA" };
			//Console.WriteLine(s1.SequenceEqual(s2, StringComparer.OrdinalIgnoreCase));
			#endregion
			//foreach (var item in result)
			//	Console.WriteLine(item);
			#endregion

			#region Q01
			//var result = Source.ProductList
			//	.Where(p => p.Category == "Seafood")
			//	.Select(p => new { p.ProductName, p.UnitPrice });

			//foreach(var item in result)
			//{
			//	Console.WriteLine($"Product Name: {item.ProductName}, Unit Price: {item.UnitPrice}");
			//}
			#endregion

			#region Q02
			//var result = Source.ProductList
			//	.Select(p=> new { p.ProductName, p.ProductID });
			//foreach(var item in result)
			//{
			//	Console.WriteLine($"{item.ProductID:D2}- Product Name: {item.ProductName}");
			//}
			#endregion

			#region Q03
			//var result = Source.ProductList
			//	.Where(p => p.UnitPrice >= 10m && p.UnitPrice <= 30);

			//foreach(var item in result)
			//{
			//	Console.WriteLine(item);
			//}
			#endregion

			#region Q04
			//var result = Source.ProductList
			//	.Where(p => p.UnitsInStock > 0 && p.Category == "Condiments");

			//foreach (var item in result)
			//{
			//	Console.WriteLine(item);
			//}
			#endregion

			#region Q05
			//var result = Source.ProductList
			//	.Select(p => new
			//		{
			//			Name = p.ProductName,
			//			Price = p.UnitPrice,
			//			StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
			//		}
			//	);

			//foreach (var item in result)
			//{
			//	Console.WriteLine($"Product Name: {item.Name}, Unit Price: {item.Price}, Stock Status: {item.StockStatus}");
			//}
			#endregion

			#region Q06
			//var result = Source.ProductList
			//			.Select((p, i) => new { p.ProductName, position = i + 1 });
			//foreach (var item in result)
			//{
			//	Console.WriteLine($"{item.position:D2}- Product Name: {item.ProductName}");
			//}
			#endregion

			#region Q07
			//var result = from c in Source.CustomerList
			//			 from o in c.Orders
			//			 where o.OrderDate.Year >= 1977
			//			 select new { c.CustomerID, o.OrderID };

			//foreach(var item in result)
			//{
			//	Console.WriteLine($"Customer ID: {item.CustomerID}, Order ID: {item.OrderID}");
			//};
			#endregion

			#region Q08
			//var result = Source.ProductList
			//			.Select((p, i) => new { p.ProductName, position = i + 1 });
			//foreach (var item in result)
			//{
			//	Console.WriteLine($"{item.position:D2}- Product Name: {item.ProductName}");
			//}
			#endregion
		}
	}
}
