using Microsoft.AspNetCore.Mvc;
using webSITE.DataAccess.Repositori.Interface;
using webSITE.Models;

namespace webSITE.ViewComponents
{
    public class MahasiswaPickerViewComponent : ViewComponent
    {
        private readonly IRepositoriMahasiswa _repositoriMahasiswa;

        public MahasiswaPickerViewComponent(IRepositoriMahasiswa repositoriMahasiswa)
        {
            _repositoriMahasiswa = repositoriMahasiswa;
        }

        public async Task<IViewComponentResult> InvokeAsync(string inputName, bool multi, List<string>? value = null)
        {
            var daftarMahasiswa = await _repositoriMahasiswa.GetAll();

            daftarMahasiswa = daftarMahasiswa?.OrderBy(x => x.Nim).ToList();

            var model = new MahasiswaPickerVM
            {
                DaftarMahasiswa = daftarMahasiswa ?? new(),
                Name = inputName,
                Multi = multi
            };

            if(value is not null && value.Count > 0)
            {
                if (multi) model.DaftarIdMahasiswa = value.Distinct().ToList();
                else model.DaftarIdMahasiswa.Add(value.First());
            }

            return View(model);
        }
    }
}
