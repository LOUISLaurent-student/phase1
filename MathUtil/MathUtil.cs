using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mathutil
{
    public class MathUtil
    {
       public static double distance_points(double xa, double ya, double xb, double yb)
        {
            double ret = 0;

            ret = Math.Abs(Math.Sqrt(Math.Pow(xb-xa,2) + Math.Pow(yb-ya,2)));

            return ret;
        }

        public static double distance_segments_points(double x1, double y1, double x2, double y2, double xp, double yp)
        {
            double a = 0, b = 0,ret = 0; 


            a = (y2 - y1) / (x2 - x1); // pente de la droite 
            a = -a;
            b = (a * x1) - y1; // oordonnées à l'origine
            b = -b;

            ret = Math.Abs((a * xp) + yp + b) / Math.Sqrt(Math.Pow(a, 2) + 1); 
            /*  ci-dessus le calcul de la distance entre un point et un(e) (segment de) droite sachant que le coefficient du second
             membre est tjrs égal à 1  */


            return ret;

        }

    }
}
