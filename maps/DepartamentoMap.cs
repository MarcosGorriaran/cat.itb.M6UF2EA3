
using cat.itb.M6UF2EA3.model;
using FluentNHibernate.Mapping;

namespace cat.itb.M6UF2EA3.maps
{
    public class DepartamentoMap : ClassMap<Departamento>
    {
        public DepartamentoMap() 
        {
            Table("departamentos");

            Id(dep => dep.ID);

            Map(dep => dep.Name).Column("dnombre");

            Map(dep => dep.Loc).Column("loc");

            HasMany(dep => dep.workers).KeyColumn("deptno").Cascade.AllDeleteOrphan();
        }
    }
}
