using UnityEngine;

namespace PassengerPickup.Gameplay.Cha
{
    public class CharacterAnimatorHandler  
    {
        private static readonly int Run = Animator.StringToHash(nameof(Run));
        private static readonly int Sit = Animator.StringToHash(nameof(Sit));
         
        private Animator _animator;

        public CharacterAnimatorHandler(Animator a_animator)
        {
            _animator = a_animator;
        }

        /// <summary>
        /// Run animation works
        /// </summary>
        public void AnimateRun()
        {
            _animator.SetBool(Run, true);
        }

        /// <summary>
        /// IdleAnimation works
        /// </summary>
        public void AnimateIdle()
        {
            _animator.SetBool(Run, false);
        }

        /// <summary>
        /// Sit Animation works
        /// </summary>
        public void AnimateSit()
        {
            _animator.SetTrigger(Sit);
        }

    }
}