
using Common.ColorEnum;
using System;
namespace PassengerPickup.Gameplay.PassageSys
{
    
    public class Passage: IPassage
    {
        [Serializable]
        public enum PassageSide { Right, Left, Forward, Back };
        
        public Passage( ColorEnumeration[] a_characterColorOrder)
        {
            
        }

    }
}
