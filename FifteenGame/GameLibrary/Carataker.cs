using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    class Carataker
    {
        public Stack<Memento> Save;
        public Carataker()
        {
            Save = new Stack<Memento>();
        }
        public void SaveStep(Memento memento)
        {
            Save.Push(memento);
        }
        public Memento BackStep()
        {
           return Save.Pop();
        }
        ~Carataker() { }
    }
}
