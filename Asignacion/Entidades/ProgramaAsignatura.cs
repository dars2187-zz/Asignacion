using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asignacion.Entidades
{
    public class ProgramaAsignatura
    {
        public int idasignatura { get; set; }
        public Asignatura asignatura { get; set; }
        public int idprograma { get; set; }
        public Programa programa { get; set; }
    }
}
