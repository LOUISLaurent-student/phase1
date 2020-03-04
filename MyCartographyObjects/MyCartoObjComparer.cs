using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCartographyObjects
{
    public class MyCartoObjComparer : IComparer<CartoObj>
    {

            public int Compare(CartoObj a, CartoObj b)
            {
                int nba = 0, nbb = 0;

                if (a is IPointy)
                {
                    IPointy pa = (IPointy)a;

                    nba = pa.NbPoints;
                }
                else
                {
                    nba = 1;
                }

                if (b is IPointy)
                {
                    IPointy pb = (IPointy)b;

                    nbb = pb.NbPoints;
                }
                else
                {
                    nbb = 1;
                }

                return nba.CompareTo(nbb);
            }
        
    }
}

