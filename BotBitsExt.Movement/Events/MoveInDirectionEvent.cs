using BotBits;
using JetBrains.Annotations;

namespace BotBitsExt.Movement.Events
{
    public sealed class MoveInDirectionEvent : Event<MoveInDirectionEvent>
    {
        internal MoveInDirectionEvent(Player player, Direction direction)
        {
            Player = player;
            Direction = direction;
        }

        /// <summary>
        ///     Gets the player.
        /// </summary>
        /// <value>
        ///     The player.
        /// </value>
        [UsedImplicitly]
        public Player Player { get; }

        /// <summary>
        ///     Gets the movement direction.
        /// </summary>
        /// <value>
        ///     The direction.
        /// </value>
        [UsedImplicitly]
        public Direction Direction { get; }
    }
}