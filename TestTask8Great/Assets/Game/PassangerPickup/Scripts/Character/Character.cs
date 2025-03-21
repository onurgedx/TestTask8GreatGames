
using System;
using UnityEngine;

namespace PassengerPickup.Gameplay.Cha
{
    /// <summary>
    /// Character Logic
    /// </summary>
    public class Character
    {       

        public Action<Vector3>   OnRun;
        public Action<Transform>   OnJumpAndSit;

        public Character()
        {

        }

        public void RunToDestination(Vector3 a_destinationPos)
        {
            OnRun?.Invoke(a_destinationPos);
        }


        public void JumpToAndSit(Transform a_destinationTransform)
        {
            OnJumpAndSit?.Invoke(a_destinationTransform);
        }



    }
}