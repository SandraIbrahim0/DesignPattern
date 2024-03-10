using System.Collections.Concurrent;

namespace ParallelProgramming.PLINQ
{
    public class PLINQ
    {
        //Motivation 1 : difference between PLinQ method ForAll and ForEach
        public static void ForAllExample()
        {
            ConcurrentBag<int> bag = new();
            var nums = Enumerable.Range(10, 10000);
            var query =
                from num in nums.AsParallel()
                where num % 10 == 0
                select num;

            // Process the results as each thread completes
            // and add them to a System.Collections.Concurrent.ConcurrentBag(Of Int)
            // which can safely accept concurrent add operations
            query.ForAll(e => bag.Add(Compute(e)));
        }

        private static int Compute(int e)
        {
            return _ = e + 1;
        }
        // ForAll: will do the compute per thread won't make the final step that the foreach did which is eumeration returing back to the thread of the calling one and summation of the result in it
        //However, foreach itself does not run in parallel, and therefore, it requires that the output from all parallel tasks be merged back into the thread on which the loop is running.
        //In PLINQ, you can use foreach when you must preserve the final ordering of the query results,

        // Motivation 2: Cancellation Token and Exception 
        public static void CancellationTokenAndExceptionExample()
        {
            var items = Enumerable.Range(1, 20);
            var cts = new CancellationTokenSource();
            var results = items.AsParallel().WithCancellation(cts.Token).Select(i =>
            {
            double result = Math.Log10(i);

            if (result > 1) throw new InvalidOperationException();

            Thread.Sleep((int)(result * 1000));
            Console.WriteLine($"i = {i}, tid = {Task.CurrentId}");
            return result;
            });

            try
            {
                foreach (var c in results)
                {
                    //if (c > 1)
                    //    cts.Cancel();
                    Console.WriteLine($"result = {c}");
                }
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine($"Canceled");
            }
            catch (AggregateException ae)
            {
                ae.Handle(e =>
                {
                    Console.WriteLine($"{e.GetType().Name}: {e.Message}");
                    return true;
                });
            }
        }
        // Motivation 3: Custom Aggregation Like Thread local storage
    }
}
