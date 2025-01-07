using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assigment4_161413
{
    public enum Level
    {
        UnderWeight,
        Normal,
        OverWeight,
        Obesity
    };
    public class Person
    {
        double height, weight;
        string name;
        
        

        public Person(double w, double h, string n)
        {
            this.name = n;
            this.weight = w;
            this.height = h;
        }

        public Person()
        {

        }
        
        public double BMI
        {
            get
            {
                return weight / Math.Pow(height,2);
            }
        }

        public Level BMILevel
        {
            get
            {
                if (BMI < 18.5)
                    return Level.UnderWeight;
                else if (BMI <= 25)
                    return Level.Normal;
                else if (BMI <= 30)
                    return Level.OverWeight;
                else
                    return Level.Obesity;
                        
            }
        }



        public double Height
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public double Weight
        {
            get
            {
                return weight;
            }

            set
            {
                weight = value;
            }
        }

        

       
    }
}
