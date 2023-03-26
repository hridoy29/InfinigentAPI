using DbExecutor;
using SecurityDAL;
using Sundorbon.Backend.SECURITY.SecurityBLL;
namespace SecurityBLL
{
    public static class Facade
    {


     
        public static AuditorBLL AuditorBLL { get { return new AuditorBLL(); } }
        public static IssuesBLL IssuesBLL { get { return new IssuesBLL(); } }
        public static ObservationBLL ObservationBLL { get { return new ObservationBLL(); } }
        public static BBDBLL BBDBLL { get { return new BBDBLL(); } }
        public static IdentityBLL IdentityBLL { get { return new IdentityBLL(); } }
        public static QuestionnaireNumberBLL QuestionnaireNumberBLL { get { return new QuestionnaireNumberBLL(); } }
        public static UserBLL UserBLL { get { return new UserBLL(); } }
        public static DistributorBLL DistributorBLL { get { return new DistributorBLL(); } }
        public static QuestionnaireTransactionBLL QuestionnaireTransactionBLL { get { return new QuestionnaireTransactionBLL(); } }
        public static ShortNoteBLL ShortNoteBLL { get { return new ShortNoteBLL(); } }
        public static AssetInfoBLL AssetInfoBLL { get { return new AssetInfoBLL(); } }
        public static AssetAuditNumberBLL AssetAuditNumberBLL { get { return new AssetAuditNumberBLL(); } }
        public static AssetAuditTransactionBLL AssetAuditTransactionBLL { get { return new AssetAuditTransactionBLL(); } }
        public static AssetConfigBLL AssetConfigBLL { get { return new AssetConfigBLL(); } }
        public static AssetDistributorBLL AssetDistributorBLL { get { return new AssetDistributorBLL(); } }
   
    }
}