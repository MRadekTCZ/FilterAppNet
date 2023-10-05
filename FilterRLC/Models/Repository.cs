using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace FilterRLC.Models
{
    public static class Repository
    {
        private static List<FilterParams> filters = new List<FilterParams>();
        public static IEnumerable<FilterParams> Filters => filters;

        public static double OutputVoltage(FilterParams filter, double? frequency)
        {
            double u1 = (double)filter.U1;
            double fmin = (double)filter.Fmin;
            double fmax = (double)filter.Fmax;
            double R1 = (double)filter.Resistance_1;
            double R2 = (double)filter.Resistance_2;
            double L1 = (double)filter.Inductance;
            double C1 = (double)filter.Capacitance;

            //---
            Complex Z1;
            Complex Z2;
            Complex Z3;
            Complex c_R1;
            Complex c_R2;
            Complex c_L;
            Complex c_C;
            Complex c_I1;
            Complex c_U1;
            Complex c_U2;
            Complex c_IL;
            double omega = (double)frequency * 2 * Math.PI;
            //Z1 = new Complex(u1, 0);
            //Z2 = new Complex((1 - omega * omega * L1 * C1), (omega * R1 * C1));
            //Z3 = Z1 / Z2;
            c_R1 = new Complex(R1, 0);
            c_R2 = new Complex(R2, 0);
            c_C = new Complex(0, (-1 / omega / C1));
            c_L = new Complex(0, (omega * L1));
            Z1 = c_R1 + 1/(1/c_C + 1/c_R2 + 1/c_L);
            c_U1 = new Complex(u1, 0);
            c_I1 = c_U1 / Z1;
            c_U2 = c_U1 - c_I1 * c_R1;


            return Math.Round(c_U2.Magnitude, 3);
        }

        public static void AddFilter(FilterParams filter)
        {
            filters.Add(filter);
        }

        public static void DeleteFilter(FilterParams filter)
        { 
            filters.Remove(filter);
        }
        public static void EditFilter(FilterParams newFilter, int ID)
        {
            
            int index = filters.FindIndex(f => f.ID == ID);
            //filters.Insert(ID, newFilter);
            filters.Insert(ID, newFilter);
            //filters.Insert(ID, newFilter);
            

        }


    }

}
