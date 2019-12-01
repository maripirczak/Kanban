using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class StatusDAO
    {
        private readonly Context _context;

        public StatusDAO(Context context)
        {
            _context = context;
        }

        public List<Status> ListarTodos()
        {
            return _context.Status.ToList();
        }

    }
}
