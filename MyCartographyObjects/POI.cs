using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCartographyObjects
{
    public class POI : Coordonnees
    {
        #region VARIABLES_MEMBRES
        private string _description;
        #endregion

        #region PROPRIETES 
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        #endregion

        #region CONSTRUCTEURS
        public POI(double latitude = 50.610, double longitude = 5.510,string description ="HEPL"):base(latitude, longitude)
        {
            Description = description;
        }
        #endregion

        #region METHODES
        public override string ToString()
        {
            return base.ToString()+" Description: "+Description;
        }
        
        #endregion
    }
}
