using Demo.Entity;
using Demo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Facade
{
    public class CommentFacade : Facade<Entity.Comment>
    {
        CommentRepository commentRepository = null;
        public CommentFacade(DataContext dataContext) : base(dataContext)
        {
            commentRepository = new CommentRepository(dataContext);
        }

        public List<Comment> GetAllCommentsByPostId(Guid PostId)
        {
            return commentRepository.GetAllCommentsByPostId(PostId);
        }

    }
}
