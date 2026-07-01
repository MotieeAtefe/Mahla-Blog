using System;

namespace Mahla_Blog.CoreLayer.DTOs.Commands
{
    public class CommendDto
    {
        public int CommentId { get; set; }
        public string UserFullName { get; set; }
        public int PostId { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
