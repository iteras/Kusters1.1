using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Identity;
using Domain.Video;

namespace Web.ViewModels
{
    public class PlaylistViewModels
    {
        public UserInt UserInt { get; set; }
        public Playlist Playlist { get; set; }
        public SelectList UsersPlaylistsSelectlist { get; set; }
        public List<UserInt> AllUserInts { get; set; }
        public SelectList UserIntListSelectlist { get; set; }
    }
}