using System.Threading;

namespace ParallelProgramming
{
    // motivation problem that bank balance can deposite and withdraw in different thread which lead to wrong number in the balance 
    //Solution to lock the balance in order to let one thread only makes the changes
    public class SharedResourceSolutions
    {
        public int Balance { get; set; }

        // 1-lock the resource mechansim in Exclusive locking 
        public object lockPad = new();
        // 2-mutex is similar to the lock but with key 
        Mutex mutex = new Mutex(false, "key");

        public void Deposite(int amount)
        {
            lock (lockPad)
            {
                Balance += amount;
            }

            if (mutex.WaitOne())
            {
                try
                {

                    Balance += amount;
                }
                finally
                {
                    mutex.ReleaseMutex();
                }
            }
        }
        public void WithDraw(int amount)
        {
            lock (lockPad)
            {
                Balance -= amount;
            }
        }
    }

    public class SharedResource
    {
        private Mutex mutex = new();
        public void AccessResource(int personNumber)
        {
            mutex.WaitOne();
            Console.WriteLine($"Person {personNumber} entered the room");
            Thread.Sleep(1000);
            Console.WriteLine($"Person {personNumber} left the room");
            mutex.ReleaseMutex();

        }
    }
    // trying to requesting the lock so CPU is running 
    public class RequestingResource
    {
        private SpinLock spinLock = new();
        public void RequestResource(int personNumber)
        {
            bool lockTaken = false;
            try
            {
                spinLock.Enter(ref lockTaken);
                Console.WriteLine($"Person {personNumber} is requesting the resource");
                Thread.Sleep(1000);
                Console.WriteLine($"Person {personNumber} has the resource");
            }
            finally
            {
                if (lockTaken)
                    spinLock.Exit();
            }
        

        }
    }

    public class SemaphoreSolution
    {
        private Semaphore semaphore = new Semaphore(2,2);
        
        public void AccessResource(int personNumber)
        { 
            semaphore.WaitOne();
            Console.WriteLine($"Person {personNumber} entered the room");
            Thread.Sleep(1000);
            Console.WriteLine($"Person {personNumber} left the room");
            semaphore.Release();

        }
    }
}
