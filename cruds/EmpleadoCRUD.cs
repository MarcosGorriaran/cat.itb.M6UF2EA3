using cat.itb.M6UF2EA3.model;
using cat.itb.M6UF2EA3.connections;
using NHibernate;
using NHibernate.Criterion;

namespace cat.itb.M6UF2EA3.cruds
{
    public class EmpleadoCRUD
    {
        private ISession session = SessionFactoryCloudzt.Open<Empleado>();
        public Empleado SelectById(int id)
        {
            Empleado result;
            
                result = session.Get<Empleado>(id);
                
            return result;
        }
        public List<Empleado> SelectAll(Func<Empleado, bool> searchTarget)
        {
            List<Empleado> result;
            
                result = (session.Query<Empleado>().Where(searchTarget)).ToList();
                
            return result;
        }
        public List<Empleado> SelectAll(string hql)
        {
            IList<Empleado> emp;

            IQuery query = session.CreateQuery(hql);
            emp = query.List<Empleado>();

            return emp.ToList();
        }

        /**
         * With a List of ICriterion which is the equivalent of a list of conditions which
         * the method will use to build a Criteria to end up returning a List of employees.
         */
        public List<Empleado> SelectAll(List<ICriterion> conditions)
        {

            ICriteria empCrit = session.CreateCriteria<Empleado>();

            foreach(ICriterion criterion in conditions)
            {
                empCrit.Add(criterion);
            }

            return empCrit.List<Empleado>().ToList();
        }
        public string Insert(Empleado employee)
        {
            string showInsertResult;
            
                using(ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(employee);
                    transaction.Commit();
                    showInsertResult = $"Departamento {employee.surname} ha sido insertado";
                }
            
            return showInsertResult;
        }
        public string InsertMany(List<Empleado> employees)
        {
            string showInsertResult="";
            foreach(Empleado employee in employees)
            {
                showInsertResult += Insert(employee)+Environment.NewLine;
            }
            return showInsertResult;
        }
        public void Update(Empleado employee)
        {
                using (ITransaction trans = session.BeginTransaction())
                {
                    session.Update(employee);
                    trans.Commit();
                }
        }
        public void Delete(Empleado employee)
        {
            
                using (ITransaction trans = session.BeginTransaction())
                {
                    session.Delete(employee);
                    trans.Commit();

                }
                
        }
    }
}
