using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Islem;
using Toplama;

namespace Carpma
{
    public class Carpma : IHesap
    {
        public int Hesapla(int a, int b)
        {
            return a * b;
        }
        public string Isim
        {
            get
            {
                return "Carpma";
            }
        }
    }
}
