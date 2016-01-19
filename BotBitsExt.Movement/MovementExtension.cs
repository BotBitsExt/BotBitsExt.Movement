using BotBits;
using JetBrains.Annotations;

namespace BotBitsExt.Movement
{
    [UsedImplicitly]
    public sealed class MovementExtension : Extension<MovementExtension>
    {
        [UsedImplicitly]
        public static void LoadInto(BotBitsClient client)
        {
            LoadInto(client, null);
        }
    }
}