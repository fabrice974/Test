using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
	class Program
	{
		interface IVehicleLimitation
		{
			int MaxMiles { get; }
		}

		[ContractClass(typeof(IVehicleLimitation))]
		interface IVehicle
		{
		}

		public abstract class class1 : IVehicle
		{
			public abstract void F();

			public virtual string DoSomething()
			{
				return "class1";
			}
		}

		public class class2 : class1
		{
			public override void F() { Console.WriteLine("class2.F"); }

			public override string DoSomething()
			{
				return "class2";
			}
		}

		public class class3 : class2
		{
			public override void F() { Console.WriteLine("class3.F"); }

			public override string DoSomething()
			{
				return "class3";
			}
		}

		public class A<T>
		{
			public class B : A<int>
			{
				public void M()
				{
					System.Console.WriteLine(typeof(T));
				}

				public class C : B
				{
				}
			}
		}

		static bool isComplete = false;


		public Program(object o)
		{
			Console.WriteLine("Object");
		}

		public Program(double[] dArray)
		{
			Console.WriteLine("double array");
		}

		public Program(int[] dArray)
		{
			Console.WriteLine("double array");
		}

		static void Main(string[] args)
		{
			var adew = new A<string>.B();

			int x = 1975;
			int y = 2015;
			x = x ^ y;// = y ^ x = x ^ y;
			Console.WriteLine("x = " + x + "; y = " + y);

			//?
			//char x = 'X';
			//int fwe = 0;
			//var ti = true ? 'X' : 0;
			//Console.WriteLine(ti);
			//Console.WriteLine(false ? fwe : 'X');

			//convert a type to object then to another type will cause invalidCastException
			double dVal = 100.1;
			Console.WriteLine((int)dVal);

			object objVal = dVal;
			var fowef = Convert.ToInt32(objVal);
			Console.WriteLine(fowef);

			//increment nullable object, still null
			int? ief = null;
			ief++;

			//virtual method execution
			//In a virtual method invocation, the run-time type of the instance for which that invocation takes place determines the actual method implementation to invoke.
			//In a non-virtual method invocation, the compile-time type of the instance is the determining factor.
			//class3 a = new class3();
			//class1 b = a;
			//Console.WriteLine(a.DoSomething());
			//Console.WriteLine(b.DoSomething());

			//a.F();
			//b.F();

			Nullable<double> nullableVariable = 0;
			double intVariable = 1;
			Console.WriteLine(nullableVariable.GetType() == intVariable.GetType());

			var list = new List<int> { 10, 20, 30, 40, 50 };
			var collection = new Collection<int>(list);
			list.Add(60);
			Console.WriteLine(String.Join(",", collection));

			//Thread debug vs release
			var v = new Thread(() =>
			{
				int i = 0;
				while (!isComplete) i += 0;
			});

			v.Start();

			Thread.Sleep(500);
			isComplete = true;
			v.Join();
			Console.WriteLine("complete!");


			//Deffered Actions
			var actions = new List<Func<int>>();
			for (int i = 0; i < 4; i++)
			{
				actions.Add(() => i);
				//yield return () => Console.WriteLine(i);
			}

			foreach (var action in actions)
			{ 
				var t3 = action();
			}

			var s = "lol";
			var t = "lof";

			for (int i = 0; i < 10; i++)
			{
				var f = FibonacciSeries(i);
			}

			if (s.Length != t.Length)
			{
				//not anagram
			}

			for (var i = 0; i <= s.Length-1; i++)
			{
				for (var j = t.Length-1; j > 0; j--)
				{
					if (s[i] != t[j])
					{
						//not anagram
					}
				}
			}

			//anagram
		}

		public static int FibonacciSeries(int n)
		{
			if (n == 0) return 0; //To return the first Fibonacci number   
			if (n == 1) return 1; //To return the second Fibonacci number   
			return FibonacciSeries(n - 1) + FibonacciSeries(n - 2);
		}
	}
}
