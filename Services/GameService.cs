using GameForum.Models;
using GameForum.Models.Enums;
using GameForum.Repositories.Interfaces;
using GameForum.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameForum.Services
{
    public class GameService : IGameService
    {
        private readonly IRepositoryWrapper _repo;
        public GameService(IRepositoryWrapper repo) {
            _repo = repo;
        }
        public IEnumerable<Game> GetAll() => _repo.GameRepository.FindAll();

        public Game GetById(int id)
        {
            return _repo.GameRepository
                        .FindByCondition(g => g.Id == id)
                        .FirstOrDefault();
        }

        public IEnumerable<Game> GetTop()
        {
            return _repo.GameRepository
                        .FindAll()
                        .OrderByDescending(g => g.AverageRating)
                        .Take(3)
                        .ToList();
        }

        public IEnumerable<Game> GetByCategory(GameCategory category)
        {
            return _repo.GameRepository
                .FindByCondition(g => g.GameCategories.Any(gc => gc.Category == category));
        }

        public IEnumerable<Game> GetAllWithCategories()
        {
            return _repo.GameRepository
                .FindAll()
                .Include(g => g.GameCategories);
        }

        public void AddGame(Game game) => _repo.GameRepository.Create(game);

        public Game GetByIdWithPosts(int id)
        {
            return _repo.GameRepository.GetByIdWithPosts(id);
        }
    }
}
