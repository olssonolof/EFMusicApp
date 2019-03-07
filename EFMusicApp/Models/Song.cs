using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFMusicApp.Models
{
    class Song
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }
        public int TrackNumber { get; set; }
        public bool HasMusicVideo { get; set; }
        public string Lyrics { get; set; }
        public Album Albums { get; set; }

    }
}
