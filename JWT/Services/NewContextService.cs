using JWT.Interfaces;
using JWT.Models;
using JWT.NewApplogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Services
{
    public class NewContextService : INewContextService
    {
        private readonly ApplicationContext _context;
        private Graph gragp { get; set; }

        public NewContextService(ApplicationContext _applicationContext) =>
           _context = _applicationContext;


    }
}
