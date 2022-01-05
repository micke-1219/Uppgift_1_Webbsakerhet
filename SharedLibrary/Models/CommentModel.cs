using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Field can not be empty!")]
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        [Required(ErrorMessage = "Field can not be empty!")]
        public string UserName { get; set; }
    }
}
