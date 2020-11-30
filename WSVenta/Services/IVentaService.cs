using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSVenta.Models.Request;

namespace WSVenta.Services
{
    public interface IVentaService
    {
        public void Add(VentaRequest model);
    }
}
