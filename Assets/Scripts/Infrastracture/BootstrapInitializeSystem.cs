using DefaultNamespace;
using Scenes;
using Sound;
using UnityEngine;
using Zenject;

namespace Infrastracture
{
    public class BootstrapInitializeSystem : IInitializable
    {
        private ISaveService _saveService;
        private ISceneManagerService _sceneManagerService;

        public BootstrapInitializeSystem(ISaveService saveService, ISceneManagerService sceneManagerService)
        {
            _saveService = saveService;
            _sceneManagerService = sceneManagerService;
        }
    
        public void Initialize()
        {
            _saveService.LoadSettingsData();
            _saveService.LoadPlayerData();
            
            Debug.Log("Initialized!");
            _sceneManagerService.LoadMenuScene();

        }
    }
}
