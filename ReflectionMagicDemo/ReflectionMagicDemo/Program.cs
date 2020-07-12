using ReflectionMagic;
using ReflectionMagicLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionMagicDemo
{
    /// <summary>
    /// ReflectionMagic     反射扩展库
    /// Github:https://github.com/ReflectionMagic/ReflectionMagic
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFrom("ReflectionMagicLibrary.dll");
            var fool1=assembly.CreateInstance("ReflectionMagicLibrary.Foo1");

            string val = fool1.AsDynamic().GetOtherClass().SomeProp;

            Console.ReadKey();
        }
    }
}
