using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogBD.Models
{
    public class Comment
    {
        //these properties show up as collumns in db table
        public int Id { get; set; }
        public int PostId { get; set; }
        public string AuthorId { get; set; }
        public string Body { get; set; }
        public DateTimeOffset Created { get; set; }
        //? here means this is datetimeoffset that allows nulls
        public DateTimeOffset? Updated { get; set; }
        public string UpdateReason { get; set; }

        //Navivagtion property - does not show in DB table this is a forgein key
        public virtual BlogPost Post { get; set; }
        public virtual ApplicationUser Author { get; set; }
    }
}