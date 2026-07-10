namespace Scenes.GamePlay
{
    public interface IPlayerService
    {
        void Register(PlayerFacade playerFacade);
        PlayerFacade PlayerFacade { get; }
    }
}