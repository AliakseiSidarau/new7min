using Zenject;

namespace Infrastracture
{
    public class BootSystemInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SaveLoadInitSystem>().AsSingle();
        }
    }
}