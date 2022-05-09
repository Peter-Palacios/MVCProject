using System;
using System.Collections.Generic;

namespace MVCProject.Models
{
    public class Data : IData
    {
        public List<Reservation> Reservations { get; set; }

        public void AddReservation(Reservation reservation)
        {
            Reservations.Add(reservation);
        }

        public void DeleteReservation(int? id)
        {
            var res = Reservations.Find(x => x.Id == id);
            Reservations.Remove(res);
        }

        public Data()
        {
            Reservations = new List<Reservation>()
            {
                new Reservation()
                {
                    Id = 11,
                    FirstName= "John",
                    LastName= "Bushin",
                    email="johnbushin@g.com",
                    persons= 3,
                    PhoneNumber=2293331234,
                    Time= new DateTime(2022,7,1,8,00,00)
                },
                new Reservation()
                {
                    Id = 12,
                    FirstName= "Susan",
                    LastName= "Green",
                    email="sgreen@y.com",
                    persons= 2,
                    PhoneNumber=4442282193,
                    Time= new DateTime(2022,5,15,2,00,00)
                },
                new Reservation()
                {
                    Id = 11,
                    FirstName= "James",
                    LastName= "Jones",
                    email="JJ@g.com",
                    persons= 10,
                    PhoneNumber=7890234586,
                    Time= new DateTime(2022,7,6,6,00,00)
                }
            };
        }
        public Reservation GetReservation(int? id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return Reservations.Find(x => x.Id == id);
            }
        }

        public IEnumerable<Reservation> InitializeData()
        {
            return Reservations;
        }

        public void UpdateReservation(Reservation reservation)
        {
            var res = Reservations.Find(x => x.Id == reservation.Id);
            if (res != null)
            {
                res.Id = reservation.Id;
                res.FirstName = reservation.FirstName;
                res.LastName = reservation.LastName;
                res.email = reservation.email;
                res.persons = reservation.persons;
                res.PhoneNumber = reservation.PhoneNumber;
                res.Time = reservation.Time;
            }
        }

        public Reservation GetReservationByEmail(string email)
        {
            throw new NotImplementedException();

            //if (email == null)
            //{
            //    return null;
            //}
            //else
            //{
            //    return Reservations.Find(x => x.email == email);
            //}
        }
    }
}
