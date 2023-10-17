﻿using ParkingLot.Exceptions;
using System.Collections.Generic;

namespace ParkingLot
{
    public class ParkingBoy
    {
        public ParkingBoy(List<ParkingLot> parkingLots)
        {
            ManagedParkingLots = parkingLots;
        }

        protected List<ParkingLot> ManagedParkingLots { get; set; }

        public Car Fetch(Ticket ticket)
        {
            if (ticket == null)
            {
                throw new NoTicketProvidedException();
            }

            ParkingLot parkingLotForTicket = ManagedParkingLots.Find(parkinglot => parkinglot.HasTicket(ticket));
            if (parkingLotForTicket == null)
            {
                throw new UnrecognizedParkingTicketException();
            }

            return parkingLotForTicket.Fetch(ticket);
        }

        public virtual Ticket Park(Car car)
        {
            ParkingLot availableParkingLot = ManagedParkingLots.Find(parkingLot => !parkingLot.IsFull());
            if (availableParkingLot == null)
            {
                throw new NotEnoughPositionException();
            }

            return availableParkingLot.Park(car);
        }
    }
}
