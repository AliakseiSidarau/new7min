using Infrastracture.SaveLoad;
using Infrastracture.SaveLoad.Data;
using Zenject.SpaceFighter;

namespace Scenes.GamePlay
{
    public class PlayerService: IPlayerService, ISaveLoad
    {
        private PlayerFacade _playerFacade;
        public void Register(PlayerFacade playerFacade)
        {
            _playerFacade = playerFacade;
        }

        public PlayerFacade PlayerFacade => _playerFacade;

        public void Save(PlayerProgress progress)
        {
            progress.PlayerData.CurrentHealth = _playerFacade.
        }

        public void Load(PlayerProgress progress)
        {
        }

        public void Reset(PlayerProgress progress)
        {
        }
    }
}