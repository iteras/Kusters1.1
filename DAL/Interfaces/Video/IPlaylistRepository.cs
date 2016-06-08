using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Identity;
using Domain.Video;

namespace DAL.Interfaces
{
    public interface IPlaylistRepository : IEFRepository<Playlist>
    {

        List<Playlist> GetAllPlaylistsForUser(int userIntId); //should work, maybe ID is enough
    }
}
