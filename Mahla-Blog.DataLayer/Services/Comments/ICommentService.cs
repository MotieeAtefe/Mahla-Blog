using System.Collections.Generic;
using Mahla_Blog.CoreLayer.DTOs.Commands;
using Mahla_Blog.CoreLayer.Utilities;

namespace Mahla_Blog.CoreLayer.Services.Comments
{
    public interface ICommentService
    {
        List<CommendDto> getCommanList(int postID);
        OperationResult  createCommend(CreateCommendDto command);

    }
}