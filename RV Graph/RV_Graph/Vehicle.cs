using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RV_Graph
{
    class Vehicle
    {
        public int vehicle_ID;
        public String AnlikKonumX;  // anlik konumları rastgele ata
        public String AnlikKonumY;
        public String HedefKonumX;
        public String HedefKonumY;
        public List<Request> atananIstekler = new List<Request>();
        public int OrtalamaHiz;

    }
}
