
using Common.CellSys;

namespace PassengerPickup.Algorithms.PathFinder
{
    public interface IPathFinder
    {
        public Path FindPath(CellPosition a_startCellPosition, CellPosition a_destinationCellPosition);
    }
}