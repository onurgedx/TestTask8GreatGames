using Common.PoolSys;
using UnityEngine;

namespace PassengerPickup.Pool
{

    /// <summary>
    /// Pooling for passage
    /// </summary>
    public class PassagePool : MonoBehaviour
    {
        public Pool<Transform> Pool => _passagePool;
        [SerializeField] private Pool<Transform> _passagePool;
    }

}