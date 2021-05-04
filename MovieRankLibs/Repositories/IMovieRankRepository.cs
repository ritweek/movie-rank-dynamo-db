using MovieRankLibs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieRankLibs.Repositories
{
    public interface IMovieRankRepository
    {
        Task<IEnumerable<MovieDb>> GetAllItemsFromDatabase();
        Task<MovieDb> GetMovie(int userId, string movieName);
        Task AddMovie(MovieDb movieDb);
    }
}
