
using PassengerPickup.Gameplay.MovementSys;

namespace PassengerPickup.Gameplay.RollerCoast
{
    public class RollerCoasterManager
    {
        private MovementSystem _movementSystem;
         
        public RollerCoasterManager(MovementSystem a_movementSystem)
        {
            _movementSystem = a_movementSystem;
        }

    }
}