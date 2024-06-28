using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Repositories.AmenityRepository;
using RealEstate_Dapper_Api.Repositories.BottomGridRepositories;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;
using RealEstate_Dapper_Api.Repositories.ContactRepository;
using RealEstate_Dapper_Api.Repositories.EmployeeRepository;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.ChartRepository;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.LastProductsRepository;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.StatisticRepository;
using RealEstate_Dapper_Api.Repositories.MessageRepository;
using RealEstate_Dapper_Api.Repositories.PopularLocationRepositories;
using RealEstate_Dapper_Api.Repositories.ProductImageRepository;
using RealEstate_Dapper_Api.Repositories.ProductRepository;
using RealEstate_Dapper_Api.Repositories.ServiceRepository;
using RealEstate_Dapper_Api.Repositories.StatisticsRepository;
using RealEstate_Dapper_Api.Repositories.SubFeatureRepository;
using RealEstate_Dapper_Api.Repositories.TestimonialRepositories;
using RealEstate_Dapper_Api.Repositories.ToDoListRepository;
using RealEstate_Dapper_Api.Repositories.UserRepository;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepository;

namespace RealEstate_Dapper_Api.Containers
{
    public static class Extensions
    {
        public static void ContainerDependecies(this IServiceCollection services) {
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IWhoWeAreRepository, WhoWeAreRepository>();
            services.AddTransient<IServiceRepository, ServiceRepository>();
            services.AddTransient<IBottomGridRepository, BottomGridRepository>();
            services.AddTransient<IPopularLocationRepository, PopularLocationRepository>();
            services.AddTransient<ITestimonialRepository, TestimonialRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IstatisticsRepository, StatisticRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IToDoListRepository, ToDoListRepository>();
            services.AddTransient<IStatisticRepository, StatiscticRepository>();
            services.AddTransient<IChartRepository, ChartRepository>();
            services.AddTransient<ILast5ProductRepository, Last5ProductRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();
            services.AddTransient<IProductImageRepository, ProductImageRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAmenityRepository, AmenityRepository>();
            services.AddTransient<ISubFeatureRepository, SubFeatureRepository>();
        }
    }
}
