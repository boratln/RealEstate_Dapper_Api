﻿namespace RealEstate_Dapper_Api.Models.Dtos.WhoWeAreDtos
{
    public class GetByIdWhoWeAreDetailDto
    {
        public int WhoWeAreDetailId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
    }
}
