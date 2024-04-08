namespace cat.itb.M6UF2EA3.model
{
    public class Empleado
    {
        public virtual int Id { get; set; }
        public virtual int empno { get; set; }
        public virtual string surname { get; set; }
        public virtual string job { get; set; }
        public virtual int boss { get; set; }
        public virtual DateTime AltDate { get; set; }
        public virtual float salary { get; set; }
        public virtual float? comision { get; set; }
        public virtual Departamento department { get; set; }

        public override string ToString()
        {
            return $"surname: {surname}\njob: {job}";
        }
    }
}
