using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFA_API.Services
{
    public class CFARepository : ICFARepository
    {
        private CFAContext _context;

        public CFARepository(CFAContext context)
        {
            _context = context;
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
