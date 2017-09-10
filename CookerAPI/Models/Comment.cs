using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookerAPI.Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Comment { get; set; }
        public int Id_User { get; set; }
        public int Id_Recipe { get; set; }
        public string Text { get; set; }
        public DateTime Date_Comment { get; set; }

        [ForeignKey("Id_User")]
        public User User { get; set; }

        [ForeignKey("Id_Recipe")]
        public Recipe Recipe { get; set; }
    }
}