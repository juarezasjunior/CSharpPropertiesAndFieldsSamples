using System;
namespace CSharpPropertiesAndFieldsSamples.Samples
{
    public class Sample6
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; private set; }

        public Sample6(int id, string name, int age, string address)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.Address = address;
        }

        public void ChangeId(int newId)
        {
            this.Id = newId;
        }
    }

    public class UsingSample6
    {
        public void Using()
        {
            Sample6 sample6 = new Sample6(1, "John", 20, "20th street");

            sample6.Name = "Mary";

            //You cannot set a value for Id property, because the setter is private
            //Only the class can set its value
            //Uncomment the following line and you will see the error

            //sample6.Id = 15;
        }
    }
}
