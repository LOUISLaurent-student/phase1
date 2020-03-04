using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyCartographyObjects
{
    public abstract class CartoObj: IIsPointClose
    {
        #region VARIABLES_MEMBRES
        private int _id;
        private static int _cpt = 0;
        #endregion

        #region PROPRIETES
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }


        #endregion

        #region CONSTRUCTEURS
        public CartoObj()
        {
            _cpt++;
            Id = _cpt;

        }
        #endregion

        #region METHODES
        public override string ToString()
        {
            return "id: "+Id;
        }
        public virtual void Draw()
        {
            Console.WriteLine(ToString());
        }

        public abstract bool IsPointClose(double Xi, double Yi, double precision);

        #endregion

    }
}
