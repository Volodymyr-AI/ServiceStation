﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Vehicles.Commands.UpdateVehicle.UpdateCommand
{
    public class UpdateTruckCommand : UpdateVehicleCommand
    {
        public int Hydraulics { get; set; }
    }
}
