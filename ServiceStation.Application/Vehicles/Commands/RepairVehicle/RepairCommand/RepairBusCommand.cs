namespace ServiceStation.Application.Vehicles.Commands.RepairVehicle.RepairCommand
{
    public class RepairBusCommand : RepairVehicleCommand
    {
        public RepairBusCommand(Guid id)
        {
            Id = id;
        }
    }
}
