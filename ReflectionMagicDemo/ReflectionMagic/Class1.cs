using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionMagicLibrary
{
    public class Foo1
    {
        private Foo2 GetOtherClass() { return new Foo2(); }
    }

    public class Foo2
    {
        private string SomeProp
        {
            get
            {
                return "dsds";
            }
        }
    }
}
