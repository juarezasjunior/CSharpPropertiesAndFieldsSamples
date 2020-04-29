using System;
namespace CSharpPropertiesAndFieldsSamples.Samples
{
    public class Sample3
    {
        private int id;
        private string name;
        private int age;
        private string address;

        public string GetName()
        {
            return this.name;
        }

        public void SetAge(int age)
        {
            if (age <= 21)
            {
                throw new Exception("You cannot add a person that are not 21 years old or more.");
            }

            this.age = age;
        }

        public int GetAge(int age)
        {
            return this.age;
        }

        public string GetAddress()
        {
            return this.address;
        }
    }
}
