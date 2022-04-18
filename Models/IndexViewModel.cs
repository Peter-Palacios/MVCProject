using System.Collections.Generic;
namespace MVCProject.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Reservation> Reservations { get; set; }
    }
}
