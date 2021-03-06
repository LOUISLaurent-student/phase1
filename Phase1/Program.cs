﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using MyCartographyObjects;

namespace Phase1
{
    class Program
    {
        static void Main(string[] args)
        {

            Coordonnees c1 = new Coordonnees();
            Coordonnees c2 = new Coordonnees(45.789, 58.123);
            POI poi1 = new POI();
            POI poi2 = new POI(c1.Latitude, c2.Longitude, "test");

            Polyline pl1 = new Polyline();
            pl1.Add(c2);
            pl1.Add(c1);
            Polyline pl2 = new Polyline(Colors.Salmon,5);
            pl2.Add(new Coordonnees());
            pl2.Add(c1);
            pl2.Add(c1);

            Polygon plg1 = new Polygon();
            Polygon plg2 = new Polygon(Colors.Tomato,Colors.Silver,10);

            plg2.Add(new Coordonnees());
            plg2.Add(c2);
            plg2.Add(c2);

            c1.Draw();
            c2.Draw();

            poi1.Draw();
            poi2.Draw();

            pl1.Draw();
            pl2.Draw();

            plg1.Draw();
            plg2.Draw();

            List<CartoObj> Liste_cartoObjs = new List<CartoObj>()
            {
                c1,poi1,pl2,pl1,poi2,plg1,c2,plg2
            };

            foreach(CartoObj carto in Liste_cartoObjs)
            {
                carto.Draw();
            }

            List<CartoObj> Liste_IPointies = new List<CartoObj>();
            List<CartoObj> Liste_no_pointies = new List<CartoObj>();

            foreach (CartoObj obj in Liste_cartoObjs )
            {
               if(obj is IPointy)
               {
                    Liste_IPointies.Add(obj);
               }
               else
               {
                    Liste_no_pointies.Add(obj);
               }
            }
            Console.WriteLine("    ");
            Console.WriteLine("liste d'objet implémentant l’interface IPointy:");
            Console.WriteLine("    ");

            foreach (CartoObj pointy in Liste_IPointies)
            {
                pointy.Draw();
            }

            Console.WriteLine("    ");
            Console.WriteLine("liste d'objet n'implémentant pas l’interface IPointy:");
            Console.WriteLine("    ");

            foreach (CartoObj no_pointy in Liste_no_pointies)
            {
                no_pointy.Draw();
            }

            List<Polyline> polylines = new List<Polyline>();

            Polyline pl01 = new Polyline(Colors.Blue,10);
            pl01.Add(new Coordonnees(1.0,2.3));
            pl01.Add(new Coordonnees(4.5,6.7));
            pl01.Add(new Coordonnees(8.9,10.0));
            pl01.Add(new Coordonnees(11.12,13.14));
            Polyline pl02 = new Polyline(Colors.Red,20);
            pl02.Add(new Coordonnees(5.0,10.15));
            pl02.Add(new Coordonnees(20.25,30.35));
            pl02.Add(new Coordonnees(40.45,50.55));
            pl02.Add(new Coordonnees(60.65,70.75));
            Polyline pl03 = new Polyline(Colors.Yellow,30);
            pl03.Add(new Coordonnees(2.4, 6.8));
            pl03.Add(new Coordonnees(10.12,14.16));
            pl03.Add(new Coordonnees(16.18,20.22));
            pl03.Add(new Coordonnees(24.26,28.30));
            Polyline pl04 = new Polyline(Colors.White,40);
            pl04.Add(new Coordonnees(3.6,9.12));
            pl04.Add(new Coordonnees(15.18,21.24));
            pl04.Add(new Coordonnees(27.30,33.36));
            pl04.Add(new Coordonnees(39.42,45.48));
            Polyline pl05 = new Polyline(Colors.Black,50);
            pl05.Add(new Coordonnees(4.8,12.16));
            pl05.Add(new Coordonnees(20.24,28.32));
            pl05.Add(new Coordonnees(36.40,44.48));
            pl05.Add(new Coordonnees(52.56,60.64));

            polylines.Add(pl01);
            polylines.Add(pl02);
            polylines.Add(pl03);
            polylines.Add(pl04);
            polylines.Add(pl05);

            Console.WriteLine("   ");
            Console.WriteLine("liste de polylines avant tri sur longeur :");
            Console.WriteLine("  ");
            
            foreach(Polyline p in polylines)
            {
                p.Draw();
            }

            polylines.Sort();

            Console.WriteLine("   ");
            Console.WriteLine("liste de polylines après tri sur longueur :");
            Console.WriteLine("  ");

            foreach (Polyline p in polylines)
            {
                p.Draw();
            }

            MyPolylineBoundingBoxComparer polboxcomp = new MyPolylineBoundingBoxComparer();

            polylines.Sort(polboxcomp);

            Console.WriteLine("   ");
            Console.WriteLine("liste de polylines après tri sur surface boundingbox :");
            Console.WriteLine("  ");

            foreach (Polyline p in polylines)
            {
                p.Draw();
            }

            List<Polyline> polylines2 = new List<Polyline>();

            polylines2 = polylines.FindAll(X => X.Equals(pl03));

            Console.WriteLine("   ");
            Console.WriteLine("liste de polyline(s) dont la longueur est acceptablement égale à la longueur de la polyline => "+pl03+":");
            Console.WriteLine("  ");

            foreach (Polyline p in polylines2)
            {
                p.Draw();
            }

            Console.WriteLine("   ");
            Console.WriteLine("liste de polylines proche du point => "+poi2+" :");
            Console.WriteLine("  ");

            foreach (Polyline p in polylines)
            {
                if (p.IsPointClose(poi2.Latitude, poi2.Longitude,5))
                {
                    p.Draw();
                }
            }

            MyCartoObjComparer cartocomp = new MyCartoObjComparer();
            Liste_cartoObjs.Sort(cartocomp);

            Console.WriteLine("   ");
            Console.WriteLine("liste de CartoObj triées selon le nbre de coordonnées composant chacun des éléments:");
            Console.WriteLine("  ");

            foreach(CartoObj c in Liste_cartoObjs)
            {
                c.Draw();
            }

            Console.ReadKey();
        }
    }
}
