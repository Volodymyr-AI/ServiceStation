﻿using ServiceStation.Application.Interfaces;
using Dapper;

namespace ServiceStation.BusinessLogic
{
    public class CountVehicleState
    {
        private readonly IAppDbContext _appDbContext;

        public CountVehicleState(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void CalculateVehicleState(Guid Id)
        {
            
        }
    }
}
