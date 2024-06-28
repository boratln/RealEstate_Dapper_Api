namespace RealEstate_Dapper_Api.Models.Dtos.ToDoListDtos
{
    public class GetByToDoListDto
    {
        public int ToDoListId { get; set; }
        public string Description { get; set; }
        public bool ToDoListStatus { get; set; }
    }
}
