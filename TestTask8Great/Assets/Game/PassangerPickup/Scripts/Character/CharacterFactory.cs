
using Common.ColorEnum;

namespace PassengerPickup.Gameplay.Cha
{
    /// <summary>
    /// Creates Character According to Datas
    /// </summary>
    public class CharacterFactory
    {
        private CharacterPool _chaPool;
        public CharacterFactory(CharacterPool a_characterPool)
        {
            _chaPool = a_characterPool;
        }


        /// <summary>
        /// Creates Character and its highly relative actors , then link them each others
        /// </summary>
        /// <param name="a_chaColor"></param>
        /// <returns></returns>
        public Character Create(ColorEnumeration a_chaColor)
        {
            Character cha = new Character();
            switch (a_chaColor)
            {
                case ColorEnumeration.Red:
                    _chaPool.RedPool.GetPoolMember().GetComponent<CharacterBehavior>();
                    break;
                case ColorEnumeration.Orange:
                    _chaPool.OrangePool.GetPoolMember().GetComponent<CharacterBehavior>();
                    break;
                case ColorEnumeration.Blue:
                    _chaPool.BluePool.GetPoolMember().GetComponent<CharacterBehavior>();
                    break;
            }

            return cha;

        }

    }
}