using BlogApi.Domain.Interfaces;
using BlogApi.Domain.Models;
using BlogApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.InfData.Repositories
{
    public class GetPostRepository : IGetPostRepository
    {
        private readonly BlogApiDbContext _context;

        public GetPostRepository(BlogApiDbContext context)
        {
            _context = context;
        }
        public async Task<List<Posts>> GetAllPostAsync()
        {
            return await _context.Posts.ToListAsync();
        }
    }
}
