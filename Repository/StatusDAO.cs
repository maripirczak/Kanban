using Domain;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
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

        public List<TipoStatus> ListarStatusPorNome() => _context.TipoStatus.ToList();


        public TipoStatus ListarStatusPorId(int id)
        {
            TipoStatus tipoStatus = _context.TipoStatus.FirstOrDefault(s => s.TipoStatusId == id);
            return tipoStatus;
        }

    }
}
