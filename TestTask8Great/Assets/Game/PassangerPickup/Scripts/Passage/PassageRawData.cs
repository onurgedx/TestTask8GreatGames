
using Common.CellSys;
using Common.ColorEnum;
using PassengerPickup.Gameplay.PassageSys;
using System;
using UnityEngine;
namespace PassengerPickup.Data
{

    [Serializable]
    public struct PassageRawData
    {
        public Passage.PassageSide Side => _side;
        [SerializeField]
        private Passage.PassageSide _side;


        public CellPosition CellPos => new CellPosition(_cellPosition.x, _cellPosition.y);
        [SerializeField]
        private Vector2Int _cellPosition;


        public ColorEnumeration[] CharacterColorOrder => _characterColorOrder;
        [SerializeField]
        private ColorEnumeration[] _characterColorOrder;

    }

}