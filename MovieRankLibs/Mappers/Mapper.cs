using MovieRank.Contracts;
using MovieRankLibs.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieRankLibs.Mappers
{
    public class Mapper : IMapper
    {
        public IEnumerable<MovieResponse> ToMovieContract(IEnumerable<MovieDb> items)
        {
            return items.Select(ToMovieContract);
        }

        public MovieResponse ToMovieContract(MovieDb movie)
        {
            return new MovieResponse
            {
                MovieName = movie.MovieName,
                Actors = movie.Actors,
                Description = movie.Description,
                Rating = movie.Ranking,
                RankDateTime = movie.RankDateTime

            };
        }

        public MovieDb ToMovieContract(int userId , MovieRankRequest movieRankRequest)
        {
            return new MovieDb
            {
                UserId = userId,
                MovieName = movieRankRequest.MovieName,
                Description = movieRankRequest.Description,
                Ranking = movieRankRequest.Ranking,
                Actors = movieRankRequest.Actors,
                RankDateTime = System.DateTime.UtcNow.ToString()
            };
        }
    }
}
