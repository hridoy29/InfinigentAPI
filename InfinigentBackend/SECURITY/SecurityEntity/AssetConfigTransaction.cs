using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinigentBackend.SECURITY.SecurityEntity
{
    public class AssetConfigTransaction
    {
        public LU_Asset_Config LU_Asset_Config { get; set; }

        public LU_Asset_Config_Photos LU_Asset_Config_Photos { get; set; }
        public string TransactionType { get; set; }

    }
}
