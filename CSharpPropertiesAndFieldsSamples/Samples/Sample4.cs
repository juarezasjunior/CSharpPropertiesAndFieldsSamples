using System;
namespace CSharpPropertiesAndFieldsSamples.Samples
{
    public class Sample4
    {
        private int id;
        private string name;
        private int age;
        private string address;

        public int Id
        {
            get
            {
                return this.id;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value < 21)
                {
                    throw new Exception("You cannot add a person that are not 21 years old or more.");
                }

                this.age = value;
            }
        }
    }
}
