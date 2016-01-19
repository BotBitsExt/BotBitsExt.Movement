using System;
using BotBits;
using JetBrains.Annotations;

namespace BotBitsExt.Movement.Extensions
{
    public static class DirectionExtensions
    {
        /// <summary>
        ///     Returns new direction by rotating clockwise provided direction.
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <returns></returns>
        [UsedImplicitly]
        public static Direction RotatedClockWise(this Direction direction)
        {
            var newDirection = direction;

            if (direction.HasFlag(Direction.Up))
            {
                if (direction == Direction.Up)
                    newDirection &= ~Direction.Up;
                newDirection |= Direction.Left;
                newDirection &= ~Direction.Right;
            }
            if (direction.HasFlag(Direction.Down))
            {
                if (direction == Direction.Down)
                    newDirection &= ~Direction.Down;
                newDirection |= Direction.Right;
                newDirection &= ~Direction.Left;
            }
            if (direction.HasFlag(Direction.Left))
            {
                if (direction == Direction.Left)
                    newDirection &= ~Direction.Left;
                newDirection |= Direction.Down;
                newDirection &= ~Direction.Up;
            }
            if (direction.HasFlag(Direction.Right))
            {
                if (direction == Direction.Right)
                    newDirection &= ~Direction.Right;
                newDirection |= Direction.Up;
                newDirection &= ~Direction.Down;
            }

            return newDirection;
        }

        /// <summary>
        ///     Returns new direction by flipping provided direction.
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <returns></returns>
        [UsedImplicitly]
        public static Direction Flipped(this Direction direction)
        {
            var newDirection = direction;

            if (direction.HasFlag(Direction.Up))
            {
                newDirection &= ~Direction.Up;
                newDirection |= Direction.Down;
            }
            if (direction.HasFlag(Direction.Down))
            {
                newDirection &= ~Direction.Down;
                newDirection |= Direction.Up;
            }
            if (direction.HasFlag(Direction.Left))
            {
                newDirection &= ~Direction.Left;
                newDirection |= Direction.Right;
            }
            if (direction.HasFlag(Direction.Right))
            {
                newDirection &= ~Direction.Right;
                newDirection |= Direction.Left;
            }

            return newDirection;
        }

        /// <summary>
        ///     Returns new direction by rotating counter clockwise provided
        ///     direction.
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <returns></returns>
        [UsedImplicitly]
        public static Direction RotatedCounterClockWise(this Direction direction)
        {
            var newDirection = direction;

            if (direction.HasFlag(Direction.Up))
            {
                if (direction == Direction.Up)
                    newDirection &= ~Direction.Up;
                newDirection |= Direction.Right;
                newDirection &= ~Direction.Left;
            }
            if (direction.HasFlag(Direction.Down))
            {
                if (direction == Direction.Down)
                    newDirection &= ~Direction.Down;
                newDirection |= Direction.Left;
                newDirection &= ~Direction.Right;
            }
            if (direction.HasFlag(Direction.Left))
            {
                if (direction == Direction.Left)
                    newDirection &= ~Direction.Left;
                newDirection |= Direction.Up;
                newDirection &= ~Direction.Down;
            }
            if (direction.HasFlag(Direction.Right))
            {
                if (direction == Direction.Right)
                    newDirection &= ~Direction.Right;
                newDirection |= Direction.Down;
                newDirection &= ~Direction.Up;
            }

            return newDirection;
        }

        /// <summary>
        ///     Returns new direction with performed portal transformation.
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <param name="sourcePortalMorph">The source portal morph.</param>
        /// <param name="targetPortalMorph">The target portal morph.</param>
        /// <exception cref="ArgumentException">The source or target morph is not a portal morph.</exception>
        [UsedImplicitly]
        public static Direction PerformPortalTransformation(this Direction direction, Morph.Id sourcePortalMorph,
            Morph.Id targetPortalMorph)
        {
            RequirePortalMorph(sourcePortalMorph, nameof(sourcePortalMorph));
            RequirePortalMorph(targetPortalMorph, nameof(targetPortalMorph));

            var source = (int) sourcePortalMorph;
            var target = (int) targetPortalMorph;

            // No transformation required if morphs are same for both portals
            if (source == target)
                return direction;

            if (source < target)
                source += 4;

            var dir = source - target;

            switch (dir)
            {
                case 1:
                    return direction.RotatedClockWise();
                case 2:
                    return direction.Flipped();
                case 3:
                    return direction.RotatedCounterClockWise();

                default:
                    return direction;
            }
        }

        /// <summary>
        ///     Determines whether direction is diagonal movement.
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <returns></returns>
        [UsedImplicitly]
        public static bool IsDiagonal(this Direction direction)
        {
            return (direction.HasFlag(Direction.Up) || direction.HasFlag(Direction.Down)) &&
                   (direction.HasFlag(Direction.Left) || direction.HasFlag(Direction.Right));
        }

        /// <summary>
        ///     Gets the vertical part of the direction.
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <returns></returns>
        [UsedImplicitly]
        public static Direction GetVertical(this Direction direction)
        {
            direction &= ~Direction.Left;
            direction &= ~Direction.Right;
            return direction;
        }

        /// <summary>
        ///     Gets the horizontal part of the direction.
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <returns></returns>
        [UsedImplicitly]
        public static Direction GetHorizontal(this Direction direction)
        {
            direction &= ~Direction.Up;
            direction &= ~Direction.Down;
            return direction;
        }

        private static void RequirePortalMorph(Morph.Id morph, string paramName)
        {
            switch (morph)
            {
                case Morph.Portal.Down:
                case Morph.Portal.Left:
                case Morph.Portal.Right:
                case Morph.Portal.Up:
                    break;

                default:
                    throw new ArgumentException("The given morph is not a portal morph.", paramName);
            }
        }
    }
}