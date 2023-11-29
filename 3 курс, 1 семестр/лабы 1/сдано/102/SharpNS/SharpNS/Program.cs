using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shapes;

namespace SharpNS {
    internal class Program {
        static void Main(string[] args) {
            shapes.circle c = new shapes.circle();
            c.draw();
            square s = new square();
            s.draw();
        }
    }
}

namespace baseshapes {

}
namespace shapes {
    using baseshapes;
    class circle : figure {
        public override void draw( ) {
            Console.WriteLine("circle");
        }
    }
    class square : figure {
        public override void draw( ) {
            Console.WriteLine("square");
        }
    }
}
namespace shapes {
    class figure {
        virtual public void draw( ) {
        }
    }
}