using System;
using SpaceFlightBookingApp.Domain.Entities;

namespace SpaceFlightBookingApp.Application.Ports
{
    public interface IInsertFlightPort
    {
        // Генерация уникального идентификатора для полета
        int GenerateFlightId();

        // Добавление полета в базу данных
        void InsertFlight(Flight flight);

        // Вставка мест в базу данных
        void InsertSeat();
    }
}

