using GameForum.Models;
using GameForum.Repositories.Interfaces;
using GameForum.Services.Interfaces;

namespace GameForum.Services
{
    public class ReplyService:IReplyService
    {
        private readonly IRepositoryWrapper _repo;

        public ReplyService(IRepositoryWrapper repository)
        {
            _repo = repository;
        }

        public void AddReply(Reply reply)
        {
            _repo.ReplyRepository.Create(reply);
            _repo.Save();
        }
    }
}
