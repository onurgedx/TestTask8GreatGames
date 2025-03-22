using Common.ColorEnum;
using PassengerPickup.Gameplay.PassageSys;
using System.Collections.Generic;
using UnityEngine;
namespace PassengerPickup.Gameplay.Cha
{
    /// <summary>
    /// Manages Character Progress
    /// </summary>
    public class CharacterManager : IPassageCharacterCreator
    {

        private CharacterFactory _characterFactory;
        private Dictionary<IPassage, List<Character>> _characters = new();

        public CharacterManager(CharacterFactory a_characterFactory)
        {
            _characterFactory = a_characterFactory;
        }


        /// <summary>
        /// Creates passage-relative characters
        /// </summary>
        /// <param name="a_passage"></param>
        /// <param name="a_characterColorOrder"></param>
        public void CreatePassageCharacters(IPassage a_passage,ColorEnumeration[] a_characterColorOrder)
        {
            List<Character> chaList = new();
            foreach (ColorEnumeration color in a_characterColorOrder)
            {
                chaList.Add(_characterFactory.Create(color));
            } 
            _characters.Add(a_passage, chaList);
        } 

    }
}