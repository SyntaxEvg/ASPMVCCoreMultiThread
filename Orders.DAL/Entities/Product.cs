﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Orders.DAL.Entities
{
    public class Product :NamedEntity
    {
        [Column(TypeName ="money")]
        public decimal Price { get; set; }
        public string? Category { get; set; }
    }

}