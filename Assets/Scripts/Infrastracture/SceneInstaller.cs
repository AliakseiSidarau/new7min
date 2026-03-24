using Infrastracture.SaveLoad;
using Scenes.GamePlay;
using UnityEngine;
using Zenject;

namespace Infrastracture
{
    public class SceneInstaller: MonoInstaller
    {
        [SerializeField] private PlayerFacade _playerFacade;

        public override void InstallBindings()
        {
            Container.Bind<PlayerFacade>().FromInstance(_playerFacade).AsSingle();
            Container.BindInterfacesAndSelfTo<SaveLoadSystem>().AsSingle();
            Debug.Log("SceneInstaller Install");
        }
    }

    public class SaveLoadSystem: IInitializable
    {
        private readonly ISaveLoadService _saveLoad;
        public SaveLoadSystem(ISaveLoadService saveLoad)
        {
            _saveLoad = saveLoad;
        }

        public void Initialize()
        {
            
        }
    }
}