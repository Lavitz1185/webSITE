using Microsoft.AspNetCore.Mvc;
using webSITE.DataAccess.Repositori.Interface;

namespace webSITE.ViewComponents
{
    public class PopUpPengumumanViewComponent : ViewComponent
    {
        private readonly IRepositoriPengumuman _repositoriPengumuman;

        public PopUpPengumumanViewComponent(IRepositoriPengumuman repositoriPengumuman)
        {
            _repositoriPengumuman = repositoriPengumuman;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var pengumuman = await _repositoriPengumuman.GetPriority();

            return View(pengumuman);
        }
    }
}
