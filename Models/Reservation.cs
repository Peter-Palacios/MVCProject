using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace MVCProject.Models
{

    //public enum SpecialOccasion
    //{
    //    Birthday,
    //    Anniversary,
    //    Celebration,
    //}

    //public enum InsideOutside
    //{
    //    inside,
    //    outside
    //}
    
    public class Reservation
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PhoneNumber { get; set; }
        public string email { get; set; }

        public int persons { get; set; }
        
        public DateTime Time { get; set; }

        //public string Date {get;set;}



    }

    
}
