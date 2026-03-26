using DefaultNamespace;
using Scenes;
using Sound;
using UnityEngine;
using Zenject;

namespace Infrastracture
{
    public class BootstrapInitializeSystem : IInitializable
    {
        private ISceneManagerService _sceneManagerService;

        public BootstrapInitializeSystem(ISceneManagerService sceneManagerService)
        {
            _sceneManagerService = sceneManagerService;
        }
    
        public void Initialize()
        {
            Debug.Log("Initialized!");
            _sceneManagerService.LoadMenuScene();
        }
    }
}
