
using Common.CellSys;
using Common.ColorEnum;
using System;
namespace PassengerPickup.Gameplay.PassageSys
{
    public class Passage
    {

        [Serializable]
        public enum PassageSide { Right, Left, Forward, Back };
        public PassageSide Side { get; private set; }

        public Passage(CellPosition a_cellPosition, PassageSide a_passageSide, ColorEnumeration[] a_characterColorOrder)
        {
            Side = a_passageSide;

        }

    }
}
