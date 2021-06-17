using Demo.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Repository
{
    public class CommentRepository : Repository<Comment>
    {
        DataContext context = null;
        public CommentRepository(DataContext dataContext) : base(dataContext)
        {
            this.context = dataContext;
        }

        public List<Comment> GetAllCommentsByPostId(Guid PostId)
        {
            List<Comment> commentList = new List<Comment>();
          
          

            string rawQuery = @"  
                                select cm.*,us.UserName as UserName from Comments cm 
                                left join Posts po on po.PostId = cm.PostId
                                left join Users us on us.UserId = cm.UserId
                                where cm.PostId = '{0}' 
                               ";

            string sqlQuery = string.Format(rawQuery, PostId);
         
            commentList = context.Database.SqlQuery<CommentVM>(sqlQuery, new object[] { }).ToList<Comment>();
            return commentList;
        }
    }
}
