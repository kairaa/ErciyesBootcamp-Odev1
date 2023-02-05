using DataAccess;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : class
    {
        private readonly NorthwndErciyesBootcampContext _context;

        public GenericManager(NorthwndErciyesBootcampContext context)
        {
            _context = context;
        }

    }
}
