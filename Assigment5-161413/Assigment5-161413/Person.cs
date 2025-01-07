using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment5_161413
{
    public enum Level
    {
        UnderWeight,
        Normal,
        OverWeight,
        Obesity
    };

    public enum PersonGender
    {
        Male,
        Female
    };
    public class Person : IComparable<Person>
    {
        string fullname;
        double weight;
        double height;
        PersonGender gender;
        
        public Person()
        {

        }
        public Person(string s, double weight, double height,string g)
        {
            this.fullname = s;
            this.weight = weight;
            this.height = height;
            if(g == "Male" || g == "male")
                gender = PersonGender.Male;
            else
            {
                gender = PersonGender.Female;
            }
        }

        public string Fullname { get => fullname; set => fullname = value; }
        public PersonGender Gender { get => gender; set => gender = value; }
        public double Weight { get => weight; set => weight = value; }
        public double Height { get => height; set => height = value; }


        public double BMI
        {
            get
            {
                return weight / Math.Pow(height, 2);
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

        public int CompareTo(Person other)
        {
            if(Program.key == 1)
                return other.fullname.CompareTo(this.fullname);
            else 
                return this.BMI.CompareTo(other.BMI);
        }

        public override string ToString()
        {
            return $"{fullname} {gender} {weight} {height}";
        }
    }


    
}
