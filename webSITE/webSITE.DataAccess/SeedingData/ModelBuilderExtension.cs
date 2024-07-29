using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webSITE.Domain;
using webSITE.Domain.Enum;

namespace webSITE.DataAccess.SeedingData
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder SeedingData(this ModelBuilder builder)
        {
            var fotoProfil = File.ReadAllBytes(@"wwwroot/img/student.png");

            var admin = new Mahasiswa[]
            {
                new Mahasiswa
                {
                    Id = "1",
                    Nim = "2206080051",
                    NamaLengkap = "Adi Juanito Taklal",
                    NamaPanggilan = "Adi",
                    TanggalLahir = new DateTime(2004, 2, 29),
                    JenisKelamin = JenisKelamin.LakiLaki,
                    FotoProfil = fotoProfil,
                    StatusAkun = StatusAkun.Aktif,
                    Bio = "Adi Juanito Taklal ILKOM #1",
                    Email = "aditaklal@gmail.com",
                    PasswordHash = new PasswordHasher<Mahasiswa>().HashPassword(null, "adiairnona"),
                    EmailConfirmed = true,
                    NormalizedEmail = "ADITAKLAL@GMAIL.COM",
                    UserName = "aditaklal@gmail.com",
                    NormalizedUserName = "ADITAKLAL@GMAIL.COM",
                },
                new Mahasiswa
                {
                    Id = "2",
                    Nim = "2206080016",
                    NamaLengkap = "Oswaldus Putra Fernando",
                    NamaPanggilan = "Fernand",
                    TanggalLahir = new DateTime(2004, 4, 14),
                    JenisKelamin = JenisKelamin.LakiLaki,
                    FotoProfil = fotoProfil,
                    StatusAkun = StatusAkun.Aktif,
                    Bio = "Oswaldus Putra Fernando ILKOM #1",
                    Email = "fernandputra14@gmail.com",
                    PasswordHash = new PasswordHasher<Mahasiswa>().HashPassword(null, "fernandilkom"),
                    EmailConfirmed = true,
                    NormalizedEmail = "fernandputra14@gmail.com".ToUpper(),
                    UserName = "fernandputra14@gmail.com",
                    NormalizedUserName = "fernandputra14@gmail.com".ToUpper(),
                },
                new Mahasiswa
                {
                    Id = "3",
                    Nim = "2206080095",
                    NamaLengkap = "Albert Berliano Tapatab",
                    NamaPanggilan = "Albert",
                    TanggalLahir = new DateTime(2004, 1, 7),
                    JenisKelamin = JenisKelamin.LakiLaki,
                    FotoProfil = fotoProfil,
                    StatusAkun = StatusAkun.Aktif,
                    Bio = "Albert Berliano Tapatab ILKOM #1",
                    Email = "Lavitz1185@gmail.com",
                    PasswordHash = new PasswordHasher<Mahasiswa>().HashPassword(null, "albertilkom"),
                    EmailConfirmed = true,
                    NormalizedEmail = "Lavitz1185@gmail.com".ToUpper(),
                    UserName = "Lavitz1185@gmail.com",
                    NormalizedUserName = "Lavitz1185@gmail.com".ToUpper(),
                },
            };

            builder.Entity<Mahasiswa>().HasData(admin);

            //var daftarMahasiswa = new Mahasiswa[]
            //{
            //    new Mahasiswa
            //    {
            //        Nim = "2206080001",
            //        NamaLengkap = "Michelle Maria Angely Rani Sani",
            //        NamaPanggilan = "Mici",
            //        JenisKelamin = JenisKelamin.Perempuan,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080002",
            //        NamaLengkap = "Inggi Rosina Nomleni",
            //        NamaPanggilan = "Inggi",
            //        JenisKelamin = JenisKelamin.Perempuan,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080003",
            //        NamaLengkap = "Varra Chandrika Kumara Tungga",
            //        NamaPanggilan = "Varra",
            //        JenisKelamin = JenisKelamin.Perempuan,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080004",
            //        NamaLengkap = "Diandra Lyan Bethseba Baun",
            //        NamaPanggilan = "Diandra",
            //        JenisKelamin = JenisKelamin.Perempuan,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080006",
            //        NamaLengkap = "Indah Inayah Rizkillah Enga",
            //        NamaPanggilan = "Indah",
            //        JenisKelamin = JenisKelamin.Perempuan,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080007",
            //        NamaLengkap = "Fransiska Odo",
            //        NamaPanggilan = "Cika",
            //        JenisKelamin = JenisKelamin.Perempuan,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080008",
            //        NamaLengkap = "Diego Junior Alexandro Lumba",
            //        NamaPanggilan = "Diego",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080009",
            //        NamaLengkap = "Ingratcia Oktaviana Nunes",
            //        NamaPanggilan = "Anna N",
            //        JenisKelamin = JenisKelamin.Perempuan,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080010",
            //        NamaLengkap = "Fila Inggriani Naitboho",
            //        NamaPanggilan = "Fila",
            //        JenisKelamin = JenisKelamin.Perempuan,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080011",
            //        NamaLengkap = "Stefanus Naibesi",
            //        NamaPanggilan = "Stef",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080012",
            //        NamaLengkap = "Mohamad Husain Oematan",
            //        NamaPanggilan = "Husein",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080013",
            //        NamaLengkap = "Ni Made Diah Sawitri",
            //        NamaPanggilan = "Diah",
            //        JenisKelamin = JenisKelamin.Perempuan,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080014",
            //        NamaLengkap = "Thirza Adristi Chandrakanti Putri Darmawan",
            //        NamaPanggilan = "Thirza",
            //        JenisKelamin = JenisKelamin.Perempuan,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080015",
            //        NamaLengkap = "Chendrika Saputri",
            //        NamaPanggilan = "Chen",
            //        JenisKelamin = JenisKelamin.Perempuan,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080017",
            //        NamaLengkap = "Dion Stekiko Melvin Tabelak",
            //        NamaPanggilan = "Dion",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080018",
            //        NamaLengkap = "Anlidua Lua Hingmadi",
            //        NamaPanggilan = "Lia",
            //        JenisKelamin = JenisKelamin.Perempuan,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080019",
            //        NamaLengkap = "Chantika Putri Mulandari",
            //        NamaPanggilan = "Umi",
            //        JenisKelamin = JenisKelamin.Perempuan,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080020",
            //        NamaLengkap = "Adriana Yohana Sain",
            //        NamaPanggilan = "Anna S",
            //        JenisKelamin = JenisKelamin.Perempuan,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080021",
            //        NamaLengkap = "Putri Sari Dewi",
            //        NamaPanggilan = "Putri",
            //        JenisKelamin = JenisKelamin.Perempuan,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080022",
            //        NamaLengkap = "Naldo Ferdinan Tajo Udju",
            //        NamaPanggilan = "Naldo",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080023",
            //        NamaLengkap = "Aleksander Geraldin Wadju",
            //        NamaPanggilan = "Gerald",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080024",
            //        NamaLengkap = "Aldy Verdynand Baria",
            //        NamaPanggilan = "Aldy",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080025",
            //        NamaLengkap = "Taufiq Kusuma",
            //        NamaPanggilan = "Taufiq",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080026",
            //        NamaLengkap = "Graciela Novita Silu Nenobahan",
            //        NamaPanggilan = "Grace",
            //        JenisKelamin = JenisKelamin.Perempuan,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080027",
            //        NamaLengkap = "Ruth Angel Pah",
            //        NamaPanggilan = "Uthe",
            //        JenisKelamin = JenisKelamin.Perempuan,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080028",
            //        NamaLengkap = "Imanuel Jeremiah Garis Ramba",
            //        NamaPanggilan = "Nuel",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080029",
            //        NamaLengkap = "Monica Anggreany Mbana",
            //        NamaPanggilan = "Anggy",
            //        JenisKelamin = JenisKelamin.Perempuan,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080030",
            //        NamaLengkap = "Patricia Margareth Monika",
            //        NamaPanggilan = "Cia",
            //        JenisKelamin = JenisKelamin.Perempuan,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080031",
            //        NamaLengkap = "Helena Alycia Liu",
            //        NamaPanggilan = "Chin",
            //        JenisKelamin = JenisKelamin.Perempuan,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080032",
            //        NamaLengkap = "Bernard Jose Adrian Junie Agilo Pa",
            //        NamaPanggilan = "King",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080033",
            //        NamaLengkap = "Fajar Akbarudin Rosnah Wangge",
            //        NamaPanggilan = "Fajar",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080034",
            //        NamaLengkap = "Zypora Ray Putri Blegur",
            //        NamaPanggilan = "Rara",
            //        JenisKelamin = JenisKelamin.Perempuan,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080035",
            //        NamaLengkap = "Joshua Aprivaldis Toelle",
            //        NamaPanggilan = "Valdis",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080036",
            //        NamaLengkap = "Gregorius Fredericus Tanusi",
            //        NamaPanggilan = "Igor",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080037",
            //        NamaLengkap = "Muh. Ramadhan Putra",
            //        NamaPanggilan = "Rama",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080038",
            //        NamaLengkap = "Putratama Clay Arnoldus",
            //        NamaPanggilan = "Ay",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080039",
            //        NamaLengkap = "Duta Arians Juanpieter Malelak",
            //        NamaPanggilan = "Duta",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080040",
            //        NamaLengkap = "Valensius Justicio Gaso Ari",
            //        NamaPanggilan = "Justin",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080041",
            //        NamaLengkap = "Mario Demetrio Tungga Gempa",
            //        NamaPanggilan = "Trio",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080042",
            //        NamaLengkap = "Adrian Teva Tetus Nau",
            //        NamaPanggilan = "Rian",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080043",
            //        NamaLengkap = "Rabil Sofian",
            //        NamaPanggilan = "Rabil",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080044",
            //        NamaLengkap = "Haris Alyano Amuntoda",
            //        NamaPanggilan = "Haris",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080045",
            //        NamaLengkap = "Christian Jaquelino Lamapaha",
            //        NamaPanggilan = "Jack",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080046",
            //        NamaLengkap = "Alfonsus Maria De Liguori Goru",
            //        NamaPanggilan = "Margo",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080047",
            //        NamaLengkap = "Rally Solendra Henuk",
            //        NamaPanggilan = "Rally",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080048",
            //        NamaLengkap = "Angela Wendelina Ome Longa",
            //        NamaPanggilan = "Bang Winda",
            //        JenisKelamin = JenisKelamin.Perempuan,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080049",
            //        NamaLengkap = "Olympio Bani",
            //        NamaPanggilan = "Pio",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080050",
            //        NamaLengkap = "Annika Laurensia Hipir",
            //        NamaPanggilan = "Nika",
            //        JenisKelamin = JenisKelamin.Perempuan,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080052",
            //        NamaLengkap = "Herijuart Djawa",
            //        NamaPanggilan = "Heri",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080052",
            //        NamaLengkap = "Herijuart Djawa",
            //        NamaPanggilan = "Heri",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080053",
            //        NamaLengkap = "Elisabeth Rika Suna Nahak",
            //        NamaPanggilan = "Rika",
            //        JenisKelamin = JenisKelamin.Perempuan,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080054",
            //        NamaLengkap = "Ade Karunia Taklal",
            //        NamaPanggilan = "Ade",
            //        JenisKelamin = JenisKelamin.Perempuan,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080055",
            //        NamaLengkap = "Benyamin Orison Darling Kana Wadu",
            //        NamaPanggilan = "Benya",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080056",
            //        NamaLengkap = "Savio Casimiro Soares",
            //        NamaPanggilan = "Lucky Besar",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080057",
            //        NamaLengkap = "Delisber Bana",
            //        NamaPanggilan = "Erik",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080058",
            //        NamaLengkap = "Nurul Afifah Nasir Karim",
            //        NamaPanggilan = "Ifa",
            //        JenisKelamin = JenisKelamin.Perempuan,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080059",
            //        NamaLengkap = "Bernadino Baitanu",
            //        NamaPanggilan = "Ardi",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080060",
            //        NamaLengkap = "Asnat Nofri Kenlopo",
            //        NamaPanggilan = "Nofi",
            //        JenisKelamin = JenisKelamin.Perempuan,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080061",
            //        NamaLengkap = "Yoseph Kurubingan Bekayo",
            //        NamaPanggilan = "Ocep",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080062",
            //        NamaLengkap = "William Ivander Lie",
            //        NamaPanggilan = "Koko",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080063",
            //        NamaLengkap = "Arni Yusfin Huan",
            //        NamaPanggilan = "Arni",
            //        JenisKelamin = JenisKelamin.Perempuan,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080064",
            //        NamaLengkap = "Iqbal Muhammad Iskandar",
            //        NamaPanggilan = "Iqbal",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080065",
            //        NamaLengkap = "Yongky Imanuel Yolimanto",
            //        NamaPanggilan = "Yongky",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080066",
            //        NamaLengkap = "Abiyyu Djakaria Zahran Atu",
            //        NamaPanggilan = "Abi",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080067",
            //        NamaLengkap = "Marthin Salvator Daniel Dima",
            //        NamaPanggilan = "Martin",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080068",
            //        NamaLengkap = "Joachim Filipo Seran",
            //        NamaPanggilan = "Ipo",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080069",
            //        NamaLengkap = "Patrisius Remby Lete",
            //        NamaPanggilan = "Pati",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080070",
            //        NamaLengkap = "Daniel Maubara",
            //        NamaPanggilan = "Dani",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080071",
            //        NamaLengkap = "Triyanto",
            //        NamaPanggilan = "Yanto",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080072",
            //        NamaLengkap = "Antonio Christian Allo",
            //        NamaPanggilan = "Gangsta Toni",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080073",
            //        NamaLengkap = "Anggi Tri Sujada Lifere",
            //        NamaPanggilan = "Anggi",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080074",
            //        NamaLengkap = "Daniel Wilhelm Valentino Likadja",
            //        NamaPanggilan = "Dave",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080075",
            //        NamaLengkap = "Grace Intan Bithauni Seran",
            //        NamaPanggilan = "Intan",
            //        JenisKelamin = JenisKelamin.Perempuan,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080076",
            //        NamaLengkap = "Djohan Rudolf Andriano Naatonis",
            //        NamaPanggilan = "Yanto",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080077",
            //        NamaLengkap = "Joey Elisa Pidu Dimu",
            //        NamaPanggilan = "Joey",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080078",
            //        NamaLengkap = "Bernaditho E. Sven De Rosari",
            //        NamaPanggilan = "Ditho",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080079",
            //        NamaLengkap = "Julian Excel Dama",
            //        NamaPanggilan = "Excel",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080080",
            //        NamaLengkap = "Ignasius K.Siuk Fios",
            //        NamaPanggilan = "Rocky",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080081",
            //        NamaLengkap = "Muhammad Ikhsan",
            //        NamaPanggilan = "Iksan",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080082",
            //        NamaLengkap = "Tamar Dian Ina Dappa Ole",
            //        NamaPanggilan = "Tamar",
            //        JenisKelamin = JenisKelamin.Perempuan,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080083",
            //        NamaLengkap = "Julius Sapitu",
            //        NamaPanggilan = "Juna",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080084",
            //        NamaLengkap = "Osintia Claudia Yanda",
            //        NamaPanggilan = "Osin",
            //        JenisKelamin = JenisKelamin.Perempuan,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080085",
            //        NamaLengkap = "Evelyn Ladystira Tade",
            //        NamaPanggilan = "Eve",
            //        JenisKelamin = JenisKelamin.Perempuan,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080086",
            //        NamaLengkap = "Fransiska Penina Neka",
            //        NamaPanggilan = "Nina",
            //        JenisKelamin = JenisKelamin.Perempuan,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080087",
            //        NamaLengkap = "Roberth Niclas Saamena",
            //        NamaPanggilan = "Obet",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080088",
            //        NamaLengkap = "Marshanda Angelic Rupidara",
            //        NamaPanggilan = "Shanda",
            //        JenisKelamin = JenisKelamin.Perempuan,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080089",
            //        NamaLengkap = "Naqia Yesoko Nggeok",
            //        NamaPanggilan = "Naqia",
            //        JenisKelamin = JenisKelamin.Perempuan,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080090",
            //        NamaLengkap = "Wildis Eko Y. Nabut",
            //        NamaPanggilan = "Wildis",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080091",
            //        NamaLengkap = "Margaritha Theresia Lubalu",
            //        NamaPanggilan = "Ritha",
            //        JenisKelamin = JenisKelamin.Perempuan,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080092",
            //        NamaLengkap = "Silvianus Adrian Seran",
            //        NamaPanggilan = "Ian",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080093",
            //        NamaLengkap = "Yoel Pratama Patty",
            //        NamaPanggilan = "Yoel",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080094",
            //        NamaLengkap = "Efrem Lucyano Syrilus Theodan",
            //        NamaPanggilan = "Lucky",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080096",
            //        NamaLengkap = "Ranti Ayu Ningtyas Koro",
            //        NamaPanggilan = "Ayu",
            //        JenisKelamin = JenisKelamin.Perempuan,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080097",
            //        NamaLengkap = "Gabriello Isak Valentino Gudu",
            //        NamaPanggilan = "Valen",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080098",
            //        NamaLengkap = "Beni Millian Liufeto",
            //        NamaPanggilan = "Bento",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },

            //    new Mahasiswa
            //    {
            //        Nim = "2206080099",
            //        NamaLengkap = "Willem Yufri Seran",
            //        NamaPanggilan = "Willem",
            //        JenisKelamin = JenisKelamin.LakiLaki,
            //    },
            //};

            //var defaultEmail = "site";
            //daftarMahasiswa = daftarMahasiswa.Select((m, i) => new Mahasiswa
            //{
            //    Id = (4 + i).ToString(),
            //    Nim = m.Nim,
            //    NamaLengkap = m.NamaLengkap,
            //    NamaPanggilan = m.NamaPanggilan,
            //    JenisKelamin = m.JenisKelamin,
            //    TanggalLahir = new DateTime(2005, 1, 1),
            //    FotoProfil = File.ReadAllBytes(fotoProfilPath1),
            //    StatusAkun = StatusAkun.Aktif,
            //    Bio = "ILKOM #1",
            //    Email = $"{defaultEmail}{i}@undana.ac.id",
            //    PasswordHash = new PasswordHasher<Mahasiswa>().HashPassword(null, "site"),
            //    EmailConfirmed = true,
            //    NormalizedEmail = $"{defaultEmail}{i}@undana.ac.id".ToUpper(),
            //    UserName = $"{defaultEmail}{i}@undana.ac.id",
            //    NormalizedUserName = $"{defaultEmail}{i}@undana.ac.id".ToUpper(),
            //}).ToArray();
            //builder.Entity<Mahasiswa>().HasData(daftarMahasiswa);

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "1",
                    Name = "Mahasiswa",
                    NormalizedName = "MAHASISWA"
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "3",
                    Name = "SuperAdmin",
                    NormalizedName = "SUPERADMIN"
                }
            );

            builder.Entity<IdentityUserRole<string>>().HasData
            (
                new IdentityUserRole<string>
                {
                    UserId = "1",
                    RoleId = "1",
                },
                new IdentityUserRole<string>
                {
                    UserId = "1",
                    RoleId = "2",
                },
                new IdentityUserRole<string>
                {
                    UserId = "1",
                    RoleId = "3",
                },
                new IdentityUserRole<string>
                {
                    UserId = "2",
                    RoleId = "1",
                },
                new IdentityUserRole<string>
                {
                    UserId = "2",
                    RoleId = "2",
                },
                new IdentityUserRole<string>
                {
                    UserId = "2",
                    RoleId = "3",
                },
                new IdentityUserRole<string>
                {
                    UserId = "3",
                    RoleId = "1",
                },
                new IdentityUserRole<string>
                {
                    UserId = "3",
                    RoleId = "2",
                },
                new IdentityUserRole<string>
                {
                    UserId = "3",
                    RoleId = "3",
                }
            );

            //builder.Entity<IdentityUserRole<string>>().HasData
            //(
            //    daftarMahasiswa.Select(m => new IdentityUserRole<string>
            //    {
            //        UserId = m.Id,
            //        RoleId = "1",
            //    }).ToArray()
            //);

            //builder.Entity<Kegiatan>().HasData(
            //    new Kegiatan
            //    {
            //        Id = 1,
            //        NamaKegiatan = "Foto Angkatan SITE",
            //        Tanggal = new DateTime(2023, 12, 03),
            //        JumlahHari = 1,
            //        Keterangan = "Kegiatan Pertama",
            //        TempatKegiatan = "Undana"
            //    },
            //    new Kegiatan
            //    {
            //        Id = 2,
            //        NamaKegiatan = "Kegiatan 1",
            //        Tanggal = new DateTime(2023, 12, 03),
            //        JumlahHari = 3,
            //        Keterangan = "Kegiatan Pertama",
            //        TempatKegiatan = "Undana"
            //    }
            //);

            //builder.Entity<PesertaKegiatan>().HasData(
            //    new PesertaKegiatan
            //    {
            //        IdKegiatan = 1,
            //        IdMahasiswa = "1",
            //    },
            //    new PesertaKegiatan
            //    {
            //        IdKegiatan = 1,
            //        IdMahasiswa = "2",
            //    },
            //    new PesertaKegiatan
            //    {
            //        IdKegiatan = 1,
            //        IdMahasiswa = "3",
            //    },
            //    new PesertaKegiatan
            //    {
            //        IdKegiatan = 2,
            //        IdMahasiswa = "2",
            //    }
            //);

            //string root = _photoFileSettings.StoredFilesPath;

            //builder.Entity<Foto>().HasData(
            //    new Foto
            //    {
            //        Id = 1,
            //        IdKegiatan = 1,
            //        PhotoPath = Path.Combine(root, "Front_Building.jpg"),
            //        Tanggal = new DateTime(2023, 12, 03),
            //    },
            //    new Foto
            //    {
            //        Id = 2,
            //        IdKegiatan = 2,
            //        PhotoPath = Path.Combine(root, "contoh.jpeg"),
            //        Tanggal = new DateTime(2023, 12, 04),
            //    },
            //    new Foto
            //    {
            //        Id = 3,
            //        IdKegiatan = 2,
            //        PhotoPath = Path.Combine(root, "contoh.jpeg"),
            //        Tanggal = new DateTime(2023, 12, 04),
            //    },
            //    new Foto
            //    {
            //        Id = 4,
            //        IdKegiatan = 2,
            //        PhotoPath = Path.Combine(root, "contoh.jpeg"),
            //        Tanggal = new DateTime(2023, 12, 05),
            //    },
            //    new Foto
            //    {
            //        Id = 5,
            //        IdKegiatan = 2,
            //        PhotoPath = Path.Combine(root, "contoh.jpeg"),
            //        Tanggal = new DateTime(2023, 12, 06),
            //    }
            //);

            //builder.Entity<MahasiswaFoto>().HasData(
            //    new MahasiswaFoto
            //    {
            //        IdFoto = 1,
            //        IdMahasiswa = "1",
            //    },
            //    new MahasiswaFoto
            //    {
            //        IdFoto = 1,
            //        IdMahasiswa = "2",
            //    },
            //    new MahasiswaFoto
            //    {
            //        IdFoto = 1,
            //        IdMahasiswa = "3",
            //    },
            //    new MahasiswaFoto
            //    {
            //        IdFoto = 2,
            //        IdMahasiswa = "2",
            //    },
            //    new MahasiswaFoto
            //    {
            //        IdFoto = 3,
            //        IdMahasiswa = "2",
            //    },
            //    new MahasiswaFoto
            //    {
            //        IdFoto = 4,
            //        IdMahasiswa = "2",
            //    },
            //    new MahasiswaFoto
            //    {
            //        IdFoto = 5,
            //        IdMahasiswa = "2",
            //    }
            //);

            builder.Entity<Pengumuman>().HasData(
                new Pengumuman
                {
                    Id = 1,
                    Judul = "Pentas Seni Ilmu Komputer 2024",
                    Isi = "Dengan bangga kami mengundang seluruh civitas akademika untuk menghadiri Pentas Seni Ilmu Komputer 2024 yang akan diselenggarakan pada tanggal 15 Agustus 2024 di Aula Utama Kampus. Acara ini akan menampilkan berbagai pertunjukan seni kreatif dari mahasiswa, termasuk tarian, drama, musik, dan pameran karya digital. ",
                    AddedAt = new DateTime(2024, 7, 11, 7, 0, 0, DateTimeKind.Local),
                    IsPriority = true,
                },
                new Pengumuman
                {
                    Id = 2,
                    Judul = "Dies Natalies Ilmu Komputer 2025 ",
                    Isi = "Coming Soon !!!!. ",
                    AddedAt = new DateTime(2024, 7, 11, 7, 0, 0, DateTimeKind.Local),
                    IsPriority = false,
                }
            );

            builder.Entity<Lomba>().HasData(
                new
                {
                    Id = 1,
                    Nama = "Menyanyi",
                    Jenis = JenisLomba.Solo,
                    Keterangan = "Keterangan",
                    MaksKuotaPerAngkatan = 2,
                    LinkGrupWa = new Uri("http://chat.whatsapp.com/IoP7JudZZfw79q4Hq2KjMM")
                },
                new
                {
                    Id = 2,
                    Nama = "Desain Poster",
                    Jenis = JenisLomba.Solo,
                    Keterangan = "Keterangan",
                    MaksKuotaPerAngkatan = 2,
                    LinkGrupWa = new Uri("http://chat.whatsapp.com/IoP7JudZZfw79q4Hq2KjMM")
                },
                new
                {
                    Id = 3,
                    Nama = "Menari",
                    Jenis = JenisLomba.Tim,
                    Keterangan = "Keterangan",
                    MaksKuotaPerAngkatan = 2,
                    MinAnggotaPerTim = 5,
                    MaksAnggotaPerTim = 10,
                    LinkGrupWa = new Uri("http://chat.whatsapp.com/IoP7JudZZfw79q4Hq2KjMM")
                },
                new
                {
                    Id = 4,
                    Nama = "Fashion Show",
                    Jenis = JenisLomba.Pasangan,
                    Keterangan = "Keterangan",
                    MaksKuotaPerAngkatan = 2,
                    PasanganBedaJenisKelamin = true,
                    LinkGrupWa = new Uri("http://chat.whatsapp.com/IoP7JudZZfw79q4Hq2KjMM")
                }
            );

            return builder;
        }
    }
}
