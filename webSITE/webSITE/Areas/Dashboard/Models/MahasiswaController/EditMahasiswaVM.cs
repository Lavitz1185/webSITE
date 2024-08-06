using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using webSITE.Domain.Enum;

namespace webSITE.Areas.Dashboard.Models.MahasiswaController
{
    public class EditMahasiswaVM
    {
        public string Id { get; set; } = string.Empty;

        public string NamaLengkap { get; set; } = string.Empty;

        [Display(Name = "Admin")]
        public bool Admin { get; set; }
    }
}
