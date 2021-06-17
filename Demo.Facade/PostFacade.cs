using Demo.Entity;
using Demo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Facade
{
    public  class PostFacade : Facade<Entity.Post>
    {
        PostRepository postRepository = null;
        public PostFacade(DataContext dataContext) : base(dataContext)
        {
            postRepository = new PostRepository(dataContext);
        }

        public PostModel GetAllPost(UserPostFilter filter)
        {
            return postRepository.GetAllPost(filter);
        }
    }
}
