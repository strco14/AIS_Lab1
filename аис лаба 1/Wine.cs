using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace аис_лаба_1
{
    public class Wine
    {
        public string Name;
        public string Type;
        public string Sugar;
        public string Homeland;
        public int Rating = 0;
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
            if(Rating != 0) 
                return $"{Name} ({Type}, {Sugar}, {Homeland}) Оценка:{Rating}";
            else 
                return $"{Name} ({Type}, {Sugar}, {Homeland})";
        }
    }
    //public enum TypeWine
    //{
    //    Red,
    //    White
    //};
    //public enum SugarType
    //{
    //    Dry,
    //    Semidry,
    //    Sweet,
    //    Semisweet
    //};
    //public enum Country
    //{
    //    Italy,
    //    France,
    //    Russia,
    //    Spain,
    //    Argentina
    //};
}
