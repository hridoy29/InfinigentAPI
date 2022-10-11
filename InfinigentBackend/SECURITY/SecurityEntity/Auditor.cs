using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinigentBackend.SECURITY.SecurityEntity
{
   public class Auditor
    {
        public int Id { get; set; }
        public int UserGroupId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastAuditDate { get; set; }
    }
}
