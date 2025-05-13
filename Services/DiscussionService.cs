using GameForum.Models;
using GameForum.Repositories.Interfaces;
using GameForum.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameForum.Services
{
    public class DiscussionService : IDiscussionService
    {
        private readonly IRepositoryWrapper _repo;

        public DiscussionService(IRepositoryWrapper repository)
        {
            _repo = repository;
        }

        public void AddDiscussion(Discussion discussion)
        {
            _repo.DiscussionRepository.Create(discussion);
            _repo.Save();
        }

        public IEnumerable<Discussion> GetAll()
        {
            return _repo.DiscussionRepository
                .FindAll()
                .Include(d => d.Author)
                .ToList();
        }

        public Discussion GetById(int id)
        {
            return _repo.DiscussionRepository
                    .FindByCondition(d => d.Id == id)
                    .Include(d => d.Author)
                    .FirstOrDefault();
        }

        public IEnumerable<Discussion> GetDiscussionByGameId(int gameId)
        {
            return _repo.DiscussionRepository
                .FindByCondition(d => d.GameId == gameId)
                 .Include(d => d.Author) 
                .ToList();
        }

        public IEnumerable<Discussion> GetDiscussionByUserId(string userId)
        {
            return _repo.DiscussionRepository
                .FindByCondition(d => d.AuthorId == userId)
                .Include(d => d.Game)
                .ToList();
        }
    }
}
