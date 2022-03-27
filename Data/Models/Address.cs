﻿namespace RealEstateDemoApp.Data.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? PostCode { get; set; }
        public string? Neighborhood { get; set; }
        public int? Entrance { get; set; }
        public int? Flat { get; set; }
        public int? AllFloor { get; set; }
        public int? Floor { get; set; }

        
    }
}
