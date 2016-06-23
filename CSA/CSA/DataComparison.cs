using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSA
{
    public abstract class DataComparison: Form
    {
        public DataTable[] LagrangeMultipliersTable;

        public abstract void PerformComparison();

    }
}
