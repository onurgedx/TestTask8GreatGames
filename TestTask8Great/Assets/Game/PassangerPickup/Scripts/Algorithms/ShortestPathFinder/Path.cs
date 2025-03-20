using Common.CellSys; 
using System.Collections.Generic;
namespace PassengerPickup.Algorithms.PathFinder
{
    public class Path : IPath
    {

        private List<CellPosition> _nodeList;
        private int _currentCellPositionIndex = 0;
        private bool _isPathCompleted = false;


        public Path(List<CellPosition> a_nodeList)
        {
            _nodeList = a_nodeList;
        }


        public CellPosition NextCellPosition()
        {
            CellPosition currentCellPosition = _nodeList[_currentCellPositionIndex];
            if (_currentCellPositionIndex < _nodeList.Count - 1)
            {
                _currentCellPositionIndex++;
            }
            else
            {
                EndPath();
            }
            return currentCellPosition;
        }


        public bool IsPathCompleted()
        {
            return _isPathCompleted;
        }


        public void EndPath()
        {
            _isPathCompleted = true;
        }
    }
}