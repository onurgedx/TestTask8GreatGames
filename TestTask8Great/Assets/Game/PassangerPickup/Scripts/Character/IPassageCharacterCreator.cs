
using Common.ColorEnum;
using PassengerPickup.Gameplay.PassageSys;

namespace PassengerPickup.Gameplay.Cha
{
    public interface IPassageCharacterCreator
    {
        /// <summary>
        /// Creates passage-relative characters
        /// </summary>
        /// <param name="a_passage"></param>
        /// <param name="a_characterColorOrder"></param>
        public void CreatePassageCharacters(IPassage a_passage, ColorEnumeration[] a_characterColorOrder);
    }
}