using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace webSITE.Domain
{
    public enum JenisKelamin
    {
        LakiLaki, Perempuan
    }

    public static class JenisKelaminExtension
    {
        public static string ToString(JenisKelamin jk)
        {
            if (jk == JenisKelamin.LakiLaki)
                return "Laki - Laki";
            else
                return "Perempuan";
        }
    }
}