using Common.CellSys; 
namespace PassengerPickup.Algorithms.PathFinder
{
    public interface IPath
    {

        /// <summary>
        /// Returns Cell position which next to go
        /// </summary>
        /// <returns></returns>
        public CellPosition NextCellPosition();



        /// <summary>
        /// Returns is path completed or not
        /// </summary>
        /// <returns></returns>
        public bool IsPathCompleted();


        /// <summary>
        /// Finishes the path and 
        /// </summary>
        public void EndPath();
    }
}