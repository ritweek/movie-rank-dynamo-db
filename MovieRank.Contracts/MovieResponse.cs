using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRank.Contracts
{
    public class MovieResponse
    {
        public string MovieName { get; set; }
        public string Description { get; set; }
        public List<string> Actors { get; set; }
        public int Rating { get; set; }
        public string RankDateTime { get; set; }
    }
}
