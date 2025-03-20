using Common.PoolSys;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellPool : MonoBehaviour
{
    public Pool<Transform> Pool => _cellPool;
    [SerializeField] private Pool<Transform> _cellPool;
}
