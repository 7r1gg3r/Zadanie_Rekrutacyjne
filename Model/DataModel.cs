using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T_Komp_zadanie.Model
{
    public class DataModel //Stworzenie klasy jako szablon danych do implementacji przy generowaniu tabeli
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public DataModel(string name, string type="int")
        {
            Name = name;
            Type = type;
        }
    }
}
