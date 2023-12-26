using BlogManagement.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogManagement.PostServices
{
    public class PostServiceViewModel
    {
        public int PostId { get; set; }

        [Required(ErrorMessage = "Please Enter Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please Fill up this")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Please Enter Author Name")]
        public string Author { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
        public ActionEnum ActionEum { get { return (ActionEnum)this.ActionId; } }
        public int ActionId { get; set; } = 1;
        public bool IsActive { get; set; }

        public IEnumerable<PostServiceViewModel> BlogList { get; set; }
    }
}