using System;
using System.Collections.Generic;
using UnityEngine;

namespace Common.PoolSys
{

    /// <summary>
    /// Pool For Object Pooling
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class Pool<T> where T : Component
    {
        public T PoolPrefab;
        private List<T> _poolList = new List<T>();


        /// <summary>
        /// Return a <typeparamref name="T"/> from Pool
        /// </summary>
        /// <param name="a_parent">Parent transform of pool objects</param>
        /// <returns></returns>
        public T GetPoolMember(Transform a_parent = default)
        {

            for (int i = 0; i < _poolList.Count; i++)
            {
                if (!_poolList[i].gameObject.activeInHierarchy)
                {
                    _poolList[i].gameObject.SetActive(true);
                    return _poolList[i];
                }
            }
            GameObject newPoolMembersGameObject = UnityEngine.Object.Instantiate(PoolPrefab.gameObject, a_parent);
            T newPoolMember = newPoolMembersGameObject.GetComponent<T>();
            _poolList.Add(newPoolMember);
            newPoolMembersGameObject.SetActive(true);
            return newPoolMember;
        }


        /// <summary>
        /// Makes All Pool members' gameobject is disable
        /// </summary>
        public void DeactivateAll()
        {
            for (int i = 0; i < _poolList.Count; i++)
            {
                _poolList[i].gameObject.SetActive(false);
            }
        }
    }
}