using System;
namespace CSharpPropertiesAndFieldsSamples.Samples
{
    public class Sample7
    {
        public int Id => 10;
        public string Name { get; set; } = "John";
        public int Age { get; private set; } = 21;
        public string Address { get; } = "20th avenue";
    }

    public class UsingSample7
    {
        public void Using()
        {
            Sample7 sample7 = new Sample7();

            sample7.Name = "Mary";

            //You cannot set a value for Id property, because the setter is private
            //Only the class can set its value
            //Uncomment the following line and you will see the error

            //sample7.Id = 20;
            //sample7.Age = 39;
            //sample7.Address = "Another street";
        }
    }
}
