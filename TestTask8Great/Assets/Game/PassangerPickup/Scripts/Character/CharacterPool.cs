using Common.PoolSys; 
using UnityEngine;

public class CharacterPool : MonoBehaviour
{
    public Pool<Transform> BluePool => _chaBluePool;
    [SerializeField] private Pool<Transform> _chaBluePool;

    public Pool<Transform> RedPool => _chaRedPool;
    [SerializeField] private Pool<Transform> _chaRedPool;

    public Pool<Transform> OrangePool => _chaOrangePool;
    [SerializeField] private Pool<Transform> _chaOrangePool;

}
