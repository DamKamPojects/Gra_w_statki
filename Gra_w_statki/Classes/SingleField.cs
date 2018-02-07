using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra_w_statki
{
    //clasa pojedynczego pola
    class SingleField
    {
        public int[] Cordinates = new int[2];
        public int Value;

        public SingleField(int value , int[] cordinates)
        {
            Value = value;
            Cordinates = cordinates;
        }
    }
}
