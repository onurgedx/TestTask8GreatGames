using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common.CellSys
{
    public class CellSystem : MonoBehaviour
    {
        public Dictionary<CellPosition, Cell> CellDictionary => _cellDictionary;
        private Dictionary<CellPosition, Cell> _cellDictionary = new();
        public static float k_CellSize { get; private set; }
        public CellLayout CellLayout { get; private set; }

        public CellSystem(CellPool a_cellPool,int a_xCellCount, int a_yCellCount)
        {
            k_CellSize = a_cellPool.Pool.PoolPrefab.GetComponent<MeshRenderer>().bounds.size.x;                         
            CellLayout = new CellLayout(a_xCellCount, a_xCellCount);
            CreateCells(CellLayout, a_cellPool);
        }


        /// <summary>
        /// Creates cells according to main cell layout
        /// </summary>
        /// <param name="a_cellLayout">CellLayout</param>
        private void CreateCells(CellLayout a_cellLayout, CellPool a_cellPool)
        {
            int xAxisOffsett = a_cellLayout.Axis1CellCount / 2;
            int yAxisOffsett = a_cellLayout.Axis2CellCount / 2;
            for (int axis1 = 0; axis1 < a_cellLayout.Axis1CellCount; axis1++)
            {
                for (int axis2 = 0; axis2 < a_cellLayout.Axis2CellCount; axis2++)
                {
                    CellPosition position = new CellPosition(axis1 - xAxisOffsett, axis2 - yAxisOffsett);
                    GameObject cellGameObject = a_cellPool.Pool.GetPoolMember(a_cellPool.transform).gameObject;
                    Cell cell = new Cell(position, cellGameObject);
                    
                    _cellDictionary.Add(position, cell);
                }
            }
        }


        /// <summary>
        /// Returns true if cell is suitable for occupier
        /// </summary>
        /// <param name="a_cellPosition"> Demand Position of Occupier </param>
        /// <param name="a_occupier">Occupier</param>
        /// <returns></returns>
        public bool IsCellPropperToOccupy(CellPosition a_cellPosition )
        {
            if (_cellDictionary.TryGetValue(a_cellPosition, out Cell cell))
            {
                if (!cell.CanOccupy()) { return false; }
            }
            else
            {
                return false;
            }
            return true;
        }


        public void TryOccupy(  params CellPosition[] a_cellPositions)
        {
            List<Cell> cellList = new List<Cell>();
            foreach (CellPosition cellPosition in a_cellPositions)
            {
                if (_cellDictionary.TryGetValue(cellPosition, out Cell cell))
                {
                    if (cell.CanOccupy())
                    {
                        cellList.Add(cell);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            foreach (Cell cell1 in cellList)
            {
                cell1.Occupy( );
            }
        }


        public void Unoccupy(CellPosition a_cellPosition)
        {
            if (_cellDictionary.TryGetValue(a_cellPosition, out Cell cell))
            {
                cell.Unoccupy( );
            }
        }


        /// <summary>
        /// Converts given <paramref name="a_worldPosition"/> to cell position
        /// </summary>
        /// <param name="a_worldPosition"></param>
        /// <returns></returns>
        public static CellPosition WorldPositionToCellPosition(Vector3 a_worldPosition)
        {
            CellPosition cellPosition = new CellPosition(Mathf.FloorToInt((a_worldPosition / k_CellSize).x + k_CellSize * 0.5f), Mathf.FloorToInt((a_worldPosition / k_CellSize).y + k_CellSize * 0.5f));
            return cellPosition;
        }
    }
}