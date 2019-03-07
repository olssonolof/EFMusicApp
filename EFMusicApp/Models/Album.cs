using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFMusicApp.Models
{
    class Album
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseDate { get; set; }
        public List<Song> Songs { get; set; }
        public Artist Artists { get; set; }

    }
}
