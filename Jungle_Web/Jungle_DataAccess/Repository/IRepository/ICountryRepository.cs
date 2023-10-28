using Jungle_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Jungle_Models.Models;

namespace Jungle_DataAccess.Repository.IRepository
{
 
        public interface ICountryRepository : IRepository<Country>
        {
            void Update(Country country);
        }
    
}
