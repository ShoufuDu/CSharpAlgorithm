using System;
using CSharpAlgorithm.MyString;
using CSharpAlgorithm.DynamicPlanning;
using CSharpAlgorithm.GreedySeek;
using CSharpAlgorithm.MyArray;
using System.Threading;
using System.Threading.Tasks;
using CSharpAlgorithm.MySort;
using CSharpAlgorithm.SList;
using CSharpAlgorithm.Else;
using CSharpAlgorithm.StackQueue;

namespace CSharpAlgorithm
{



    class Testref
    {
        public Testref() { }
        public int Value;
    }

    interface IAnimal
    {
        int A { get; }
        void Say();
        void Walk();
    }

    public abstract class Animal
    {
        public int a;
        virtual public void Say() { Console.WriteLine("Say virtural"); }
        protected void SayNoVirtual() { Console.WriteLine("SayNoVirtual"); }
        public void Walk() { Console.WriteLine("Walk public non-virtual"); }

        public abstract void SayAbstract();
    }

    public class Dog : Animal
    {
        public override void SayAbstract()
        {
            Console.WriteLine("Dog Say Abstract");
        }

        public new void SayNoVirtual() { Console.WriteLine("Dog SayNoVirtual protected "); }
        override public void Say() { Console.WriteLine("Dog say virtual overrid"); }

        public new void Walk() { Console.WriteLine("Dog Walk"); }
    }

    class MySingleton
    {
        static MySingleton ins;
        private MySingleton() { Console.WriteLine("the id is:{0}",id++); }
        private static int id = 1;

        private static readonly object locker = new Object();

        public int ID {
            get { return id; }
        }

        static public MySingleton Get()
        {
            if (ins == null)
            {
                lock (locker)
                {
                    if (ins == null)
                    {
                        ins = new MySingleton();
                    }
                }
            }

            return ins;
        }

        public void Testref()
        {
            Console.WriteLine("Test Singleton");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Algorithm!");

            //TestString.TestBasicFunction("");

            //string result;

            //StringSolution.TestValidPalindrome();

            //StringSolution.TestStrStr();

            //StringSolution.TestAtoI(out result);

            //StringSolution.TestDicimal2Binary(out result);
            //Console.WriteLine(result);

            //StringSolution.TestStringBinaryAdd(out result);
            //Console.WriteLine(result);

            //StringSolution.TestLongPalindrome(out result);
            //Console.WriteLine(result);

            //DynamicPlanningSolution.TestTriangleMinSum( out result);
            //Console.WriteLine(result);

            //DynamicPlanningSolution.TestContinusMaxSum(out result);
            //Console.WriteLine(result);

            //DynamicPlanningSolution.TestPalindromePartition();

            //DynamicPlanningSolution.TestCollectMaxApples(out result);

            //var dynamicPlanning = new DynamicPlanningSolution();

            //dynamicPlanning.TestCountSunkAndHit(out result);

            //DynamicPlanningSolution.TestColorBlocks(out result);

            //DynamicPlanningSolution.TestLongestIncreasingSubsequence(out result);

            //DynamicPlanningSolution.TestMinTimeToCrossBridge();

            //GreedySeekSolution.TestJumpGame2();

            //DynamicPlanningSolution.TestMaxRectangle();

            //DynamicPlanningSolution.TestPacksackSelection();

            //DynamicPlanningSolution.TestMaxMSubset();

            //ArraySolution.TestRemoveDuplicatFromUnorder();
            //ArraySolution.TestRemoveDuplicatFromSorted();

            //SortSolution.TestSort();

            //TestInherited();

            // TestSingleton();

            // LRUCache.Test();

            // ElseSolution.TestRandomArray();

            // DynamicPlanningSolution.MyTestCountSunkAndHit();

            StackQueueSolution.TestMatchSign();

            StackQueueSolution.Test_LongMatchSign_1();

            Console.Read();
        }

        public static void TestInherited()
        {
            Dog dog = new Dog();

            Animal animal = dog;

            animal.Say();
            animal.SayAbstract();
            animal.Walk();
            dog.Walk();
            dog.SayNoVirtual();

        }

        public static void TestSingleton()
        {
            //MySingleton a = MySingleton.Get();

            //a.Testref();

            for(int i=0;i<10;i++)
            {
                Task.Run(() =>
                {
                    Console.WriteLine(MySingleton.Get().ID);
                });
            }
        }

        public static void TestCaseRef()
        {
            Testref a = new Testref { Value = 10 };
            Console.WriteLine("Before TestRef, a.Value:{0}", a.Value);

            TestRef(a);
            System.Diagnostics.Debug.Assert(a != null);

            Console.WriteLine("After TestRef, a.Value:{0}", a.Value);

            Console.WriteLine("Before TestRefEx, a.Value:{0}", a.Value);
            TestRefEx(ref a);
            System.Diagnostics.Debug.Assert(a != null);
            Console.WriteLine("After TestRefEx, a.Value:{0}", a.Value);

            string str_a = "IIIIIIIIIIIII";
            Console.WriteLine(str_a);

            string str_b = str_a;
            //str_b[0] = 'H';  //error, string is const

            Console.WriteLine("Before b=a, a.Value:{0}", a.Value);
            Testref b = a;
            b.Value = 120;
            Console.WriteLine("After b=120, a.Value:{0}", a.Value);
            b = null;
            Console.WriteLine("After b=null, a.Value:{0}", a.Value);

        }


        public static void TestRef(Testref a)
        {
            a.Value = 20;
            a = null; // will not trigger assert
        }

        public static void TestRefEx(ref Testref a)
        {
            a.Value = 30;

            //a = null; will trigger assert

            Testref b = new Testref { Value = 100 };
            a = b;
        }

        public static void TestTask()
            {
                string tid = Thread.CurrentThread.ManagedThreadId.ToString();
                    Console.WriteLine($"Main1 tid {tid}");
                    Task<int> t = CalAsync();
                    Console.WriteLine($"Main2 after CalAsync");
                    tid = Thread.CurrentThread.ManagedThreadId.ToString();
                    Console.WriteLine($"main2 tid {tid}");
            }

    public static int Cal()
        {
            string tid = Thread.CurrentThread.ManagedThreadId.ToString();
            Console.WriteLine($"Cal tid {tid}");
            int sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum = sum + i;
            }
            Console.WriteLine($"sum={sum}");
            return sum;
        }

        public static async Task<int> CalAsync()
        {
            string tid = Thread.CurrentThread.ManagedThreadId.ToString();
            Console.WriteLine($"CalAsync1 tid {tid}");
            var result = await Task.Run(new Func<int>(Cal));
            tid = Thread.CurrentThread.ManagedThreadId.ToString();
            Console.WriteLine($"CalAsync2 tid {tid}, result={result}");
            return result;
        }
        }
}
