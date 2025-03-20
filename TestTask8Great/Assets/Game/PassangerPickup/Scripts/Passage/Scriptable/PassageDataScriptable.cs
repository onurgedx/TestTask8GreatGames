
using UnityEngine;

namespace PassengerPickup.Data
{
    [CreateAssetMenu(fileName = "PassageData", menuName = "ScriptableObjects/Passage", order = 1)]
    public class PassageDataScriptable : ScriptableObject
    {
        public PassageRawData[] PassagerRawDatas => _passageRawDatas;
        [SerializeField]
        private PassageRawData[] _passageRawDatas;
    }
}