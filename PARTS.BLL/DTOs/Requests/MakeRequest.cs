﻿namespace PARTS.BLL.DTOs.Requests
{
    public class MakeRequest : BaseDTO
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? Year { get; set; }

        public List<VehicleRequest>? Vehicles { get; set; }
        public List<ModelRequest>? Models { get; set; }
    }
}
