using cat.itb.M6UF2EA3.model;
using cat.itb.M6UF2EA3.connections;
using NHibernate;

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
