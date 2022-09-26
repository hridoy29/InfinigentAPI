using DbExecutor;
using SecurityDAL;
using Sundorbon.Backend.SECURITY.SecurityBLL;
namespace SecurityBLL
{
    public static class Facade
    {


     
        public static AuditorBLL AuditorBLL { get { return new AuditorBLL(); } }
        public static DistributorBLL DistributorBLL { get { return new DistributorBLL(); } }
   
    }
}