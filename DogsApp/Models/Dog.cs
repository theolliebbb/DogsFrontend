using System;
using System.Collections.Generic;

namespace Dogs.Models
{
	public class Dog
	{
        public int id { get; set; }
        public string name { get; set; }
        public string breed { get; set; }
        public string image { get; set; }
        public int age { get; set; }
        public string temperament { get; set; }

    }
    public class DogLister
    {
        public Dog[] DogList { get; set; }

    }

}

