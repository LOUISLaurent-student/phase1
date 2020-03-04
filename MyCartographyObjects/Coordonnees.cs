using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mathutil;

namespace MyCartographyObjects
{
    public class Coordonnees: CartoObj
    {
        #region VARIABLES_MEMBRES
        private double _longitude;
        private double _latitude;
        #endregion

        #region PROPRIETES 
        public double Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }

        public double Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }

        #endregion

        #region CONSTRUCTEURS
        public Coordonnees(double latitude = 0, double longitude = 0)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
        #endregion

        #region METHODES
        public override string ToString()
        {
           return  base.ToString()+" Coordonnees: " +"(" + Latitude.ToString("F3") + ";" + Longitude.ToString("F3") + ")";
        }
        public override  bool IsPointClose(double Xi, double Yi,double precision)
        {
           
            double test = 0;

            test = MathUtil.distance_points(Longitude,Latitude, Xi, Yi);

            if ( test <= precision)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }

        #endregion
    }
}
