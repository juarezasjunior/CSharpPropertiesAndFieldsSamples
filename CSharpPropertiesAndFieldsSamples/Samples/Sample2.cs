using System;
namespace CSharpPropertiesAndFieldsSamples.Samples
{
    public class Sample2
    {
        private readonly int id;
        private readonly string name;

        public Sample2(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public void AnotherMethod(int id, string name)
        {
            //You cannot set readonly fields outside the constructor

            //Try to uncomment the following lines and see the error
            //this.id = id;
            //this.name = name;
        }
    }
}
