using Demo.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Repository
{
    public class PostRepository:Repository<Post>
    {
        DataContext context = null;
        public PostRepository(DataContext dataContext) : base(dataContext)
        {
            this.context = dataContext;
        }

        public PostModel GetAllPost(UserPostFilter filter)
        {

            string searchTextQuery = "";
            string subquery = "";
     
            string CountTextQuery = "";

            if (!string.IsNullOrWhiteSpace(filter.SearchText))
            {
                searchTextQuery = " (po.PostStatement like '%" + filter.SearchText + "%' or po.PostDate like '%" + filter.SearchText + "%' ) and ";
                CountTextQuery = " where po.PostStatement like '%" + filter.SearchText + "%'";
            }


            List<Post> postList = new List<Post>();



            string rawQuery = @"  
                                declare @pagesize int
                                declare @pageno int 
                                set @pagesize = " + filter.UnitPerPage + @"
                                set @pageno = " + filter.PageNumber + @"
                                declare @pagestart int
                                set @pagestart=(@pageno-1)* @pagesize  
                                select  TOP (@pagesize) po.*,us.UserName as UserName from Posts po 
                                left join Users us on us.UserId = po.UserId where {0} po.Id NOT IN(Select TOP (@pagestart) Id from Posts)
                               
                               ";
            string CountQuery = string.Format("Select * from Posts po {0}", CountTextQuery);

            rawQuery = string.Format(rawQuery,searchTextQuery);
            int TotalCount = 0;
            var ctx = DataContext.getInstance();
            postList = context.Database.SqlQuery<PostVM>(rawQuery, new object[] { }).ToList<Post>();
            TotalCount = ctx.Posts.SqlQuery(CountQuery).ToList().Count;

            PostModel model = new PostModel();
            model.PostList = postList;
            model.TotalCount = TotalCount;
            return model;
        }
    }
}
