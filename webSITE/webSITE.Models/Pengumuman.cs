using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webSITE.Domain.Abstractions;

namespace webSITE.Domain
{
    public class Pengumuman : Entity, IAuditableEntity
    {
        public string Judul { get; set; } = string.Empty;
        public string Isi { get; set; } = string.Empty;
        public bool IsPriority { get; set; }
        public DateTime AddedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public Foto? Foto { get; set; }
        public Mahasiswa? Creator { get; set; }
    }
}
