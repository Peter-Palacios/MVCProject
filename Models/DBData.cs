using System.Collections.Generic;
namespace MVCProject.Models
{
    public class DBData : IData
    {
        public List<Reservation> Reservations { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        private ReservationContext _reservationContext;

        public DBData(ReservationContext reservationContext)
        {
            _reservationContext = reservationContext;
        }
        public void AddReservation(Reservation reservation)
        {
            _reservationContext.Reservations.Add(reservation);
            _reservationContext.SaveChanges();
        }

        public void DeleteReservation(int? id)
        {
            var res = _reservationContext.Reservations.Find(id);
            if(res!=null)
            {
                _reservationContext.Reservations.Remove(res);
                _reservationContext.SaveChanges();
            }
        }

        public Reservation GetReservation(int? id)
        {
            return _reservationContext.Reservations.Find(id);
        }

        public IEnumerable<Reservation> InitializeData()
        {
            return _reservationContext.Reservations;
        }

        public void UpdateReservation(Reservation reservation)
        {
            Reservation res = _reservationContext.Reservations.Find(reservation.Id);
            if(res!=null)
            {
                res.Id = reservation.Id;
                res.FirstName = reservation.FirstName;
                res.LastName = reservation.LastName;
                res.email = reservation.email;
                res.PhoneNumber = reservation.PhoneNumber;
                res.persons = reservation.persons;
                res.Time = reservation.Time;

                _reservationContext.SaveChanges();
            }
        }
    }
}
