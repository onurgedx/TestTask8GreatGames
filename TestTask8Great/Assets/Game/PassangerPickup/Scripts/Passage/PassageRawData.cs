
using Common.CellSys;
using Common.ColorEnum;
using PassengerPickup.Gameplay.PassageSys;
using System;
using UnityEngine;
namespace PassengerPickup.Data
{

    /// <summary>
    /// Passage Initial Datas
    /// </summary>
    [Serializable]
    public struct PassageRawData
    {
        /// <summary>
        /// Shows the side on which the passage stay
        /// </summary>
        public Passage.PassageSide Side => _side;
        [SerializeField]
        private Passage.PassageSide _side;


        /// <summary>
        /// Indicates the cell position of the passage.
        /// </summary>
        public CellPosition CellPos => new CellPosition(_cellPosition.x, _cellPosition.y);
        [SerializeField]
        private Vector2Int _cellPosition;
        

        /// <summary>
        /// Color Enumeration 
        /// </summary>
        public ColorEnumeration[] CharacterColorOrder => _characterColorOrder;
        [SerializeField]
        private ColorEnumeration[] _characterColorOrder;

    }

}