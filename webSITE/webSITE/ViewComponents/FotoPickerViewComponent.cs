using Microsoft.AspNetCore.Mvc;
using webSITE.DataAccess.Repositori.Interface;
using webSITE.Models;
using webSITE.Repositori.Implementasi;

namespace webSITE.ViewComponents
{
    public class FotoPickerViewComponent : ViewComponent
    {
        private readonly IRepositoriFoto _repositoriFoto;

        public FotoPickerViewComponent(IRepositoriFoto repositoriFoto)
        {
            _repositoriFoto = repositoriFoto;
        }

        public async Task<IViewComponentResult> InvokeAsync(string name, bool multi, List<int>? value = null)
        {
            var daftarFoto = await _repositoriFoto.GetAll();

            daftarFoto = daftarFoto?
                .OrderByDescending(daftarFoto => daftarFoto.AddedAt)
                .ToList();

            var model = new FotoPickerVM
            {
                DaftarFoto = daftarFoto ?? new(),
                InputName = name,
                Multi = multi,
                DaftarIdFoto = value
            };

            return View(model);
        }
    }
}
