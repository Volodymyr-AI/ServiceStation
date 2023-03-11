namespace ServiceStation.Application.Vehicles.Commands.RepairVehicle.RepairCommand
{
    public class RepairCarCommand : RepairVehicleCommand
    {
        public RepairCarCommand(Guid id)
        {
            Id = id;
        }
    }
}
