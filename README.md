BACA AKU!!!

Fitur : 
  - Tampilkan anggota SITE (sudah)
  - Album Foto (sudah)
  - Jadwal Kegiatan (sudah)
  - Dashboard (sudah)
  - Dashboard Mahasiswa (sudah)
  - Form Tambah, Edit, dan Hapus Mahasiswa (belum)
  - Dashboard Kegiatan (belum)
  - Form Tambah, Edit, dan Hapus Kegiatan (belum)
  - Dashboard Foto (belum)
  - Form Tambah, Edit, dan Hapus Foto (belum)
  - Autentinfikasi (belum)
  - Login Admin (belum)

Tambahan UI : 
  - Home : 
    - Statistik
    - Foto Site Jumbotron
    - Kegiatan Terbaru
    - Highlight Album
  - Siters : 
    - Publik 
    - Profil Bio isi terserah (Siap)

Download kode (Satu Kali saja)
- Pilih Folder
- Klik kanan -> Show More Options -> Open Git Bash Here
- git clone https://github.com/Lavitz1185/webSITE
- cd webSITE

Login
email : aditaklal@gmail.com
password : adiairnona

email : fernandputra14@gmail.com
password : fernandilkom

email : Lavitz1185@gmail.com
password : albertilkom

Pertama kali jalankan :
  - Update-Database -context AppDbContext
  - Update-Database -context IdentityContext

Ubah appsettings.json
  - Ubah "StoredFilesPath" dengan cara : 
    - Klik Kanan folder img di wwwroot
    - Pilih Open Folder In File Explorer
    - Paste ke appsettings.json di "StoredFilesPath"
    - Contoh "StoredFilesPath": "D:\\latihan\\WebSITE\\webSITE\\webSITE\\webSITE\\wwwroot\\img\\"
    - Save lalu Update-Database

Link Dashboard
http://localhost:8802/Dashboard/