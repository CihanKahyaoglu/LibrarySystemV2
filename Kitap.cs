using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHECKPOINT_TASK
{
    internal class Kitap
    {
        public string Baslik { get; set; }
        public string Yazar { get; set; }
        public string Tur { get; set; }
        public int Yil { get; set; }
        public Kitap(string baslik_, string _yazar, string _tür, int _yil)
        {
            Baslik = baslik_;
            Yazar = _yazar;
            Tur = _tür;
            Yil = _yil;
        }
    }
}
