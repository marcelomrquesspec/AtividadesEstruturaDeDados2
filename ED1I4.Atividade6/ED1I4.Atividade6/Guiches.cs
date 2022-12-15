using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED1I4.Atividade6
{
    public class Guiches
    {
        public List<Guiche> listaCuiches { get; }

        public Guiches()
        {
            listaCuiches = new List<Guiche>();
        }

        public void adicionar(Guiche guiche)
        {
            listaCuiches.Add(guiche);
        }
    }
}
