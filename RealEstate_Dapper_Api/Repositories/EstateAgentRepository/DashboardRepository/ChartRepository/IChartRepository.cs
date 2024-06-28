using RealEstate_Dapper_Api.Models.Dtos.ChartDtos;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.ChartRepository
{
    public interface IChartRepository
    {
        Task<List<ResultCharDto>> Get5CityForChart();
    }
}
