using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MyCartographyObjects
{
    public class Polygon: CartoObj, IPointy
    {
        #region VARIABLES MEMBRES
        private List<Coordonnees> _listecoordonnees;
        private Color _couleurremplissage;
        private Color _couleurcontour;
        private double _niveauopacite;
        #endregion

        #region PROPRIETES
        public List<Coordonnees> Listecoordonnees
        {
            get { return _listecoordonnees; }
            set { _listecoordonnees = value; }
        }

        public Color Couleurremplissage
        {
            get { return _couleurremplissage; }
            set { _couleurremplissage = value; }
        }

        public Color Couleurcontour
        {
            get { return _couleurcontour; }
            set { _couleurcontour = value; }
        }

        public double Niveauopacite
        {

            get { return _niveauopacite; }
            set { _niveauopacite = value; }
        }
        #endregion

        #region CONSTRUCTEURS
        public Polygon() : this(Colors.White,Colors.Black, 1)
        {

        }
        public Polygon(Color couleurremplissage,Color couleurcontour, double niveauopacite)
        {
            Couleurremplissage = couleurremplissage;
            Couleurcontour = couleurcontour;
            Niveauopacite = niveauopacite;
            Listecoordonnees = new List<Coordonnees>();
        }
        #endregion

        #region METHODES
        public void Add(Coordonnees Coordonnees)
        {
            Listecoordonnees.Add(Coordonnees);
        }
        public void Remove(Coordonnees Coordonnees)
        {
            Listecoordonnees.Remove(Coordonnees);
        }
        public override string ToString()
        {
            string tempo = base.ToString() + " couleur de remplissage:" + Couleurremplissage+ " couleur de contour:"+Couleurcontour + " niveau d'opacité:"+Niveauopacite;

            foreach (Coordonnees c in Listecoordonnees)
            {
                tempo = tempo + " " + c;
            }

            return tempo;
        }
        public override void Draw()
        {
            Console.WriteLine(ToString());
        }

        public override bool IsPointClose(double Xi, double Yi,double precision)
        {
            double X_min = 0, X_max = 0, Y_min, Y_max = 0;

            X_min = X_max = Listecoordonnees.First().Longitude;
            Y_min = Y_max = Listecoordonnees.First().Latitude;

            foreach(Coordonnees c in Listecoordonnees)
            {
                if(c.Longitude > X_max)
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
                if(c.Latitude < Y_min)
                {
                    Y_min = c.Latitude;
                }

            }

            if(Xi >= X_min && Xi <= X_max  && Yi >= Y_min && Yi <= Y_max)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int NbPoints
        {

            get
            {
                int i = 0, idi = 0;


                if (Listecoordonnees.Count() > 0)
                {
                    i=1;
                    idi = Listecoordonnees.First().Id;

                    foreach (Coordonnees c in Listecoordonnees)
                    {


                        if (idi != c.Id)
                        {
                            i++;
                        }

                        idi = c.Id;


                    }
                }

                return i;
            }
        }
        #endregion
    }
}
