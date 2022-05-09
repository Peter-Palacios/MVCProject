using System.Collections.Generic;
namespace MVCProject.Models
{
    public interface IData 
    {
        List<Reservation> Reservations { get; set; }

        IEnumerable<Reservation> InitializeData();
        Reservation GetReservation(int? id);
        Reservation GetReservationByEmail(string? email);
        void AddReservation(Reservation reservation);
        void UpdateReservation(Reservation reservation);
        void DeleteReservation(int? id);

    }
}
