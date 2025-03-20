using PassengerPickup.Data;
using PassengerPickup.Pool;
using System.Collections.Generic;
using UnityEngine;

namespace PassengerPickup.Gameplay.PassageSys
{

    public class PassageSystem
    {
        private PassagePool _passagePool;

        private List<Passage> _passageList = new List<Passage>();

        private PassageRawData[] _passageRawDatas;


        public PassageSystem(PassagePool a_passagePool, PassageRawData[] a_passageRawDatas)
        {
            _passagePool = a_passagePool;
        }


        private void Create()
        {
            foreach (PassageRawData rawData in _passageRawDatas)
            {
                Passage passage = new Passage(rawData.CellPos, rawData.Side, rawData.CharacterColorOrder);
                Transform passagetrnsfrmn = _passagePool.Pool.GetPoolMember();
                PassageBehavior passageBehavior = passagetrnsfrmn.GetComponent<PassageBehavior>();

            }

        }
    }

}