using System;

namespace ModelLib
{
    public class Wine : IDomainObject
    {
        public int Id { get; set; }
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

        public override bool Equals(object obj)
        {
            if (obj is Wine other)
            {
                return string.Equals(Name, other.Name, StringComparison.OrdinalIgnoreCase) &&
                       string.Equals(Type, other.Type, StringComparison.OrdinalIgnoreCase) &&
                       string.Equals(Sugar, other.Sugar, StringComparison.OrdinalIgnoreCase) &&
                       string.Equals(Homeland, other.Homeland, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        public override string ToString()
        {
            if (Rating != 0)
                return $"{Name} ({Type}, {Sugar}, {Homeland}) Оценка:{Rating}";
            else
                return $"{Name} ({Type}, {Sugar}, {Homeland})";
        }
    }
}
