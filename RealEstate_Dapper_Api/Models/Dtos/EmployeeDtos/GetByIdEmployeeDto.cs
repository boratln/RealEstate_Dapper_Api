﻿namespace RealEstate_Dapper_Api.Models.Dtos.EmployeeDtos
{
    public class GetByIdEmployeeDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeTitle { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeMail { get; set; }
        public string EmployeephoneNumber { get; set; }
        public string EmployeeImageUrl { get; set; }
        public bool EmployeeStatus { get; set; }
    }
}
