using System;

namespace DesignPattern
{
    public class Person
    {
        public string Name;
        public string Position;

        public override string ToString()
        {
            return $"{nameof(Name)}:{Name},{nameof(Position)}:{Position}";
        }
        public class Builder : PersonJobBuilder<Builder>
        {
            
        }
        public static Builder New => new Builder();
    }

    public abstract class PersonBuilder
    {
        protected Person person=new Person();
        public Person Build()
        {
            return person;
        }
    }
    public class PersonInfoBuilder<T>:PersonBuilder where T:PersonInfoBuilder<T>
    {
        public T called(string name)
        {
            person.Name = name;
            return (T)this;
        }
    }

    public class PersonJobBuilder<T> : PersonInfoBuilder<PersonJobBuilder<T>>
        where T : PersonJobBuilder<T>
    {
        public T WorkAs(string position)
        {
            person.Position = position;
            return (T) this;
        }
    }

    public class BuilderExec
    {
        public static void Execute()
        {
           var me= Person.New.called("Bimal").WorkAs("Engineer").Build();
            Console.WriteLine(me);
        }
    }
}