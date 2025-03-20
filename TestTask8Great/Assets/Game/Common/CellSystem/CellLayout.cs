namespace Common.CellSys
{
    /// <summary>
    /// Contains Cell Structure informations
    /// </summary>
    public struct CellLayout
    {
        public int Axis1CellCount { get; private set; }
        public int Axis2CellCount { get; private set; }

        public CellLayout(int a_axis1CellCount, int a_axis2CellCount)
        {
            Axis1CellCount = a_axis1CellCount;
            Axis2CellCount = a_axis2CellCount;
        }
    }
}