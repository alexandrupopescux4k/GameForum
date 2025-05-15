using GameForum.Models;

namespace GameForum.Services.Interfaces
{
    public interface IGameRequestService

    {
        IEnumerable<GameRequest> GetAll();
    }
}
