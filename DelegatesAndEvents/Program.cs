namespace DelegatesAndEvents
{
    public delegate int SumDelegate(int x, int y);

    public delegate string BroadcastDelegate(string message);

    public delegate string OtherBroadcastDelegate(string message);

    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            SumDelegate sumFunction = delegate (int a, int b)
            {
                return a + b;
            };

            int result = sumFunction(1, 2);
            Console.WriteLine(result);
            */

            BroadcastDelegate broadcaster = null;
            broadcaster += MessageReceiver2;
            broadcaster += MessageReceiver1;

            // Invoke all - get the result of latest
            if (broadcaster is not null)
            {
                string result = broadcaster("Hello world!");
                Console.WriteLine("Multicast result=" + result);
            }
            

            Console.WriteLine("After delegate detach");
            
            if (broadcaster is not null)
            {
                broadcaster -= MessageReceiver1;
                broadcaster("Hello world after detach!");
            }

            // Invole all (one by one) and get each result
            List<string> allResults = new List<string>();
            Delegate[] invocationList = broadcaster.GetInvocationList();
            foreach (Delegate method in invocationList)
            {
                string partialResult = method.DynamicInvoke("Hello world dynamic invoke!") as string;
                allResults.Add(partialResult);
            }

            Console.WriteLine("All invocations result=" + string.Join(", ", allResults));
        }

        private static int Dif(int a, int b)
        {
            return a - b;
        }

        private static string MessageReceiver1(string message)
        {
            string echo = $"Receiver1: {message}";
            Console.WriteLine(echo);
            return echo;

        }

        private static string MessageReceiver2(string message)
        {
            string echo = $"Receiver2: {message}";
            Console.WriteLine(echo);
            return echo;
        }
    }
}