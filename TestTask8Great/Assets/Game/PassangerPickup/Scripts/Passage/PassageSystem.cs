using Common.ColorEnum;
using PassengerPickup.Data;
using PassengerPickup.Gameplay.Cha;
using PassengerPickup.Pool;
using System;
using System.Collections.Generic;
using UnityEngine;
namespace PassengerPickup.Gameplay.PassageSys
{
     
    public class PassageSystem
    {
         
        private PassagePool _passagePool;

        private List<Passage> _passageList = new List<Passage>();

        private PassageRawData[] _passageRawDatas;

        

        public PassageSystem(PassagePool a_passagePool, PassageRawData[] a_passageRawDatas,IPassageCharacterCreator a_passagerCharacterCreator)
        {
            _passagePool = a_passagePool;
            _passageRawDatas = a_passageRawDatas;
            Create(a_passagerCharacterCreator);
        }


        /// <summary>
        /// Creates Passage and its highly relatives
        /// </summary>
        private void Create(IPassageCharacterCreator a_passagerCharacterCreator)
        {
            foreach (PassageRawData rawData in _passageRawDatas)
            {
                Passage passage = new Passage( rawData.CharacterColorOrder);                
                Transform passagetrnsfrmn = _passagePool.Pool.GetPoolMember();
                PassageBehavior passageBehavior = passagetrnsfrmn.GetComponent<PassageBehavior>();
                passagetrnsfrmn.position = rawData.CellPos.CellPositionToWorldPosition();                
                switch (rawData.Side)
                {
                    case Passage.PassageSide.Right:
                        passagetrnsfrmn.rotation = Quaternion.LookRotation(Vector3.left);
                        break;
                    case Passage.PassageSide.Left:
                        passagetrnsfrmn.rotation = Quaternion.LookRotation(Vector3.right);
                        break;
                    case Passage.PassageSide.Forward:
                        passagetrnsfrmn.rotation = Quaternion.LookRotation(Vector3.back);
                        break;
                    case Passage.PassageSide.Back:
                        passagetrnsfrmn.rotation = Quaternion.LookRotation(Vector3.forward);
                        break;
                }
                a_passagerCharacterCreator.CreatePassageCharacters(passage, rawData.CharacterColorOrder);

            }
        }
    }

}