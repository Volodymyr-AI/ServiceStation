namespace ServiceStation.API.Entities
{
    public class Bus : Vehicle
    {
        public int Interior { get; set; }
        public int Handrails { get; set; }

        public bool replacementOfInteriorSeatUpholstery { get; set; } // optional
    }
}
