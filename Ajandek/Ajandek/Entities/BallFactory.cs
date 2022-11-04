using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajandek.Entities
{
    public class BallFactory
    {
        //public int MyProperty { get; set; }
        public Ball CreateNew()
        {
            return new Ball();
        }
    }
}
