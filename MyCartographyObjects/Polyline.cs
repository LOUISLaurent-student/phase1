using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using mathutil;

namespace MyCartographyObjects
{
    public class Polyline: CartoObj, IPointy, IComparable<Polyline>,IEquatable<Polyline>
    {
        #region VARIABLES MEMBRES
         private List<Coordonnees> _listecoordonnees;
         private Color _couleur;
         private int _epaisseur;
        
        #endregion

        #region PROPRIETES
        public List<Coordonnees> Listecoordonnees
        { 
            get { return _listecoordonnees; }
            set { _listecoordonnees = value; }
        }

        public Color Couleur
        {
            get { return _couleur; }
            set { _couleur = value; }
        }

        public int Epaisseur
        {

            get { return _epaisseur; }
            set { _epaisseur = value; }
        }


        #endregion

        #region CONSTRUCTEURS
        public Polyline():this(Colors.AliceBlue, 1)
        {
            
        }
        public Polyline(Color couleur, int epaisseur)
        {
            Couleur = couleur;
            Epaisseur = epaisseur;
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
            string tempo = base.ToString() + " epaisseur:"+Epaisseur + " couleur:"+Couleur;

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
            int i = 0;
            double resultat = 0;

            Coordonnees cprec = new Coordonnees();

            foreach (Coordonnees c in Listecoordonnees)
            {

                if(c.IsPointClose(Xi, Yi, precision))
                {
                    return true;
                }

                if( i > 0)
                {
                    resultat = MathUtil.distance_segments_points(cprec.Longitude,cprec.Latitude,c.Longitude,c.Latitude, Xi, Yi);
                    
                    if(resultat <= precision)
                    {
                        return true;
                    }
                }
                cprec.Latitude = c.Latitude;
                cprec.Longitude = c.Longitude;
                i++;

            }

            return false;
        }

       

        public int NbPoints
        {
            
            get {
                    int i = 0,idi = 0;

                    idi = Listecoordonnees.First().Id;


                    foreach (Coordonnees c in Listecoordonnees)
                    {
                    
                    
                        if( idi == c.Id)
                        {
                            i++;
                        }
                    
                        idi = c.Id;
                    

                    }

                    return i;
                }
        }

        public int CompareTo(Polyline other)
        {
            return Longueur().CompareTo(other.Longueur());
        }

        public double Longueur()
        {
            double longueur = 0;
            Coordonnees cprec = new Coordonnees(Listecoordonnees.First().Latitude, Listecoordonnees.First().Longitude);

            foreach(Coordonnees c in Listecoordonnees)
            {
                longueur = longueur + MathUtil.distance_points(cprec.Longitude, cprec.Latitude, c.Longitude, c.Latitude);
                cprec.Latitude = c.Latitude;
                cprec.Longitude = c.Longitude;
            }

            return longueur;

        }

        public bool Equals(Polyline other)
        {
            double difference = 0;

            difference = Math.Abs(Longueur() - other.Longueur());

           if(difference <= 5.0)
           {
                return true;
           }
           
            return false;
            
        }
        #endregion

    }
}
