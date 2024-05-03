namespace SpaceFlightBookingApp.Domain.Entities
{
    public class Seat
    {
        public enum SeatClass
        {
            Economy,
            Business,
            FirstClass
        }

        // Автоматические свойства
        public int SeatNumber { get; }
        public bool IsOccupied { get; private set; }
        public int Price { get; }

        // Конструктор
        public Seat(int seatNumber, SeatClass seatClass)
        {
            SeatNumber = seatNumber;
            Price = CalculatePrice(seatClass);
            IsOccupied = false;
        }

        // Метод для расчета цены места
        private int CalculatePrice(SeatClass seatClass)
        {
            switch (seatClass)
            {
                case SeatClass.Economy:
                    return 100;
                case SeatClass.Business:
                    return 150;
                case SeatClass.FirstClass:
                    return 200;
                default:
                    throw new ArgumentException("Invalid seat class.");
            }
        }

        // Метод для бронирования места
        public bool ReserveSeat()
        {
            if (!IsOccupied)
            {
                IsOccupied = true;
                return true; // Место успешно забронировано
            }
            else
            {
                return false; // Место уже занято
            }
        }

        // Метод для освобождения места
        public void ReleaseSeat()
        {
            IsOccupied = false;
        }
    }
}