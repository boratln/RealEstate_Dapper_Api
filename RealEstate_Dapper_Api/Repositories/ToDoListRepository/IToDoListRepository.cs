using RealEstate_Dapper_Api.Models.Dtos.ToDoListDtos;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepository
{
    public interface IToDoListRepository
    {
        Task<List<ResultToDoListDto>> GetAllToDoList();
        Task CreateToDoList(CreateToDoListDto toDoListDto);
        Task DeleteToDoList(int id);
        Task UpdateToDoList(UpdateToDoListDto toDoListDto);
        Task<GetByToDoListDto> ToDoListDetail(int id);
    }
}
