using EkaRofl.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkaRofl.Tests.Classes
{
    /// <summary>
    /// Fake DbContext Implementation
    /// Implement an interface to make the bridge between reality and tests ;)
    /// Ex : IVirtualPortfolioEntities
    /// </summary>
    /// <version>0.1</version>
    /// <author>eka808</author>
    public class FakeDbContext : IEkaRoflEntities
    {        
        public IDbSet<EkaRofl.Data.Model.Banana> Bananas { get; set; }        

        /// Overload of the Set method of entity framework
        /// By default it's unusable in unit tests
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IDbSet<T> Set<T>() where T : class
        {
            var correspondingDbSets = this.GetType().GetProperties().Where(a => a.PropertyType == typeof(IDbSet<T>));

            if (correspondingDbSets.Count() == 1)
            {
                var correspondingProperty = correspondingDbSets.FirstOrDefault();
                return (IDbSet<T>)correspondingProperty.GetValue(this, null);
            }
            throw new Exception("Unexisting dbset");
        }

        public int SaveChanges()
        {
            return 0;
        }
    }
}
