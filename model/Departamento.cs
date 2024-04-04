using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.M6UF2EA3.model
{
    public class Departamento
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Loc {  get; set; }
        public virtual IList<Empleado> workers { get; set; }

        public override string ToString()
        {
            return $"ID: {ID}\nName: {Name}\nLoc: {Loc}";
        }
    }
}
