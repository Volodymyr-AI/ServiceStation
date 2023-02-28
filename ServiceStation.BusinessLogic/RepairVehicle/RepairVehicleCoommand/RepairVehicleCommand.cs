using MediatR;

namespace ServiceStation.BusinessLogic.RepairVehicle.RepairVehicleCoommand
{
    public class RepairVehicleCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public int Body { get; set; }
        public int Wheels { get; set; }
        public int Engine { get; set; }
        public int Breaks { get; set; }
        public int Undercarriage { get; set; }

        public double State { get; set; }
    }
}
