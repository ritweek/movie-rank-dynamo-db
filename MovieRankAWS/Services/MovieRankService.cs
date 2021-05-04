using MovieRank.Contracts;
using MovieRankLibs.Mappers;
using MovieRankLibs.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieRankAWS.Services
{
    public class MovieRankService : IMovieRankService
    {
        private readonly IMovieRankRepository _movieRankRepository;
        private readonly IMapper _mapper;

        public MovieRankService(IMovieRankRepository movieRankRepository, IMapper mapper)
        {
            _movieRankRepository = movieRankRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MovieResponse>> GetAllItemsFromDatabase()
        {
            var response = await _movieRankRepository.GetAllItemsFromDatabase();
            return _mapper.ToMovieContract(response);
        }

        public async Task<MovieResponse> GetMovie(int userId, string movieName)
        {
            var response = await _movieRankRepository.GetMovie(userId, movieName);
            return _mapper.ToMovieContract(response);
        }

        public async Task AddMovie(int userId, MovieRankRequest movieRankRequest)
        {
            var movieDb =  _mapper.ToMovieContract(userId, movieRankRequest);

            await _movieRankRepository.AddMovie(movieDb);
        }
    }
}
