namespace RealEstate_Dapper_Api.Models.Dtos.ToDoListDtos
{
    public class UpdateToDoListDto
    {
        public int ToDoListId { get; set; }
        public string Description { get; set; }
        public bool ToDoListStatus { get; set; }
    }
}
