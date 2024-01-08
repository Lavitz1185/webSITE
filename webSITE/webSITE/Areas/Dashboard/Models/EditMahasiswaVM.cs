using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using webSITE.Models;

namespace webSITE.Areas.Dashboard.Models
{
    public class EditMahasiswaVM
    {
        public string Id { get; set; }
        public string NamaLengkap { get; set; }

        [Display(Name = "Status Akun")]
        public StatusAkun StatusAkun { get; set; }

        [Display(Name = "Admin")]
        public bool Admin { get; set; }
    }
}
