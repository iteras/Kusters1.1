using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain.Video;

namespace DAL.Repositories
{
    public class PlaylistRepository : EFRepository<Playlist>, IPlaylistRepository
    {
        public PlaylistRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
