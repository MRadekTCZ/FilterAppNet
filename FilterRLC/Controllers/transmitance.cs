using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Numerics;
namespace FilterRLC.Models
{
    public class Transmittance
    {
        public static List<object> GetTransmittance(FilterParams filter)
        {
            double u1 = (double)filter.U1;
            double fmin = (double)filter.Fmin;
            double fmax = (double)filter.Fmax;
            double R1 = (double)filter.Resistance_1;
            double R2 = (double)filter.Resistance_2;
            double L1 = (double)filter.Inductance;
            double C1 = (double)filter.Capacitance;
            int size = (int)filter.NumOfRows;
            //---
            List<object> results = new List<object>();
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
            double f = fmin;
            double df = (fmax - fmin) / (size - 1);
            double omega = 0;
            //---
            results.Add(new[] { "Frequency", "Amplitude", "Phase" });
            //---
            for (int i = 0; i < size; i++)
            {
                omega = 2 * Math.PI * f;
                //Z1 = new Complex(u1, 0);
                //Z2 = new Complex((1 - omega * omega * L1 * C1), (omega * R1 * C1));
                //Z3 = Z1 / Z2;
                c_R1 = new Complex(R1, 0);
                c_R2 = new Complex(R2, 0);
                c_C = new Complex(0, (-1 / omega / C1));
                c_L = new Complex(0, (omega*L1));
                Z1 = c_R1 + 1 / (c_C + c_R2 + c_L);
                c_U1 = new Complex(u1, 0);
                c_I1 = c_U1 / Z1;
                c_U2 = c_L * c_I1;
                Z3 = c_L / Z1;
                results.Add(new[] { f, Z3.Magnitude, Z3.Phase });
                f += df;
            }
            //---
            return results;
        }
        public static List<object> Envelope(FilterParams filter)
        {
            double u1 = (double)filter.U1;
            double fmin = (double)filter.Fmin;
            double fmax = (double)filter.Fmax;
            double R1 = (double)filter.Resistance_1;
            double R2 = (double)filter.Resistance_2;
            double L1 = (double)filter.Inductance;
            double C1 = (double)filter.Capacitance;
            int size = (int)filter.NumOfRows;
            //---
            List<object> results = new List<object>();
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
            double f = fmin;
            double df = (fmax - fmin) / (size - 1);
            double omega = 0;
            //---
            results.Add(new[] { "Frequency", "Amplitude" });
            //---
            for (int i = 0; i < size; i++)
            {
                omega = 2 * Math.PI * f;

                c_R1 = new Complex(R1, 0);
                c_R2 = new Complex(R2, 0);
                c_C = new Complex(0, (-1 / omega / C1));
                c_L = new Complex(0, (omega * L1));
                Z1 = c_R1 + 1 / (c_C + c_R2 + c_L);
                c_U1 = new Complex(u1, 0);
                c_I1 = c_U1 / Z1;
                c_U2 = c_L * c_I1;
                Z3 = c_L / Z1;
                results.Add(new[] { f, c_I1.Magnitude });
                f += df;
            }
            //---
            return results;
        }


    }

   
}
