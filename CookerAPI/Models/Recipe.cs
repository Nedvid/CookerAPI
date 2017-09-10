using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookerAPI.Models
{
    public class Recipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Recipe { get; set; }
        public int Id_User { get; set; }
        public int Id_Category_Main { get; set; }

        public string Name_Recipe { get; set; }
        public int Rate { get; set; } //rate 0-5
        public string Level { get; set; }
        public DateTime Date_Recipe { get; set; } //date of create
        public string URL_Photo { get; set; } //URL of thumbnail
        public int Time { get; set; } // in minutes
        public int Number_Person { get; set; } // recipe for number of people
        public int Steps { get; set; }
        public string Instruction { get; set; }

        [ForeignKey("Id_User")]
        public User User { get;set;}
        [ForeignKey("Id_Category_Main")]
        public Category_Main Category_Main { get; set; }

        public ICollection<Category_Recipe> Categories_Recipes { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Element> Elements { get; set; }
        public ICollection<Rate> Rates { get; set; }

    }
}