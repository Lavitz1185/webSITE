using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webSITE.Models
{
    public enum StatusAkun
    {
        Aktif,
        TidakAktif
    }

    public static class StatusAkunExtension
    {
        public static string ToString(StatusAkun status)
        {
            if (status == StatusAkun.Aktif)
                return "Aktif";
            else
                return "Tidak Aktif";
        }
    }
}
