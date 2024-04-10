using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OsDsII.api.Data;
using OsDsII.api.Models;

namespace OsDsII.api.Repository
{
    public class CommentRepository
    {
        // DI DATA CONTEXT

        private readonly DataContext _dataContext; 

        public CommentRepository(DataContext datacontext) 
        {
            _dataContext = datacontext;
        }

        public async Task<IActionResult> GetCommentsAsync()
        {
            return (IActionResult)await _dataContext.Comments.ToListAsync();
        }

        public async Task AddAsync(int serviceOrderId, Comment comment)
        {
            await _dataContext.Comments.AddAsync(comment);
            await _dataContext.SaveChangesAsync();
        }

    }
}
