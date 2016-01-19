using BotBits;
using JetBrains.Annotations;

namespace BotBitsExt.Movement.Extensions
{
    public static class PlayerExtensions
    {
        private const string MovementDirection = "MovementDirection";
        private const string LastMovementDirection = "LastMovementDirection";

        internal static void SetMovementDirection(this Player player, Direction direction)
        {
            player.Set(MovementDirection, direction);

            if (direction != Direction.None)
            {
                player.Set(LastMovementDirection, direction);
            }
        }

        /// <summary>
        ///     Gets the current movement direction.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <returns></returns>
        public static Direction GetMovementDirection(this Player player)
        {
            return player.Get<Direction>(MovementDirection);
        }

        /// <summary>
        ///     Gets the last movement direction before player stopped moving
        ///     or current if the player is still moving.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <returns></returns>
        [UsedImplicitly]
        public static Direction GetLastMovementDirection(this Player player)
        {
            return player.Get<Direction>(LastMovementDirection);
        }
    }
}