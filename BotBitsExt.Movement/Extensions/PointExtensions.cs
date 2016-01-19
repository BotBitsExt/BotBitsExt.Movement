using BotBits;
using JetBrains.Annotations;

namespace BotBitsExt.Movement.Extensions
{
    public static class PointExtensions
    {
        /// <summary>
        ///     Moves the point in the specified direction.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="direction">The direction.</param>
        /// <param name="steps">The number of steps.</param>
        /// <returns></returns>
        [UsedImplicitly]
        public static Point MovedInDirection(this Point point, Direction direction, int steps = 1)
        {
            if (direction.HasFlag(Direction.Up))
                point.Y -= steps;
            if (direction.HasFlag(Direction.Down))
                point.Y += steps;
            if (direction.HasFlag(Direction.Left))
                point.X -= steps;
            if (direction.HasFlag(Direction.Right))
                point.X += steps;
            return point;
        }

        /// <summary>
        ///     Moves the point in direction relatively to the source direction.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="sourceDirection">The source direction.</param>
        /// <param name="direction">The direction.</param>
        /// <param name="steps">The steps.</param>
        /// <returns></returns>
        [UsedImplicitly]
        public static Point MovedRelativelyInDirection(this Point point, Direction sourceDirection, Direction direction,
            int steps = 1)
        {
            if (sourceDirection.HasFlag(Direction.Up))
            {
                point = point.MovedInDirection(direction, steps);
            }
            if (sourceDirection.HasFlag(Direction.Down))
            {
                point = point.MovedInDirection(direction.Flipped(), steps);
            }
            if (sourceDirection.HasFlag(Direction.Left))
            {
                point = point.MovedInDirection(direction.RotatedClockWise(), steps);
            }
            if (sourceDirection.HasFlag(Direction.Right))
            {
                point = point.MovedInDirection(direction.RotatedCounterClockWise(), steps);
            }
            return point;
        }
    }
}