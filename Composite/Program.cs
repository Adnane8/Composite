using System;
using System.Collections.Generic;
using System.Linq;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Leaf leaf1= new Leaf();
            Leaf leaf2= new Leaf();
            Leaf leaf3= new Leaf();
            Leaf leaf4= new Leaf();

            Composite composite1 = new Composite();
            Composite composite2 = new Composite();

            Client client1 = new Client();


            composite1.Add(leaf1);
            composite1.Add(leaf2);
            composite1.Add(leaf3);

            composite2.Add(leaf4);

            client1.ClientCode2(composite1, composite2);


        }
    }

    public abstract class Component
    {
        public abstract string Operation();

        public virtual void Add(Component component)
        {
            throw new NotImplementedException();
        }
        
        public virtual void Remove(Component component)
        {
            throw new NotImplementedException();
        }

        public virtual bool IsComposite()
        {
            return true;
        } 
    }

    public class Leaf : Component
    {
        public override string Operation()
        {
            return "Leaf";
        }

        public override bool IsComposite()
        {
            return false;
        }
    }

    public class Composite : Component
    {
        private List<Component> _Childs { get; set; } = new List<Component>();

        public override void Add(Component component)
        {
            _Childs.Add(component);
        }

        public override void Remove(Component component)
        {
            _Childs.Remove(component);
        }

        public override string Operation()
        {
            var result = "Branch (";
            if (_Childs.Any())
            {
                for(int i = 0; i < _Childs.Count; i++)
                {
                    result += _Childs[i].Operation();

                    if(i != _Childs.Count - 1)
                    {
                        result += "/";
                    }
                }
            }

            result += ")";

            return result;
        }
    }

    public class Client
    {
        public void ClientCode(Component leaf)
        {
            Console.WriteLine($"RESULT: {leaf.Operation()}\n");
        }

        public void ClientCode2(Component component1, Component component2)
        {
            if (component1.IsComposite())
            {
                component1.Add(component2);
            }

            Console.WriteLine($"RESULT: {component1.Operation()}");
        }
    }
}
