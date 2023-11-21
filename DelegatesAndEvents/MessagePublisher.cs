using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    internal class MessagePublisher
    {
        private event BroadcastMessage onMessageReceivedEvent;

        public event BroadcastMessage OnMessageReceivedEvent
        {
            add { onMessageReceivedEvent += value; }
            remove { onMessageReceivedEvent -= value; }
        }

        // public BroadcastMessage OnMessageReceivedDelegate;

        public void SendMessage(string message)
        {
            // NOT recommended
            // OnMessageReceivedEvent(message);

            // Recommended (#1)
            onMessageReceivedEvent?.Invoke(message);

            // Recommended (#2 - old school)
            /*
            BroadcastMessage handlers = OnMessageReceivedEvent;
            if (handlers is not null)
            {
                handlers(message);
            }
            */
        }
    }
}
