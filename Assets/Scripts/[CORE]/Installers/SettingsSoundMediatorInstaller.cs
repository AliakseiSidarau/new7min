using Settings;
using Zenject;

namespace Infrastracture
{
    public class SettingsSoundMediatorInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SettingsController>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<SettingsSoundMediator>()
                .AsSingle();
        }
    }
}