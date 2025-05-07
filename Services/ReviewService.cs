using Microsoft.EntityFrameworkCore;
using GameForum.Models;
using GameForum.Repositories.Interfaces;
using GameForum.Services.Interfaces;

namespace GameForum.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IRepositoryWrapper _repo;
        
        public ReviewService(IRepositoryWrapper repository)
        {
            _repo = repository;
        }

        public void AddReview(Review review)
        {
            _repo.ReviewRepository.Create(review);
            _repo.Save();
        }

        public IEnumerable<Review> GetAll() => _repo.ReviewRepository.FindAll();

        public Review GetById(int id)
        {
          return _repo.ReviewRepository.FindByCondition(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Review> GetReviewsByGameId(int gameId)
        {
            return _repo.ReviewRepository.FindByCondition(r => r.GameId == gameId).ToList();
        }

        public IEnumerable<Review> GetReviewsByUserId(string userId)
        {
           return _repo.ReviewRepository.FindByCondition(x => x.AuthorId == userId).ToList();
        }

        public IEnumerable<Review> GetTop()
        {
            return _repo.ReviewRepository
             .FindAll()
              .Include(r => r.Game)
                 .Include(r => r.Author)
                 .OrderByDescending(x => x.Upvotes + x.Downvotes)
                 .Take(3)
                 .ToList();
        }
    }
}
