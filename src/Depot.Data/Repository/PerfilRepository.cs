using Depot.Business.Interfaces;
using Depot.Business.Models;
using Depot.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Depot.Data.Repository
{
    public class PerfilRepository : Repository<Perfil>, IPerfilRepository
    {
        public PerfilRepository(DepotContext context) : base(context) { }
       
    }
}
