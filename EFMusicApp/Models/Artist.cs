using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFMusicApp.Models
{
    class Artist
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int YearStarted { get; set; }
        public List<Album> Albums { get; set; }



    }
}
