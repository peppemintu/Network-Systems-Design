using System;
using SpaceFlightBookingApp.Domain.Entities;

namespace SpaceFlightBookingApp.Application.UseCases
{
	public interface IAddFlightUseCase
	{
        // Добавление определенного количества мест каждого класса для полета
        public void AddSeatsToFlight(Flight flight, int economySeatsCount, int businessSeatsCount, int firstClassSeatsCount);

        // Функция, объединяющая последовательный вызов вышеуказанных функций
        public void AddFlight(DateTime date, string destination, string username,
                              int economySeatsCount, int businessSeatsCount, int firstClassSeatsCount);
    }
}

