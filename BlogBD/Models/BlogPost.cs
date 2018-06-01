using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogBD.Models
{
    public class BlogPost
    {

        //Each of these is a colllumn in the DB table
        public int Id { get; set; }
        public DateTimeOffset Created { get; set; }
        //? here means this is datetimeoffset that allows nulls
        public DateTimeOffset? Updated { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string AuthorId { get; set; }
        public string Abstract { get; set; }
        [AllowHtml]
        public string Body { get; set; }
        public string MediaURL { get; set; }
        public bool Published { get; set; }

        //Navigation property - does not show up in DB table this is a foregin key
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ApplicationUser Author { get; set; }
        //Constructor - speical method that has same name as the class and runs 
        //when a new instance of the class is instaniated
        public BlogPost()
        {
            this.Comments = new HashSet<Comment>();
        }
    }
}
