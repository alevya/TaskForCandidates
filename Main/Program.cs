using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tasks.Task1;
using Tasks.Task2;

namespace Main
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            InitMenu();
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.D1 | keyInfo.Key == ConsoleKey.NumPad1)
                {
                    TestTask1();
                    InitMenu();
                }
                if (keyInfo.Key == ConsoleKey.D2 | keyInfo.Key == ConsoleKey.NumPad2)
                {
                    TestTask2();
                    InitMenu();
                }
               
            } while (keyInfo.Key != ConsoleKey.Escape);

        }

        private static void InitMenu()
        {
            Console.WriteLine("SELECT TASK:\n");
            Console.WriteLine("\t Press key <1> - Task №1, Press key <2> - Task №2" );
            Console.WriteLine("\t Press the Escape key to exit \n");
        }

        #region Test Task1
        private static void TestTask1()
        {
            var queue = new SafeQueue<int>();

            Action actRead = () => Read(queue);
            Action actWrite = () => Write(queue);

            var tasks = new Task[2];
            tasks[0] = Task.Factory.StartNew(actRead);
            tasks[1] = Task.Factory.StartNew(actWrite);

            Task.WaitAll(tasks);
        }

        private static void Read(SafeQueue<int> queue)
        {
            for (int i = 0; i <= 100; i++)
            {
                var res = queue.Pop();
                Console.WriteLine("Read:{0:D}", res);
            }
        }

        private static void Write(SafeQueue<int> queue)
        {
            for (int i = 0; i <= 100; i++)
            {
                queue.Push(i);
                Console.WriteLine("Write:{0:D}", i);
            }
        }

        #endregion

        #region Test Task2
        private static void TestTask2()
        {
            IEnumerable<int> inData = GetData<int>();
            int x = 11;

            if (inData == null)
            {
                Console.WriteLine("Error getting Data");
                Console.ReadLine();
                return;
            }
            var result = AlgorithmFind<int>.GetPairs(inData, x);

            foreach (var item in result)
            {
                Console.WriteLine("Pair: {0}", item);
            }
        }

        private static IEnumerable<T> GetData<T>()
        {
            int n = 100000;
            var r = new Random();
            var inData = new List<int>();
            for (var i = 0; i < n; i++)
                inData.Add(new Func<int>(() => r.Next(-10000, 1000)).Invoke());
            return inData as IEnumerable<T>;
        }

        #endregion

      
    }
   
}
