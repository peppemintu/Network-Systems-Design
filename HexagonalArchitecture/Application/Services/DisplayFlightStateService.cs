using System;
using SpaceFlightBookingApp.Application.Ports;
using SpaceFlightBookingApp.Application.UseCases;

namespace SpaceFlightBookingApp.Application.Services
{
    public class DisplayFlightStateService : IDisplayFlightStateUseCase
    {
        private readonly ISelectFlightStatePort _selectFlightStatePort;

        public DisplayFlightStateService(ISelectFlightStatePort selectFlightStatePort)
        {
            _selectFlightStatePort = selectFlightStatePort;
        }

        public Dictionary<int, bool> GetSeatOccupancyStatus(int flightId)
        {
            return _selectFlightStatePort.GetSeatOccupancyStatus(flightId);
        }

        public (int availableSeats, int occupiedSeats) CalculateSeatAvailability(Dictionary<int, bool> seatOccupancyStatus)
        {
            int availableSeats = 0;
            int occupiedSeats = 0;

            foreach (var seatStatus in seatOccupancyStatus.Values)
            {
                if (seatStatus)
                    occupiedSeats++;
                else
                    availableSeats++;
            }

            return (availableSeats, occupiedSeats);
        }

        public bool HasFlightDeparted(int flightId)
        {
            DateTime departureTime = _selectFlightStatePort.GetFlightDepartureTime(flightId);
            return DateTime.Now > departureTime;
        }

        public (string operatorName, DateTime departureDate, string destination) GetFlightInfo(int flightId)
        {
            return _selectFlightStatePort.GetFlightInfo(flightId);
        }

        public FlightInformationDto GetFlightInformation(int flightId)
        {
            var seatOccupancyStatus = GetSeatOccupancyStatus(flightId);
            var (availableSeats, occupiedSeats) = CalculateSeatAvailability(seatOccupancyStatus);
            var (operatorName, departureDate, destination) = GetFlightInfo(flightId);
            var hasDeparted = HasFlightDeparted(flightId);

            return new FlightInformationDto
            {
                SeatOccupancyStatus = seatOccupancyStatus,
                AvailableSeats = availableSeats,
                OccupiedSeats = occupiedSeats,
                HasDeparted = hasDeparted,
                OperatorName = operatorName,
                DepartureDate = departureDate,
                Destination = destination
            };
        }
    }
}

