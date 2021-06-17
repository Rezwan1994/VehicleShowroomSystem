using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Entity
{
    public class Post:Entity
    {
        public Guid PostId { get; set; }
        public string PostStatement { get; set; }
        public DateTime PostDate { get; set; }
        public int TotalComment { get; set; }
        public Guid UserId { get; set; }
        [NotMapped]
        public string UserName { get; set; }
    }
    [NotMapped]
    public class PostVM : Post
    {
 
    }
}
