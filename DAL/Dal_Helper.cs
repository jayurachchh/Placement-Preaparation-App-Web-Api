namespace Placement_Preparation.DAL
{
    #region Connection : DalHelper
    public class Dal_Helper
    {
        public static string Constr = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json").Build()
        .GetConnectionString("ConnectionString");
    }
    #endregion
}