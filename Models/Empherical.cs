using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiricalStatistics_Web_App.Models
{
    public class Empirical

    {


        [Required(ErrorMessage ="Should be a number")]

        public int Amount { get; set; }


        [Required(ErrorMessage = "Should be a number")]
        [Range(-1000, 1000, ErrorMessage = "Should be a number between -1000 and 1000")]

        public int LowerLimit { get; set; }


        [Required(ErrorMessage = "Should be a number")]
        [Range(-1000, 1000, ErrorMessage = "Should be a number between -1000 and 1000")]

        

        public int UpperLimit { get; set; }

       

        private double[] empiricalList;




        public void SetValue()
        {

            empiricalList = new double[Amount];
            Random random = new Random();

            for (int i = 0; i < empiricalList.Length; i++)
            {
                empiricalList[i] = random.Next(LowerLimit, UpperLimit + 1) / 10.0;
            }

        }

        public double[] GetArray()
        {
         
            return empiricalList;
        }

        public double AverageEmpirical()
        {
            double suma = 0;

            foreach (var list in empiricalList)
            {
                suma += list;
            }
            return suma / empiricalList.Length;
        }

        public double Median()
        {
            double[] temp = empiricalList.ToArray();

            Array.Sort(temp);

            int length = temp.Length;

            if (length == 0)
            {
                return -1;
            }
            else if (length % 2 == 0)
            {
                double a = temp[length / 2 - 1];
                double b = temp[length / 2];

                return (a + b) / 2.0;
            }
            else
            {
                return temp[length / 2];
            }
        }

        public double Mode()
        {
            if (empiricalList.Length == 0)
                throw new ArgumentException("Array can not be empty");
            
            Dictionary<double, int> dict = new Dictionary<double, int>();

            foreach (var list in empiricalList)
            {
                if (dict.ContainsKey(list))
                {
                    dict[list]++;
                }
                else
                {
                    dict.Add(list, 1);
                }
            }

            int max = 0;
            double moda = 0;

            foreach (var list in dict)
            {
                if (list.Value > max)
                {
                    max = list.Value;
                    moda = list.Key;
                }
            }
            return moda;
        }

        public double DataSwing()
        {
            double max = empiricalList.Max();
            double min = empiricalList.Min();

            return max - min;
        }

        public double Dispercion()
        {
            double _x = AverageEmpirical();

            double suma = 0;

            foreach (var list in empiricalList)
            {
                suma += Math.Pow((list - _x), 2);
            }
            return suma / empiricalList.Length;
        }

        public double Fluctuation()
        {
            double s = Dispercion();

            return Math.Sqrt(s);
        }

        public double Variation()
        {
            double S = Fluctuation();
            double _x = AverageEmpirical();

            return S / _x;
        }


        public double StartMoment4()
        {
            double suma = 0;

            foreach (var list in empiricalList)
            {
                suma += Math.Pow(list, 4);
            }
            return suma / empiricalList.Length;
        }

        public double StartMoment3()
        {
            double suma = 0;

            foreach (var list in empiricalList)
            {
                suma += Math.Pow(list, 3);
            }
            return suma / empiricalList.Length;
        }

        public double CentralMoment3()
        {
            double suma = 0;

            double _x = AverageEmpirical();
            foreach (var list in empiricalList)
            {
                suma += Math.Pow((list - _x), 3);
            }
            return suma / empiricalList.Length;
        }

        public double CentralMoment4()
        {
            double suma = 0;
            double _x = AverageEmpirical();

            foreach (var list in empiricalList)
            {
                suma += Math.Pow((list - _x), 4);
            }
            return suma / empiricalList.Length;
        }

        public double Asymmetry()
        {
            double central3 = CentralMoment3();
            double disper = Dispercion();

            return disper * Math.Pow(disper, 1) / central3;
        }

        public double Excess()
        {
            double disper = Dispercion();

            double central4 = CentralMoment4();

            return (Math.Pow(disper, 2) / central4) - 3;


        }

        public double CorrectDispecion()
        {
            double disper = Dispercion();

            return (empiricalList.Length / (empiricalList.Length - 1)) * disper;
        }

        

        public Dictionary<double, int> GetFrequencies()
        {
            Dictionary<double, int> dict = new Dictionary<double, int>();
            foreach (var list in empiricalList)
            {
                if (dict.ContainsKey(list))
                {
                    dict[list]++;
                }
                else
                {
                    dict.Add(list, 1);
                }
            }
            return dict;
        }
    }
}
