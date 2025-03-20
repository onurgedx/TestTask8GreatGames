using Common.PoolSys;
using UnityEngine;

namespace PassengerPickup.Pool
{

    public class PassagePool : MonoBehaviour
    {
        public Pool<Transform> Pool => _passagePool;
        [SerializeField] private Pool<Transform> _passagePool;
    }

}