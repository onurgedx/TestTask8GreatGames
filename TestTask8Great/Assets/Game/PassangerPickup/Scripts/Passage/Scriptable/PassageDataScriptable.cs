using UnityEngine;
namespace PassengerPickup.Data
{
    /// <summary>
    /// Passage Raw Data Container
    /// </summary>
    [CreateAssetMenu(fileName = "PassageData", menuName = "ScriptableObjects/Passage", order = 1)]
    public class PassageDataScriptable : ScriptableObject
    {
        /// <summary>
        /// Passage Raw Data Container
        /// </summary>
        public PassageRawData[] PassagerRawDatas => _passageRawDatas;
        [SerializeField]
        private PassageRawData[] _passageRawDatas;
    }
}