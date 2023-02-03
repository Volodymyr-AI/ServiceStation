﻿namespace ServiceStation.API.Entities
{
    public abstract class Vehicle
    {
        public Guid VehicleId { get; set; }
        public int Body { get; set; }
        public int Wheels { get; set; }
        public int Engine { get; set; }
        public int Brakes { get; set; }
        public int Chassis { get; set; }
        public int AveragePoint { get; set; }
    }
}