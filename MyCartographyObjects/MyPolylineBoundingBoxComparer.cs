using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mathutil;

namespace MyCartographyObjects
{
    public class MyPolylineBoundingBoxComparer : IComparer<Polyline>
    {
        public int Compare(Polyline a, Polyline b)
        {

            double X_min = 0, X_max = 0, Y_min, Y_max = 0,largueur = 0 , longueur = 0, sa =0, sb =0;

            X_min = X_max = a.Listecoordonnees.First().Longitude;
            Y_min = Y_max = a.Listecoordonnees.First().Latitude;

            foreach (Coordonnees c in a.Listecoordonnees)
            {
                if (c.Longitude > X_max)
                {
                    X_max = c.Longitude;
                }

                if (c.Longitude < X_min)
                {
                    X_min = c.Longitude;
                }

                if (c.Latitude > Y_max)
                {
                    Y_max = c.Latitude;
                }
                if (c.Latitude < Y_min)
                {
                    Y_min = c.Latitude;
                }
            }


            longueur = MathUtil.distance_points(X_min, Y_min, X_max, Y_min);
            largueur = MathUtil.distance_points(X_min, Y_min, X_min, Y_max);

            sa = largueur * longueur;

            X_min = X_max = b.Listecoordonnees.First().Longitude;
            Y_min = Y_max = b.Listecoordonnees.First().Latitude;

            foreach (Coordonnees c in b.Listecoordonnees)
            {
                if (c.Longitude > X_max)
                {
                    X_max = c.Longitude;
                }

                if (c.Longitude < X_min)
                {
                    X_min = c.Longitude;
                }

                if (c.Latitude > Y_max)
                {
                    Y_max = c.Latitude;
                }
                if (c.Latitude < Y_min)
                {
                    Y_min = c.Latitude;
                }
            }


            longueur = MathUtil.distance_points(X_min, Y_min, X_max, Y_min);
            largueur = MathUtil.distance_points(X_min, Y_min, X_min, Y_max);

            sb = largueur * longueur;

            return sa.CompareTo(sb);      

        }
    }
}
