namespace SpaceFlightBookingApp.Domain.Entities
{
    public class Operator
    {
        // Автоматические свойства
        public int OperatorId { get; }
        public string OperatorName { get; set; }
        public string ContactNumber { get; set; }

        // Конструктор
        public Operator(int operatorId, string operatorName, string contactNumber)
        {
            OperatorId = operatorId;
            OperatorName = operatorName;
            ContactNumber = contactNumber;
        }
    }
}