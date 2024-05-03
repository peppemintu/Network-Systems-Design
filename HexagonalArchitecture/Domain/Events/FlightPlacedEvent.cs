using System;
namespace SpaceFlightBookingApp.Domain.Events
{
    public class FlightPlacedEvent
    {
        // Идентификатор оператора, разместившего полет
        public int OperatorId { get; private set; }

        // Идентификатор рейса
        public int FlightId { get; private set; }

        // Дата и время события
        public DateTime Timestamp { get; private set; }

        // Конструктор для создания экземпляра события
        public FlightPlacedEvent(int operatorId, int flightId, DateTime timestamp)
        {
            OperatorId = operatorId;
            FlightId = flightId;
            Timestamp = timestamp;

            // Вывод информации о событии в консоль
            Console.WriteLine($"FlightPlacedEvent created - " +
                $"OperatorId: {operatorId}, FlightId: {flightId}, " +
                $"Timestamp: {timestamp}");
        }
    }
}

