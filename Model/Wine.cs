using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Model
{
    public class Wine:IDomainObject
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Sugar { get; set; }
        public string Homeland { get; set; }
        public int Rating { get; set; } = 0;
        public Wine(string name, string type, string sugar, string homeland)
        {
            Name = name;
            Type = type;
            Sugar = sugar;
            Homeland = homeland;
        }
        public Wine() { }
        public override string ToString()
        {
            if (Rating != 0)
                return $"{Name} ({Type}, {Sugar}, {Homeland}) Оценка:{Rating}";
            else
                return $"{Name} ({Type}, {Sugar}, {Homeland})";
        }
    }
}

