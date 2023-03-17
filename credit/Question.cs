using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace credit
{
    class Question
    {
        int id;
        string name;
        double weight;
        public int Id => id;
        public string Name => name;
        public double Weight => weight;
        public Question(int id, string name, double weight)
        {
            this.id = id;
            this.name = name;
            this.weight = weight;
        }
    }
}
