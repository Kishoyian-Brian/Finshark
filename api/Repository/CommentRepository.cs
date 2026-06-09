using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;



namespace api.Repository

{
    public class CommentRepository : IcommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Comments>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }
    }
}