using System;
using System.Collections.Generic;

namespace DesignPattern
{
    public enum Color {Green,Red,Blue}
    public enum Size {Small,Large,Huge}
    public interface ISpecification<T>
    {
        bool IsStatisfied(T t);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }

    public class ColorSpecification : ISpecification<Product>
    {
        private Color color;

        public ColorSpecification(Color color)
        {
            this.color = color;
        }
        
        public bool IsStatisfied(Product t)
        {
            return t.color == color;
        }
    }

    public class Product
    {
        public Product(string name,Color color, Size size)
        {
            this.color = color;
            this.Name = name;
            this.size = size;
        }
        public Color  color { get; private set; }
        public string Name { get; private set; }
        public Size   size { get;  private set; }
    }

    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach(var i in items)
                if (spec.IsStatisfied(i))
                    yield return i;
        }
    }
    public  class ActivateOpenClose
    {
        public static void   CallFunction()
        {
            Console.WriteLine("Hello World!");

            var apple=new Product("Apple",Color.Green,Size.Small);
            var tree=new Product("Tree",Color.Green,Size.Large);
            var house=new Product("Apple",Color.Blue,Size.Large);

            Product[] products = {apple, tree, house};
            
            var bf=new BetterFilter();
            foreach (var p in bf.Filter(products,new ColorSpecification(Color.Green)))
            {
                Console.WriteLine($"-{p.Name} is green");
            }
        }
    }
    
}