using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Models.Dtos.ToDoListDtos;
using System.Diagnostics;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepository
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly Context _context;
        public ToDoListRepository(Context context)
        {
            _context = context;
        }
        public async Task CreateToDoList(CreateToDoListDto toDoListDto)
        {
            string query = "INSERT INTO ToDoList(Description,ToDoListStatus) VALUES(@desc,@status)";
            var parameters = new DynamicParameters();
            parameters.Add("@desc", toDoListDto.Description);
            parameters.Add("@status", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteToDoList(int id)
        {
            string query = "DELETE FROM ToDolist WHERE ToDoListId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection()) {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultToDoListDto>> GetAllToDoList()
        {
            string query = "SELECT * FROM ToDoList";
            using (var connection = _context.CreateConnection()) {
            var list=await connection.QueryAsync<ResultToDoListDto>(query);
                return list.ToList();
            
            }
        }

        public async Task<GetByToDoListDto> ToDoListDetail(int id)
        {
            string query = "Select * from ToDoList where ToDoListId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection()) {
                var data=await connection.QueryFirstOrDefaultAsync<GetByToDoListDto>(query);
                return data;
            
            }
        }

        public async Task UpdateToDoList(UpdateToDoListDto toDoListDto)
        {
            string query = "Update ToDoList Set Description=@desc,ToDoListStatus=@status where ToDoListId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", toDoListDto.ToDoListId);
            parameters.Add("@desc", toDoListDto.Description);
            parameters.Add("@status", toDoListDto.ToDoListStatus);
            using (var connection = _context.CreateConnection())
            {
               await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
