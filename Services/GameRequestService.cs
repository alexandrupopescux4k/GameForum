using GameForum.Models;
using GameForum.Repositories.Interfaces;
using GameForum.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameForum.Services
{
    public class GameRequestService : IGameRequestService
    {
        private readonly IRepositoryWrapper _repo;

        public GameRequestService(IRepositoryWrapper repository)
        {
            _repo = repository;
        }

        public void AddGame(GameRequest gameRequest) => _repo.GameRequestRepository.Create(gameRequest);

        public IEnumerable<GameRequest> GetAll()
        {
            return _repo.GameRequestRepository
            .FindAll()
             .Include(r => r.RequestedByUser)
                .Include(r => r.GameCategories)
                 .ToList();
        }
    }
}
