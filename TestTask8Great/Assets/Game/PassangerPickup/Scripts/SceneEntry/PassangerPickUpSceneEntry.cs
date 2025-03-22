using Common.CellSys;
using PassengerPickup.Algorithms.PathFinder;
using PassengerPickup.Data;
using PassengerPickup.Gameplay.Cha;
using PassengerPickup.Gameplay.MovementSys;
using PassengerPickup.Gameplay.PassageSys;
using PassengerPickup.Gameplay.RollerCoast;
using PassengerPickup.Pool;
using UnityEngine;

namespace PassengerPickup.Gameplay.SceneEntry
{

    /// <summary>
    /// SceneEntry for PassangerPickUp Scene
    /// </summary>
    public class PassangerPickUpSceneEntry : MonoBehaviour
    {
        public CellSystem CellSystem { get; private set; }
        public IPathFinder PathFinder;

        private RollerCoasterManager _rollerCoasterManager;
        private CharacterManager _chaManager;

        private PassageSystem _passageSystem;


        [SerializeField]
        private PassageDataScriptable _passageDatas;


        [SerializeField]
        private CellPool _cellPool;

        [SerializeField]
        private PassagePool _passagePool;

        [SerializeField]
        private CharacterPool _chaPool;

        [SerializeField] private MovementSystem _movementSystem;

        void Start()
        {
            CellSystem = new CellSystem(_cellPool, 4, 4);
            PathFinder = new AStarPathFinder(CellSystem);
            

            CharacterFactory chaFactory = new CharacterFactory(_chaPool);
            _chaManager = new CharacterManager(chaFactory);

            _passageSystem = new PassageSystem(_passagePool, _passageDatas.PassagerRawDatas, _chaManager);
            _rollerCoasterManager = new RollerCoasterManager(_movementSystem);

        }

        void Update()
        {

        }
    }

}