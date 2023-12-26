using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BlogManagement.Utility;

namespace BlogManagement.Models
{
    public class Posts
    {
        [Key]
        public int PostId { get; set; }

        [Required(ErrorMessage ="Please Enter Title")]
        [StringLength(250)] 
        public string Title { get; set; }

        [Required(ErrorMessage = "Please Fill up this")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Please Enter Author Name")]
        [StringLength(150)] 
        public string Author { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; } = true;
    }
}