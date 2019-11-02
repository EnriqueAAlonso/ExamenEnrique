using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenEnrique.Classes;
namespace ExamenEnrique.Memento
{
    public class Memento
    {
        private User user;

        public Memento(User u)
        {
            this.user = u;
        }

        public User getState()
        {
            return user;
        }
    }

    public class Originator
    {
        private User state;

        public void setState(User s)
        {
            this.state = s;
        }

        public User getState()
        {
            return this.state;
        }

        public Memento SaveToMemento()
        {
            return new Memento(state);
        }

        public void GetStateFromMemento(Memento m)
        {
            state = m.getState();
        }

    }

    public class Caretaker
    {
        private List<Memento> mementos=new List<Memento>();

        public void AddMemento(Memento memento)
        {
            mementos.Add(memento);

        }

        public Memento GetMemento()
        {
            Memento outs =mementos[mementos.Count - 1];
            mementos.Remove(outs);
            return outs;
        }

        public int Size()
        {
            return mementos.Count;
        }
    }
}
