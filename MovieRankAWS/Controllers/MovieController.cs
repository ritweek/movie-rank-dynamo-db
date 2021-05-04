﻿using Microsoft.AspNetCore.Mvc;
using MovieRank.Contracts;
using MovieRankAWS.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieRankAWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRankService _movieRankService;

        public MovieController(IMovieRankService movieRankService)
        {
            _movieRankService = movieRankService;
        }

        [HttpGet]
        public async Task<IEnumerable<MovieResponse>> GetAllItemsFromDatabase() 
        {
            var results = await _movieRankService.GetAllItemsFromDatabase();
            return results;
        }

        [HttpGet]
        [Route("{userId}/{movieName}")]
        public async Task<MovieResponse> GetMovie(int userId , string movieName)
        {
            var result = await _movieRankService.GetMovie(userId, movieName);
            return result;
        }

        [HttpPost]
        [Route("{userId}")]
        public async Task<IActionResult> AddMovie(int userId, [FromBody] MovieRankRequest movieRankRequest)
        {
            await _movieRankService.AddMovie(userId, movieRankRequest);
            return Ok();
        }
    }
}
