using Ajandek.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajandek.Entities
{
    public class BallFactory:IToyFactory
    {
        //public int MyProperty { get; set; }
        public Toy CreateNew()
        {
            return new Ball();
        }

        public static implicit operator BallFactory(Car v)
        {
            throw new NotImplementedException();
        }
    }
}
