using UnityEngine;
using Zenject;

namespace Scenes.GamePlay
{
    public class PlayerFacade: MonoBehaviour
    {
        [SerializeField] private PlayerHealth _playerHealth;
        private IPlayerService _playerService;
        

        public PlayerHealth PlayerHealth => _playerHealth;
        
        //[Inject]

        public void Construct(IPlayerService playerService)
        {
            _playerService = playerService;
        }
        
    }
}