namespace DelegatesAndEvents
{
    public delegate int SumDelegate(int x, int y);

    public delegate string BroadcastDelegate(string message);

    public delegate string OtherBroadcastDelegate(string message);

    public delegate void BroadcastMessage(string message);

    internal class Program
    {
        static void Main(string[] args)
        {
            // (..parameters..) => { ... code ... }


            SumDelegate sumFunction = (a, b) => a + b;
            BroadcastMessage messageDelegate = message => Console.WriteLine(message);

            int sumResult = sumFunction(1, 2);
            Console.WriteLine(sumResult);
            

            int[] result1 = ArrayHelper.Sum(
                new[] { 1, 2, 3 },
                new[] { 4, 5, 6 },
                (a, b) => a + b);

            string[] result2 = ArrayHelper.Sum(
                new[] { "test", "other" },
                new[] { "1", "2" },
                (txt1, txt2) => string.Concat(txt1, txt2));

            BroadcastMessage messagePublisherDelegate = null;
            messagePublisherDelegate += BroadcastMessageReceived;
            messagePublisherDelegate("Test message (delegate)");

            Action<string> messagePublisherDelegate2 = BroadcastMessageReceived;
            messagePublisherDelegate2("Test message (action delegate)");

            MessagePublisher messagePublisherObject = new MessagePublisher();
            messagePublisherObject.OnMessageReceivedEvent += BroadcastMessageReceived;
            // messagePublisherObject.OnMessageReceivedDelegate += BroadcastMessageReceived;
            messagePublisherObject.SendMessage("Test message (event)");


            /*
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
            */
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

        private static void BroadcastMessageReceived(string mesasge)
        {
            Console.WriteLine($"Received broadcast message: {mesasge}");
        }
    }
}