using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace credit
{
    class Group
    {
        int id;
        string name;
        double weight;
        List<Question> questions;
        public int Id => id;
        public string Name => name;
        public double Weight => weight;
        public List<Question> Questions => questions;
        public Group(int id, string name, double weight, List<Question> questions)
        {
            this.id = id;
            this.name = name;
            this.weight = weight;
            this.questions = new List<Question>(questions);
        }
    }
}
