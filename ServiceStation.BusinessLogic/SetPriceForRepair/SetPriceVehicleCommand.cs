﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.BusinessLogic.SetPriceForRepair
{
    public class SetPriceVehicleCommand : IRequest<int>
    {
        public Guid Id { get; set; }
    }
}
