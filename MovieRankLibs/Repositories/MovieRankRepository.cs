using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using MovieRankLibs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieRankLibs.Repositories
{
    public class MovieRankRepository : IMovieRankRepository
    {
        private readonly DynamoDBContext _dynamoDBContext;

        public MovieRankRepository(IAmazonDynamoDB amazonDynamoDB)
        {
            _dynamoDBContext = new DynamoDBContext(amazonDynamoDB);
        }

        public async Task AddMovie(MovieDb movieDb)
        {
            await _dynamoDBContext.SaveAsync(movieDb);
        }

        public async Task<IEnumerable<MovieDb>> GetAllItemsFromDatabase()
        {
            return await _dynamoDBContext.ScanAsync<MovieDb>(new List<ScanCondition>()).GetRemainingAsync();
        }

        public async Task<MovieDb> GetMovie(int userId, string movieName)
        {
            return await _dynamoDBContext.LoadAsync<MovieDb>(userId, movieName);
        }


    }
}
