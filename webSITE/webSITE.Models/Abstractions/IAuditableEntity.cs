using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webSITE.Domain.Abstractions
{
    public interface IAuditableEntity
    {
        public DateTime AddedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public Mahasiswa? Creator { get; set; }
    }
}
