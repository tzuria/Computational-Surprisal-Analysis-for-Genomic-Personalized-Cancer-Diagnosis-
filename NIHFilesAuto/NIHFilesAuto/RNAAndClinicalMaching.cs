using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIHFilesAuto
{
    public class RNAAndClinicalMaching
    {
        string RNA { set; get; }
        string Clinical { set; get; }
        public RNAAndClinicalMaching(string rna, string clinical)
        {
            RNA = rna;
            Clinical = clinical;

        }
    }
}
