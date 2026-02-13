using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Infrastracture
{
    public class BootstrapInitializeSystem : IInitializable
    {
        private ISaveService _saveService;

        public BootstrapInitializeSystem(ISaveService saveService)
        {
            _saveService = saveService;
        }
    
        public void Initialize()
        {
            _saveService.LoadSettingsData();
            _saveService.LoadPlayerData();
            SceneManager.LoadScene("1.Menu");
            Debug.Log("Initialized!");
        }
    }
}
