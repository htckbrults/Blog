using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Interactions
    {
        public int Id { get; set; }
        public int BlogsId { get; set; }
        public bool InteractionType { get; set; } // True olarak Algılanırsa Like, False Olarak Algılanırsa DisLike Olarak Algınacaktır.
        public DateTime InteractionDate { get; set; }
        public string IPAddress { get; set; }
        public Blogs Blogs { get; set; }

    }
}
