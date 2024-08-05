using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webSITE.Areas.Dashboard.Models.KegiatanController;
using webSITE.DataAccess.Data;
using webSITE.DataAccess.Repositori.Interface;
using webSITE.Domain;
using webSITE.Models;
using webSITE.Services.Contracts;
using webSITE.Domain.Abstractions;
using webSITE.Domain.Exceptions.FotoExceptions;
using webSITE.Domain.Exceptions.KegiatanExceptions;
using webSITE.Domain.Exceptions.MahasiswaExceptions;

namespace webSITE.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin, ADMIN")]
    public class KegiatanController : Controller
    {
        private readonly IRepositoriKegiatan _repositoriKegiatan;
        private readonly IRepositoriMahasiswa _repositoriMahasiswa;
        private readonly IRepositoriFoto _repositoriFoto;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<KegiatanController> _logger;
        private readonly IToastrNotificationService _notificationService;

        public KegiatanController(
            IRepositoriKegiatan repositoriKegiatan,
            IRepositoriMahasiswa repositoriMahasiswa,
            IRepositoriFoto repositoriFoto,
            IMapper mapper,
            ILogger<KegiatanController> logger,
            IUnitOfWork unitOfWork,
            IToastrNotificationService notificationService)
        {
            _repositoriKegiatan = repositoriKegiatan;
            _repositoriMahasiswa = repositoriMahasiswa;
            _repositoriFoto = repositoriFoto;
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _notificationService = notificationService;
        }

        public async Task<IActionResult> Index()
        {
            var listKegiatan = await _repositoriKegiatan.GetAllWithDetail();

            return View(listKegiatan ?? new());
        }

        public async Task<IActionResult> Detail(int id)
        {
            var kegiatan = await _repositoriKegiatan.GetWithDetail(id);

            if (kegiatan is null) return NotFound();

            return View(kegiatan);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _repositoriKegiatan.Delete(id);
                await _unitOfWork.SaveChangesAsync();

                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Success,
                    Title = "Hapus Kegiatan Sukses"
                });
            }
            catch (DomainException ex)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Hapus Kegiatan Gagal",
                    Message = ex.Message,
                });
                _logger.LogError("Delete. Exception : {0}", ex.ToString());
            }
            catch (Exception ex)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Hapus Kegiatan Gagal",
                });
                _logger.LogError("Delete. Exception : {0}", ex.ToString());
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult TambahKegiatan()
        {
            return View(new TambahKegiatanVM());
        }

        [HttpPost]
        public async Task<IActionResult> TambahKegiatan(TambahKegiatanVM tambahKegiatanVM)
        {
            try
            {
                //Validasi
                if (!ModelState.IsValid) return View(tambahKegiatanVM);

                var duplikasiNama = await _repositoriKegiatan.IsDuplicateName(0,
                    tambahKegiatanVM.NamaKegiatan, tambahKegiatanVM.Tanggal);

                if (duplikasiNama)
                    throw new KegiatanAlreadyExistsException(
                        tambahKegiatanVM.NamaKegiatan,
                        tambahKegiatanVM.Tanggal);

                //Simpan ke database
                var kegiatan = new Kegiatan
                {
                    NamaKegiatan = tambahKegiatanVM.NamaKegiatan,
                    Tanggal = tambahKegiatanVM.Tanggal,
                    JumlahHari = tambahKegiatanVM.JumlahHari,
                    Keterangan = tambahKegiatanVM.Keterangan,
                    TempatKegiatan = tambahKegiatanVM.TempatKegiatan
                };

                foreach (var idFoto in tambahKegiatanVM.DaftarIdFoto)
                {
                    var foto = await _repositoriFoto.Get(idFoto) ?? throw new FotoNotFoundException(idFoto);
                    kegiatan.AddFoto(foto);
                }

                var fotoThumbnail = await _repositoriFoto.Get(tambahKegiatanVM.IdThumbnail);

                if(fotoThumbnail is null)
                {
                    ModelState.AddModelError(nameof(TambahKegiatanVM.IdThumbnail), "Foto Thumbnail tidak ditemukan");
                    return View(tambahKegiatanVM);
                }

                kegiatan.FotoThumbnail = fotoThumbnail;

                foreach (var idMahasiswa in tambahKegiatanVM.DaftarIdMahasiswa)
                {
                    var mahasiswa = await _repositoriMahasiswa.Get(idMahasiswa);

                    if (mahasiswa is null) throw new MahasiswaNotFoundException(idMahasiswa);

                    kegiatan.TambahPeserta(mahasiswa);
                }

                _repositoriKegiatan.Add(kegiatan);

                await _unitOfWork.SaveChangesAsync();

                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Success,
                    Title = "Tambah Kegiatan Sukses",
                    Message = "Sukses menambahkan kegiatan. Lanjutkan dengan menambahkan foto untuk kegiatan"
                });

                return RedirectToAction(nameof(Index));
            }
            catch (FotoNotFoundException ex)
            {
                ModelState.AddModelError(nameof(TambahKegiatanVM.DaftarIdFoto), ex.Message);
                return View(tambahKegiatanVM);
            }
            catch (MahasiswaNotFoundException ex)
            {
                ModelState.AddModelError(nameof(TambahKegiatanVM.DaftarIdMahasiswa), ex.Message);
                return View(tambahKegiatanVM);
            }
            catch (KegiatanAlreadyHaveFotoException ex)
            {
                ModelState.AddModelError(nameof(TambahKegiatanVM.DaftarIdFoto), ex.Message);
                return View(tambahKegiatanVM);
            }
            catch (KegiatanAlreadyHaveMahasiswaException ex)
            {
                ModelState.AddModelError(nameof(TambahKegiatanVM.DaftarIdMahasiswa), ex.Message);
                return View(tambahKegiatanVM);
            }
            catch (KegiatanAlreadyExistsException ex)
            {
                ModelState.AddModelError(nameof(TambahKegiatanVM.NamaKegiatan), ex.Message);
                return View(tambahKegiatanVM);
            }
            catch (DomainException ex)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Tambah Kegiatan Gagal",
                    Message = ex.Message,
                });
                ModelState.AddModelError(string.Empty, $"Tambah Gagal. {ex.Message}");

                _logger.LogError("Tambah. Domain Exception : {0}", ex.ToString());
                return View(tambahKegiatanVM);
            }
            catch (Exception ex)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Tambah Kegiatan Gagal"
                });
                ModelState.AddModelError(string.Empty, $"Tambah Gagal");

                _logger.LogError("Tambah. Exception : {0}", ex.ToString());
                return View(tambahKegiatanVM);
            }
        }

        public async Task<IActionResult> EditKegiatan(int id)
        {
            var kegiatan = await _repositoriKegiatan.GetWithDetail(id);

            if (kegiatan is null) return NotFound();

            return View(new EditKegiatanVM
            {
                Id = id,
                NamaKegiatan = kegiatan.NamaKegiatan,
                TempatKegiatan = kegiatan.TempatKegiatan,
                JumlahHari = kegiatan.JumlahHari,
                Keterangan = kegiatan.Keterangan,
                Tanggal = kegiatan.Tanggal,
                IdThumbnail = kegiatan.FotoThumbnail?.Id,
                DaftarIdFoto = kegiatan.DaftarFoto is null ? new() : kegiatan.DaftarFoto.Select(f => f.Id).ToList(),
                DaftarIdMahasiswa = kegiatan.DaftarMahasiswa is null ? new() : kegiatan.DaftarMahasiswa.Select(m => m.Id).ToList(),
            });
        }

        [HttpPost]
        public async Task<IActionResult> EditKegiatan(EditKegiatanVM editKegiatanVM)
        {
            try
            {
                //Validasi
                if (!ModelState.IsValid) return View(editKegiatanVM);

                var duplikasiNama = await _repositoriKegiatan.IsDuplicateName(
                    editKegiatanVM.Id,
                    editKegiatanVM.NamaKegiatan,
                    editKegiatanVM.Tanggal);

                if (duplikasiNama)
                    throw new KegiatanAlreadyExistsException(
                        editKegiatanVM.NamaKegiatan,
                        editKegiatanVM.Tanggal);

                //Simpan ke database
                var kegiatan = await _repositoriKegiatan.GetWithDetail(editKegiatanVM.Id);

                if (kegiatan is null) throw new KegiatanNotFoundException(editKegiatanVM.Id);

                kegiatan.NamaKegiatan = editKegiatanVM.NamaKegiatan;
                kegiatan.JumlahHari = editKegiatanVM.JumlahHari;
                kegiatan.Keterangan = editKegiatanVM.Keterangan;
                kegiatan.TempatKegiatan = editKegiatanVM.TempatKegiatan;
                kegiatan.Tanggal = editKegiatanVM.Tanggal;

                var fotoThumbnail = await _repositoriFoto.Get(editKegiatanVM.IdThumbnail!.Value);

                if (fotoThumbnail is null)
                {
                    ModelState.AddModelError(nameof(TambahKegiatanVM.IdThumbnail), "Foto Thumbnail tidak ditemukan");
                    return View(editKegiatanVM);
                }

                kegiatan.FotoThumbnail = fotoThumbnail;

                var daftarFoto = new List<Foto>();

                foreach (var idFoto in editKegiatanVM.DaftarIdFoto)
                {
                    var foto = await _repositoriFoto.Get(idFoto) ?? throw new FotoNotFoundException(idFoto);
                    daftarFoto.Add(foto);
                }

                kegiatan.AddDaftarFoto(daftarFoto);

                var daftarMahasiswa = new List<Mahasiswa>();
                foreach (var idMahasiswa in editKegiatanVM.DaftarIdMahasiswa)
                {
                    var mahasiswa = await _repositoriMahasiswa.Get(idMahasiswa);
                    if (mahasiswa is null) throw new MahasiswaNotFoundException(idMahasiswa);

                    daftarMahasiswa.Add(mahasiswa);
                }

                kegiatan.TambahDaftarPeserta(daftarMahasiswa);

                _repositoriKegiatan.Update(kegiatan);
                await _unitOfWork.SaveChangesAsync();

                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Success,
                    Title = "Edit Kegiatan Sukses!"
                });

                return RedirectToAction(nameof(Index));
            }
            catch (FotoNotFoundException ex)
            {
                ModelState.AddModelError(nameof(EditKegiatanVM.DaftarIdFoto), ex.Message);
                return View(editKegiatanVM);
            }
            catch (MahasiswaNotFoundException ex)
            {
                ModelState.AddModelError(nameof(EditKegiatanVM.DaftarIdMahasiswa), ex.Message);
                return View(editKegiatanVM);
            }
            catch (KegiatanAlreadyHaveFotoException ex)
            {
                ModelState.AddModelError(nameof(EditKegiatanVM.DaftarIdFoto), ex.Message);
                return View(editKegiatanVM);
            }
            catch (KegiatanAlreadyHaveMahasiswaException ex)
            {
                ModelState.AddModelError(nameof(EditKegiatanVM.DaftarIdMahasiswa), ex.Message);
                return View(editKegiatanVM);
            }
            catch (KegiatanAlreadyExistsException ex)
            {
                ModelState.AddModelError(nameof(EditKegiatanVM.NamaKegiatan), ex.Message);
                return View(editKegiatanVM);
            }
            catch (DomainException ex)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Edit Kegiatan Gagal",
                    Message = ex.Message,
                });
                ModelState.AddModelError(string.Empty, $"Edit Gagal. {ex.Message}");

                _logger.LogError("Tambah. Domain Exception : {0}", ex.ToString());
                return View(editKegiatanVM);
            }
            catch (Exception ex)
            {
                _notificationService.AddNotification(new ToastrNotification
                {
                    Type = ToastrNotificationType.Error,
                    Title = "Edit Kegiatan Gagal"
                });
                ModelState.AddModelError(string.Empty, $"Edit Gagal");

                _logger.LogError("Edit. Exception : {0}", ex.ToString());
                return View(editKegiatanVM);
            }
        }

        public async Task<IActionResult> DaftarAlbum()
        {
            var daftarKegiatan = await _repositoriKegiatan.GetAllWithDetail();

            daftarKegiatan = daftarKegiatan ?? new();

            var daftarAlbum = daftarKegiatan.Select(k =>
            {
                var album = new AlbumVM
                {
                    IdKegiatan = k.Id,
                    NamaKegiatan = k.NamaKegiatan,
                    Tanggal = k.Tanggal,
                    DaftarFoto = k.DaftarFoto.ToList(),
                    IdThumbnail = k.FotoThumbnail?.Id,
                };

                if (k.FotoThumbnail is not null)
                    album.DaftarFoto.Add(k.FotoThumbnail);

                album.JumlahFoto = album.DaftarFoto.Count;

                return album;
            }).ToList();

            return View(daftarAlbum);
        }

        public async Task<IActionResult> AlbumKegiatan(int id)
        {
            var kegiatan = await _repositoriKegiatan.GetWithDetail(id);

            if (kegiatan is null) return NotFound();

            var model = new AlbumVM
            {
                IdKegiatan = id,
                NamaKegiatan = kegiatan.NamaKegiatan,
                Tanggal = kegiatan.Tanggal,
                DaftarFoto = kegiatan.DaftarFoto
                    .OrderBy(f => f.AddedAt)
                    .ToList()
            };

            if (kegiatan.FotoThumbnail is not null)
                model.DaftarFoto.Add(kegiatan.FotoThumbnail);

            return View(model);
        }
    }
}
