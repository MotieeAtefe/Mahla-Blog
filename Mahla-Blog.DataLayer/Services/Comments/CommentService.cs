
using Mahla_Blog.CoreLayer.DTOs.Commands;
using Mahla_Blog.CoreLayer.Utilities;
using System.Collections.Generic;
using Mahla_Blog_DataLayer.Context;
using System.Linq;
using System.Net.Mime;
using Mahla_Blog_DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mahla_Blog.CoreLayer.Services.Comments
{
    public class CommentService : ICommentService
    {
        private readonly BlogContext _context;

        public CommentService(BlogContext context)
        {
            _context = context;
        }
        public OperationResult createCommend(CreateCommendDto command)
        {
            var result = new PostComment()
            {
                PostId = command.PostId,
                Text = command.Text,
                UserId = command.UserId
            };
            _context.Add(result);
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public List<CommendDto> getCommanList(int postID)
        {
            return
                _context.PostComment.Where(p => p.PostId == postID).
                Include(p => p.Users)
                .Select(command => new CommendDto()
                {
                    PostId = command.PostId,
                    Text = command.Text,
                    UserFullName = command.Users.FullName,
                    CommentId = command.Id,
                    CreationDate = command.CreationDate
                }).ToList();
        }
    }
}
