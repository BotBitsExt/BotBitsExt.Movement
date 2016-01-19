using BotBits;
using BotBits.Events;
using BotBitsExt.Movement.Events;
using BotBitsExt.Movement.Extensions;

namespace BotBitsExt.Movement
{
    public sealed class MovementService : EventListenerPackage<MovementService>
    {
        [EventListener]
        private void On(MoveEvent e)
        {
            var direction = GetDirection((int) e.Vertical, (int) e.Horizontal);
            if (direction != e.Player.GetMovementDirection())
            {
                e.Player.SetMovementDirection(direction);
                new MoveInDirectionEvent(e.Player, direction).RaiseIn(BotBits);
            }
        }

        private static Direction GetDirection(int vertical, int horizontal)
        {
            var direction = Direction.None;

            switch (vertical)
            {
                case -1:
                    direction |= Direction.Up;
                    break;
                case 1:
                    direction |= Direction.Down;
                    break;
            }

            switch (horizontal)
            {
                case -1:
                    direction |= Direction.Left;
                    break;
                case 1:
                    direction |= Direction.Right;
                    break;
            }

            return direction;
        }
    }
}