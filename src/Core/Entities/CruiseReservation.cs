namespace Core.Entities
{
    public class CruiseReservation
    {
        public int Id { get; set; }

        public int TravelAgentId { get; set; }

        public float PercentCommissionPerPerson { get; set; }

        public int CruiseId { get; set; }

        public Cruise Cruise { get; set; }

        public TravelAgent TravelAgent { get; set; }
    }
}
