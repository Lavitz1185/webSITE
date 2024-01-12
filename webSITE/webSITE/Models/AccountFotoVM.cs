﻿using System.ComponentModel.DataAnnotations;

namespace webSITE.Models
{
    public class AccountFotoVM
    {
        public string? Id { get; set; }

        [Required]
        [Display(Name = "Foto Profil")]
        public IFormFile FotoFormFile { get; set; }
    }
}