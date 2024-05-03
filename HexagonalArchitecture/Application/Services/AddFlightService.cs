using System;
using SpaceFlightBookingApp.Application.Ports;
using SpaceFlightBookingApp.Application.UseCases;
using SpaceFlightBookingApp.Domain.Entities;

namespace SpaceFlightBookingApp.Application.Services
{
    public class AddFlightService : IAddFlightUseCase
    {
        private readonly IInsertFlightPort _insertFlightPort;

        public AddFlightService(IInsertFlightPort insertFlightPort)
        {
            _insertFlightPort = insertFlightPort;
        }

        public void AddFlight(DateTime date, string destination, string username,
                              int economySeatsCount, int businessSeatsCount, int firstClassSeatsCount)
        {
            // Генерация уникального идентификатора для полета
            int flightId = _insertFlightPort.GenerateFlightId();

            // Создание объекта класса Flight
            var flight = new Flight(flightId, date, destination, username);

            // Добавление мест к полету
            AddSeatsToFlight(flight, economySeatsCount, businessSeatsCount, firstClassSeatsCount);

            // Проверка наличия свободных мест
            if (flight.Seats.Count == 0)
            {
                throw new InvalidOperationException("Необходимо добавить хотя бы одно место к полету");
            }

            // Добавление полета в базу данных
            _insertFlightPort.InsertFlight(flight);
        }

        public void AddSeatsToFlight(Flight flight, int economySeatsCount, int businessSeatsCount, int firstClassSeatsCount)
        {
            // Добавление мест к полету
            for (int i = 0; i < economySeatsCount; i++)
            {
                var seatNumber = i + 1;
                var seatClass = Seat.SeatClass.Economy;
                ValidateAndAddSeat(flight, seatNumber, seatClass);
            }

            for (int i = 0; i < businessSeatsCount; i++)
            {
                var seatNumber = economySeatsCount + i + 1;
                var seatClass = Seat.SeatClass.Business;
                ValidateAndAddSeat(flight, seatNumber, seatClass);
            }

            for (int i = 0; i < firstClassSeatsCount; i++)
            {
                var seatNumber = economySeatsCount + businessSeatsCount + i + 1;
                var seatClass = Seat.SeatClass.FirstClass;
                ValidateAndAddSeat(flight, seatNumber, seatClass);
            }
        }

        private void ValidateAndAddSeat(Flight flight, int seatNumber, Seat.SeatClass seatClass)
        {
            // Проверка наличия места с таким номером
            if (flight.GetSeatByNumber(seatNumber) != null)
            {
                throw new InvalidOperationException($"Место с номером {seatNumber} уже существует");
            }

            // Добавление места к полету
            flight.AddSeat(seatNumber, seatClass);
        }
    }
}

