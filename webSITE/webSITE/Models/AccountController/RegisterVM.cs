using System.ComponentModel.DataAnnotations;
using webSITE.Domain.Enum;

namespace webSITE.Models.AccountController
{
    public class RegisterVM
	{
		[Required(ErrorMessage = "Masukan {0}")]
		[EmailAddress(ErrorMessage = "Format {0} salah")]
		[Display(Name = "Email")]
		public string Email { get; set; } = string.Empty;

		[Required(ErrorMessage = "Masukan {0}")]
		[StringLength(100, ErrorMessage = "Panjang {0} minimanl {2} dan maksimal {1} karakater.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; } = string.Empty;

		[DataType(DataType.Password)]
		[Display(Name = "Konfirmasi password")]
		[Compare("Password", ErrorMessage = "Password dan konfirmasi password tidak sama.")]
		public string ConfirmPassword { get; set; } = string.Empty;

		[Required(ErrorMessage = "Masukan {0}")]
		[StringLength(10, ErrorMessage = "Panjang {0} minimanl {2} dan maksimal {1} karakater.", MinimumLength = 10)]
		[Display(Name = "NIM")]
		public string Nim { get; set; } = string.Empty;

		[Required(ErrorMessage = "Masukan {0}")]
		[StringLength(100, ErrorMessage = "Panjang {0} minimanl {2} dan maksimal {1} karakater.", MinimumLength = 6)]
		[Display(Name = "Nama Lengkap")]
		public string NamaLengkap { get; set; } = string.Empty;

		[Required(ErrorMessage = "Masukan {0}")]
		[StringLength(100, ErrorMessage = "Panjang {0} minimanl {2} dan maksimal {1} karakater.", MinimumLength = 2)]
		[Display(Name = "Nama Panggilan")]
		public string NamaPanggilan { get; set; } = string.Empty;

		[Required(ErrorMessage = "Masukan {0}")]
		[DataType(DataType.Date)]
		[Display(Name = "Tanggal Lahir")]
		public DateTime TanggalLahir { get; init; } = new DateTime(2004, 1, 1);

		[Required(ErrorMessage = "Masukan {0}")]
		[Display(Name = "Jenis Kelamin")]
		public JenisKelamin JenisKelamin { get; set; }

		public string? ReturnUrl { get; set; }
	}
}
