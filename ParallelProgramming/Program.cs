namespace ParallelProgramming
{
    using ParallelProgramming.TaskPractise;
    using System;
    using System.Threading.Tasks;

    class IntroducingTasks
    {
        public static void Write(char c)
        {
            int i = 1000;
            while (i-- > 0)
            {
                Console.Write(c);
            }
        }

        public static void Write(object s)
        {
            int i = 1000;
            while (i-- > 0)
            {
                Console.Write(s.ToString());
            }
        }

        static void Main(string[] args)
        {
            ////CreateAndStartSimpleTasks();
            ////TasksWithState();
            ////TasksWithReturnValues();
            //var tasks = new List<Task>();
            //var ba = new BankAccount();

            //for (int i = 0; i < 10; ++i)
            //{
            //    tasks.Add(Task.Factory.StartNew(() =>
            //    {
            //        for (int j = 0; j < 1000; ++j)
            //            ba.Deposite(100);
            //    }));
            //    tasks.Add(Task.Factory.StartNew(() =>
            //    {
            //        for (int j = 0; j < 1000; ++j)
            //            ba.WithDraw(100);
            //    }));
            //}

            //Task.WaitAll(tasks.ToArray());

            //Console.WriteLine($"Final balance is {ba.Balance}.");

            //Console.WriteLine("Main program done, press any key.");
            //Console.ReadKey();
            //SolutionToSharedResourcesWithMutuxSingleThread();
            //SolutionToSharedResourcesWithSpinLockSingleThread();
            // SolutionToSharedResourcesWithSemophoreMultipleThreads();
            //Task with continuation
            //Console.WriteLine("Please enter number");
            //int number = int.Parse(Console.ReadLine());
            //Task<List<int>> task = Task.Run(() => TaskPractise.TaskPractise.AddFactors(number));

            //task.ContinueWith(t =>
            //{
            //    foreach (int i in task.Result)
            //    {
            //        Console.WriteLine(i);
            //    }
            //    Console.WriteLine("task in processing");
            //});


            //Console.WriteLine("Prgram is ready for another input");
            // Task has child / parent relation 
            //TaskPractise.TaskPractise.ChildAndParentRelation();
            //TaskPractise.TaskPractise.ThreadLocalStorage();
            //PLINQ.PLINQ.CancellationTokenAndExceptionExample();
        }

        private static void SolutionToSharedResourcesWithMutuxSingleThread()
        {
            Console.WriteLine($"the solution to Shared Resource with Mutux representing the key to the room ");

            SharedResource sharedResource = new();
            for (int i = 0; i <= 5; i++)
            {
                Thread thread = new Thread(() => { sharedResource.AccessResource(i); });
                thread.Start();
            }
            Console.ReadLine();
        }

        private static void SolutionToSharedResourcesWithSpinLockSingleThread()
        {
            Console.WriteLine($"the solution to Shared Resource with Spin lock representing keep requesting for the lock to be released ");

            RequestingResource requestResource = new();
            for (int i = 0; i <= 5; i++)
            {
                Thread thread = new Thread(() => { requestResource.RequestResource(i); });
                thread.Start();
            }
            Console.ReadLine();
        }

        private static void SolutionToSharedResourcesWithSemophoreMultipleThreads()
        {
            Console.WriteLine($"the solution to Shared Resource with Spin lock representing keep requesting for the lock to be released ");

            SemaphoreSolution requestResource = new();
            for (int i = 0; i <= 5; i++)
            {
                Thread thread = new Thread(() => { requestResource.AccessResource(i); });
                thread.Start();
            }
            Console.ReadLine();
        }

        // Summary:

        // 1. Two ways of using tasks
        //    Task.Factory.StartNew() creates and starts a Task
        //    new Task(() => { ... }) creates a task; use Start() to fire it
        // 2. Tasks take an optional 'object' argument
        //    Task.Factory.StartNew(x => { foo(x) }, arg);
        // 3. To return values, use Task<T> instead of Task
        //    To get the return value. use t.Result (this waits until task is complete)
        // 4. Use Task.CurrentId to identify individual tasks.

        //ways fo handling the parrall programming 
    }
}