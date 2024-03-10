using System.Security.Cryptography.X509Certificates;

namespace ParallelProgramming.TaskPractise
{
    public static class TaskPractise
    {
        // first way Continuations
        public static List<int> AddFactors(int number)
        {
            Console.WriteLine(" begining the proccessing the task");
            var factors = new List<int>();
            int max = (int)Math.Sqrt(number);

            for (int factor = 1; factor <= max; ++factor) // Test from 1 to the square root, or the int below it, inclusive.
            {
                if (number % factor == 0)
                {
                    factors.Add(factor);
                    if (factor != number / factor) // Don't add the square root twice!
                        factors.Add(number / factor);
                }
            }
            return factors;
        }

        // second Child and Parent relation as when parent run the included child will also run
        public static void ChildAndParentRelation()
        {
            var parent = new Task(() =>
            {
                var child = new Task(() =>
                {
                    Console.WriteLine("Child task starting...");
                    Thread.Sleep(3000);
                    Console.WriteLine("Child task finished.");
                }, TaskCreationOptions.AttachedToParent);
                // handle case child failed
                var failHandler = child.ContinueWith(t =>
                {
                    Console.WriteLine($"Unfortunately, task {t.Id}'s state is {t.Status}");
                }, TaskContinuationOptions.AttachedToParent | TaskContinuationOptions.OnlyOnFaulted);
                // handle case child sucess
                var completionHandler = child.ContinueWith(t =>
                {
                    Console.WriteLine($"Hooray, task {t.Id}'s state is {t.Status}");
                }, TaskContinuationOptions.AttachedToParent | TaskContinuationOptions.OnlyOnRanToCompletion);
                child.Start();
                Console.WriteLine("Parent task starting...");
                Thread.Sleep(1000);
                Console.WriteLine("Parent task finished.");
            });

            parent.Start();
            try
            {
                parent.Wait();
            }
            catch (AggregateException ae)
            {
                ae.Handle(e => true);
            }

        }
        // another way to access shared resource used by multiple threads ( first way to have a way of locking on the shared resource )
        // second way to have thread local storage 
        public static void ThreadLocalStorage()
        {
            int sum = 0;
            Parallel.For(1, 101, () => 0,// initialize local state, show code completion for next arg
                (x, state, tls) =>
                {
                    //Console.WriteLine($"{Task.CurrentId}");
                    tls += x;
                    Console.WriteLine($"Task {Task.CurrentId} has sum {tls}");
                    return tls;
                },
                partialSum =>
                {
                    Console.WriteLine($"Partial value of task {Task.CurrentId} is {partialSum}");
                    Interlocked.Add(ref sum, partialSum);
                });
            Console.WriteLine($"Sum of 1..100 = {sum}");
        }

    }


}
