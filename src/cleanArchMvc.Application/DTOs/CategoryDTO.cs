﻿using System.ComponentModel.DataAnnotations;

namespace cleanArchMvc.Application.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        public required string Name { get; set; }
    }
}
