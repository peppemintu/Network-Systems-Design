using System;
namespace SpaceFlightBookingApp.Application.UseCases
{
    public interface IDisplayFlightStateUseCase
    {
        // Функция, определяющая, какие места куплены, а какие нет, и возвращающая структуру данных со значениями "номер места - занято/не занято"
        Dictionary<int, bool> GetSeatOccupancyStatus(int flightId);

        // Функция, вычисляющая, сколько мест свободно и сколько занято на основе структуры данных со значениями "номер места - занято/не занято"
        (int availableSeats, int occupiedSeats) CalculateSeatAvailability(Dictionary<int, bool> seatOccupancyStatus);

        // Функция, вычисляющая, был ли полет уже совершен
        bool HasFlightDeparted(int flightId);

        // Функция, получающая информацию об операторе полета, дате отправления и месте назначения
        (string operatorName, DateTime departureDate, string destination) GetFlightInfo(int flightId);

        // Функция, объединяющая вышеперечисленные функции и возвращающая объект с информацией о полете
        FlightInformationDto GetFlightInformation(int flightId);
    }

    // DTO для хранения информации о полете
    public class FlightInformationDto
    {
        public Dictionary<int, bool> SeatOccupancyStatus { get; set; }
        public int AvailableSeats { get; set; }
        public int OccupiedSeats { get; set; }
        public bool HasDeparted { get; set; }
        public string OperatorName { get; set; }
        public DateTime DepartureDate { get; set; }
        public string Destination { get; set; }
    }
}

