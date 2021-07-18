using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Data
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int number { get; set; }
        public int mouth { get; set; }
        public string clas { get; set; }
        
        public Data (int Id, string Name, int number, int mouth, string clas)
        {
            this.Id = Id;
            this.Name = Name;
            this.number = number;
            this.mouth = mouth;
            this.clas = clas;
        }
    }
}
