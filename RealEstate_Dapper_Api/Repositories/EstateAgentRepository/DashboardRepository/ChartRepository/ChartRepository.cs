﻿using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Models.Dtos.ChartDtos;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.ChartRepository
{
    public class ChartRepository : IChartRepository
    {
        private readonly Context _context;
        public ChartRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultCharDto>> Get5CityForChart()
        {
            string query = "Select top(5) City,Count(*) as 'CityCount' From Product Group By City order By CityCount Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCharDto>(query);
                return values.ToList();
            }
        }
    }
}
