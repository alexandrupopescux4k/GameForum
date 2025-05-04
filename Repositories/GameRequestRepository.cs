using GameForum.Data;
using GameForum.Models;
using GameForum.Repositories.Interfaces;

namespace GameForum.Repositories
{
    public class GameRequestRepository : RepositoryBase<GameRequest>, IGameRequestRepository
    {
        public GameRequestRepository(GameForumContext gameforumContext) : base(gameforumContext)
        {
        }
    }
}
