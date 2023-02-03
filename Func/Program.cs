using System;
using System.Linq.Expressions;

namespace Func
{
    class Program
    {
        static void Main(string[] args)
        {
            var objeto1 = new Objeto("mouse");
            var objeto2 = new Objeto("caneta");
            var objeto3 = new Objeto("teclado");

            Func<Objeto, bool> func = nome => nome.ObjectName.Length > 5;

            var obj1bol = func(objeto1);
            var obj2bol = func(objeto2);
            var obj3bol = func(objeto3);

            Console.WriteLine(obj1bol);
            Console.WriteLine(obj2bol);
            Console.WriteLine(obj3bol);

            Console.WriteLine("\nretorno depois de refenciar a função na func\n");

            func = RetornoFuncObj;

            obj1bol = func(objeto1);
            Console.WriteLine(obj1bol);

            obj2bol = func(objeto2);
            Console.WriteLine(obj2bol);

            obj3bol = func(objeto3);
            Console.WriteLine(obj3bol);

            Expression<Func<Objeto, bool>> expr = nome => nome.ObjectName.Length > 5;

            Func<Objeto, bool> func2 = expr.Compile();

            Console.WriteLine();
            Console.WriteLine(func2(objeto1));
            Console.WriteLine(func2(objeto2));
            Console.WriteLine(func2(objeto3));
        }

        static bool RetornoFuncObj(Objeto algum)
        {
            Console.WriteLine("String recebida: " + algum);

            if (algum.ObjectName.Length > 5)
            {
                return false;
            }

            return true;
        }
    }

    class Objeto
    {
        public Guid ObjectId { get; private set; }
        public string? ObjectName { get; private set; }

        public Objeto(string? objectName)
        {
            ObjectId = Guid.NewGuid();
            ObjectName = objectName;
        }

        public void ChangeObjectName(string name)
        {
            ObjectName = name;
        }

        public override string ToString()
        {
            return ObjectName;
        }
    }
}