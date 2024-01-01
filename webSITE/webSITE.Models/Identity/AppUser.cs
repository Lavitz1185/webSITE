using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using webSITE.Models;

namespace webSITE.Models.Identity;

// Add profile data for application users by adding properties to the AppUser class
public class AppUser : IdentityUser
{
    public int IdMahasiswa { get; set; }

    public Mahasiswa Mahasiswa { get; set; }
}
