
using System;
using System.Collections;
using UnityEngine;

namespace PassengerPickup.Gameplay.Cha
{
    public class CharacterMovementHandler
    {
        private static int k_speed=10;


        public Action OnRunStart;
        public Action OnRunEnd;
        public Action OnJumpStart;
        public Action OnJumpEnd;

        private MonoBehaviour _monoBehavior;        
        public CharacterMovementHandler(MonoBehaviour a_monoBehavior)
        {
            _monoBehavior = a_monoBehavior;
        }

        /// <summary>
        /// Moves To Destination Position
        /// </summary>
        /// <param name="a_destinationPosition"></param>
        public void RunToDestination(Vector3 a_destinationPosition)
        {
            _monoBehavior.StartCoroutine(run2Destination());


            IEnumerator run2Destination()
            {
                OnRunStart?.Invoke();

                Vector3 startPos = _monoBehavior.transform.position;

                float counter = 0;
                while(true)
                {
                    counter =Mathf.Clamp( counter+ Time.deltaTime * 10 , 0, 1.1f);
                   _monoBehavior.transform.position = Vector3.Lerp(startPos, a_destinationPosition, counter);
                    if(counter>=1){ break; }
                    yield return null;
                }

                OnRunEnd?.Invoke();
            }

        }


        /// <summary>
        /// Jumps to Destination Position
        /// </summary>
        /// <param name="a_destinationTransform"></param>
        public void JumpToDestination(Transform a_destinationTransform)
        {
            _monoBehavior.StartCoroutine(jumpToDestination());
            IEnumerator jumpToDestination()
            {
                OnJumpStart?.Invoke();
                yield return null;

                OnJumpEnd?.Invoke();
            }
        }

    }
}