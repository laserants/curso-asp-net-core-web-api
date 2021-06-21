using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Core.Entities
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        [Column("imdb_id")]
        public string ImdbId { get; set; }
        public string Rating { get; set; }
        public string Genres { get; set; }
        public int RunTime { get; set; }
        public string Country { get; set; }
        public string Language { get; set; }
        [Column("imdb_score")]
        public double ImdbScore { get; set; }
        [Column("imdb_votes")]
        public int ImdbVotes { get; set; }
        [Column("metacritic_score")]
        public int MetacriticScore { get; set; }
    }
}
