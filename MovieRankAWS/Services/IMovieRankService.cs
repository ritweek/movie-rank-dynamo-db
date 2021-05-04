using MovieRank.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieRankAWS.Services
{
    public interface IMovieRankService
    {
        Task<IEnumerable<MovieResponse>> GetAllItemsFromDatabase();
        Task<MovieResponse> GetMovie(int userId, string movieName);
        Task AddMovie(int userId, MovieRankRequest movieRankRequest);
    }
}
