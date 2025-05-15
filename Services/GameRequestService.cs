using GameForum.Models;
using GameForum.Repositories.Interfaces;
using GameForum.Services.Interfaces;

namespace GameForum.Services
{
    public class GameRequestService : IGameRequestService
    {
        private readonly IRepositoryWrapper _repo;

        public GameRequestService(IRepositoryWrapper repository)
        {
            _repo = repository;
        }
        public IEnumerable<GameRequest> GetAll()
        {
            return _repo.GameRequestRepository.FindAll().ToList();
        }
    }
}
