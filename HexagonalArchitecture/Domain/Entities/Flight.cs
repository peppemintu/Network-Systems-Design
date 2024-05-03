namespace SpaceFlightBookingApp.Domain.Entities
{
    public class Flight
    {
        // Автоматические свойства
        public int FlightId { get; }
        public DateTime Date { get; set; }
        public string Destination { get; set; }
        public string OperatorName { get; set; }
        public List<Seat> Seats { get; }

        // Конструктор
        public Flight(int flightId, DateTime date, string destination, string operatorName)
        {
            if (string.IsNullOrEmpty(destination))
                throw new ArgumentException("Destination cannot be null or empty.", nameof(destination));

            FlightId = flightId;
            Date = date;
            Destination = destination;
            OperatorName = operatorName;
            Seats = new List<Seat>();
        }

        // Метод для добавления места к полету
        public void AddSeat(int seatNumber, Seat.SeatClass seatClass)
        {
            // Создаем новый объект места и добавляем его в список мест на рейсе
            Seat newSeat = new Seat(seatNumber, seatClass);
            Seats.Add(newSeat);
        }

        // Метод для удаления места с полета
        public void RemoveSeat(Seat seat)
        {
            Seats.Remove(seat);
        }

        public Seat GetSeatByNumber(int seatNumber)
        {
            foreach (var seat in Seats)
            {
                if (seat.SeatNumber == seatNumber)
                {
                    return seat;
                }
            }
            return null; // Место с указанным номером не найдено
        }
    }
}