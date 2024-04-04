using cat.itb.M6UF2EA3.model;
using FluentNHibernate.Mapping;

namespace cat.itb.M6UF2EA3.maps
{
    public class EmpleadoMap : ClassMap<Empleado>
    {
        public EmpleadoMap() 
        {
            Table("empleados");

            Id(emp => emp.Id);

            Map(emp => emp.empno).Column("empno");
            Map(emp => emp.surname).Column("apellido");
            Map(emp => emp.job).Column("oficio");
            Map(emp => emp.boss).Column("dir");
            Map(emp => emp.AltDate).Column("fechaalt");
            Map(emp => emp.salary).Column("salario");
            Map(emp => emp.comision).Column("comision");

            References(emp=>emp.department).Column("deptno");
        }
    }
}
