using UnityEngine;
namespace PassengerPickup.Gameplay.Cha
{
    /// <summary>
    /// Character View
    /// </summary>
    public class CharacterBehavior : MonoBehaviour
    { 
        private CharacterAnimatorHandler _characterAnimatorHandler;
        private CharacterMovementHandler _characterMovementHandler;


        private void Start()
        {
            Animator animator = GetComponent<Animator>();
            _characterAnimatorHandler = new CharacterAnimatorHandler(animator);
            _characterMovementHandler = new CharacterMovementHandler(this);

            _characterMovementHandler.OnRunStart += _characterAnimatorHandler.AnimateRun;
            _characterMovementHandler.OnRunEnd += _characterAnimatorHandler.AnimateIdle;
            _characterMovementHandler.OnJumpEnd+= _characterAnimatorHandler.AnimateSit;
        }

        /// <summary>
        /// Run Process
        /// </summary>
        /// <param name="a_destination"></param>
        public void Run(Vector3 a_destination)
        {
            _characterMovementHandler.RunToDestination(a_destination);
        }

        /// <summary>
        /// Jump And Sit Progress
        /// </summary>
        /// <param name="a_destinationTransform"></param>
        public void JumpAndSit(Transform a_destinationTransform)
        {
            _characterMovementHandler.JumpToDestination(a_destinationTransform);
        }
    }
}