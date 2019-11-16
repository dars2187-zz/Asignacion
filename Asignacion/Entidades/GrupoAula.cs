using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asignacion.Entidades
{
    public class GrupoAula
    {
        public int idgrupo { get; set; }
        public Grupo grupo { get; set; }
        public int idaula { get; set; }
        public Aula aula { get; set; }
    }
}
