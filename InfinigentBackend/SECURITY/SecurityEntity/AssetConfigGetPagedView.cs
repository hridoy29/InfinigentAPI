using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinigentBackend.SECURITY.SecurityEntity
{
    public class AssetConfigGetPagedView
    {
        public List<LU_Asset_Config> Asset_Configs { get; set; }
        public int TotalCount { get; set; }
    }
}
