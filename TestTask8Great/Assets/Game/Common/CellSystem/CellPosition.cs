using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Common.CellSys
{

    /// <summary>
    /// Define Position According To Board
    /// </summary>
    public struct CellPosition
    {
        /// <summary>
        ///  new CellPosition(1,0);
        /// </summary>
        public static CellPosition Right = new CellPosition(1, 0);
        /// <summary>
        /// new CellPosition(0,1);
        /// </summary>
        public static CellPosition Forward = new CellPosition(0, 1);
        /// <summary>
        /// new CellPosition(-1,0);
        /// </summary>
        public static CellPosition Left = new CellPosition(-1, 0);
        /// <summary>
        /// new CellPosition(0,-1);
        /// </summary>
        public static CellPosition Back = new CellPosition(0, -1);

        public int XPosition { get; private set; }
        public int YPosition { get; private set; }

        public CellPosition(int a_xPosition, int a_yPosition)
        {
            XPosition = a_xPosition;
            YPosition = a_yPosition;
        }

        public Vector3 CellPositionToWorldPosition()
        {
            return new Vector3(XPosition,0 , YPosition) * CellSystem.k_CellSize;
        }

        public override string ToString()
        {
            return "(" + XPosition.ToString() + "," + YPosition + ")";
        }

        public static bool operator ==(CellPosition pos1, CellPosition pos2) => (pos1.XPosition, pos1.YPosition) == (pos2.XPosition, pos2.YPosition);
        public static bool operator !=(CellPosition pos1, CellPosition pos2) => (pos1.XPosition, pos1.YPosition) != (pos2.XPosition, pos2.YPosition);

        public static CellPosition operator +(CellPosition pos1, CellPosition pos2) => new CellPosition(pos1.XPosition + pos2.XPosition, pos1.YPosition + pos2.YPosition);
        public static CellPosition operator -(CellPosition pos1, CellPosition pos2) => new CellPosition(pos1.XPosition - pos2.XPosition, pos1.YPosition - pos2.YPosition);

    }
}