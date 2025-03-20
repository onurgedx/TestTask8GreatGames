using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Common.CellSys
{
    public class Cell
    {
        public CellPosition CellPosition { get; private set; }
        private GameObject _cellGameObject;
        private bool _occupied=false;
        public Cell(CellPosition a_cellPosition, GameObject a_cellGameObject)
        {
            CellPosition = a_cellPosition;
            _cellGameObject = a_cellGameObject;
            _cellGameObject.transform.position = a_cellPosition.CellPositionToWorldPosition();
        }

        public bool CanOccupy( )
        {           
            return !_occupied;
        }

        public void Occupy()
        {
            _occupied = true;
        }

        public void Unoccupy()
        {
            _occupied = false;
        }
    }
}