using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OsDsII.api.Models;

namespace OsDsII.api.Repository
{
    public interface ICommentRepository
    {

        public Task<IActionResult> GetCommentsAsync(int serviceOrderId);

        public Task<IActionResult> AddComment(int serviceOrderId, Comment comment);
    }
}