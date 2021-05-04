using MovieRank.Contracts;
using MovieRankLibs.Models;
using System.Collections.Generic;

namespace MovieRankLibs.Mappers
{
    public interface IMapper
    {
        IEnumerable<MovieResponse> ToMovieContract(IEnumerable<MovieDb> items);
        MovieResponse ToMovieContract(MovieDb movie);
        MovieDb ToMovieContract(int userId, MovieRankRequest movieRankRequest);
    }
}
