using WebSocketSharp;

namespace ValheimWebSocket.Classes
{
    public class MessageDispatcher
    {
        public static void Dispatch(string[] args)
        {
            var subArgs = args.SubArray(1, args.Length - 1);

            switch (args[0])
            {
                case "raven":
                    RavenDispatcher.Dispatch(subArgs);
                    break;

                case "player":
                    PlayerDispatcher.Dispatch(subArgs);
                    break;
            }
        }
    }
}
