using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinigentBackend.SECURITY.SecurityEntity
{
    public class LU_Asset_Config_Photos
    {

        public int Id { get; set; }
        public string AssetNumber { get; set; }
        public string ShopImage { get; set; }
        public string AssetImage { get; set; }
        public string SignImage { get; set; }
        public string CoolerImage { get; set; }
        public string ShortNote { get; set; }
        public string Remarks { get; set; }
    }
}
