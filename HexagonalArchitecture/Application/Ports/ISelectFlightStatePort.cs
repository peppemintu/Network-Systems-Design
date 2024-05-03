using System;
namespace SpaceFlightBookingApp.Application.Ports
{
    public interface ISelectFlightStatePort
    {
        // Получение статуса занятости мест на полете из базы данных
        Dictionary<int, bool> GetSeatOccupancyStatus(int flightId);

        // Получение информации о состоянии полета из базы данных
        (string operatorName, DateTime departureDate, string destination) GetFlightInfo(int flightId);

        // Получение времени отправления полета из базы данных
        DateTime GetFlightDepartureTime(int flightId);
    }
}

