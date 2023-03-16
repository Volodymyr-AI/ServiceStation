namespace ServiceStation.Application.Vehicles.Commands.RepairVehicle.RepairCommand
{
    public class RepairTruckCommand : RepairVehicleCommand
    {
        public RepairTruckCommand(Guid id)
        {
            Id = id;
        }
    }
}
