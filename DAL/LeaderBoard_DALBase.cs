using Placement_Preparation.Model;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace Placement_Preparation.DAL
{
    public class LeaderBoard_DALBase:Dal_Helper
    {
        # region LeaderBoard_Dalbase


        #region Method : dbo.API_Leaderboard_Selectall
        public List<Leaderboard> dbo_API_LeaderboardGetAll()
        {
            try
            {
                List<Leaderboard> listOfleaderborddata = new List<Leaderboard>();
                SqlDatabase sqlDatabase = new SqlDatabase(Constr);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("Pro_SelectAllLeaderboard");
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dataReader.Read())
                    {
                        Leaderboard LeaderboardModel = new Leaderboard();
                        LeaderboardModel.LeaderboardID = Convert.ToInt32(dataReader["LeaderboardID"]);
                        LeaderboardModel.Rank = Convert.ToInt32(dataReader["Rank"]);
                        LeaderboardModel.UserName = dataReader["UserName"].ToString();
                        LeaderboardModel.UserEmail = dataReader["UserEmail"].ToString();
                        LeaderboardModel.Score = Convert.ToInt32(dataReader["Score"]);
                        LeaderboardModel.UserImage = dataReader["UserImage"].ToString();
                        LeaderboardModel.Created = Convert.ToDateTime(dataReader["Created"].ToString());
                        LeaderboardModel.Modified = Convert.ToDateTime(dataReader["Modified"].ToString());
                        listOfleaderborddata.Add(LeaderboardModel);
                    }
                }
                return listOfleaderborddata;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #region Method : dbo.API_Leaderboard_SelectByID
        public Leaderboard dbo_API_Leaderboard_SelectByID(int LeaderboardID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(Constr);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("Pro_SelectLeaderboardById");
                sqlDatabase.AddInParameter(dbCommand, "@LeaderboardID", DbType.Int32, LeaderboardID);
                Leaderboard LeaderboardModel = new Leaderboard();
                using (IDataReader dataReader = sqlDatabase.ExecuteReader(dbCommand))
                {
                    dataReader.Read();
                    LeaderboardModel.LeaderboardID = Convert.ToInt32(dataReader["LeaderboardID"]);
                    LeaderboardModel.Rank = Convert.ToInt32(dataReader["Rank"]);
                    LeaderboardModel.UserName = dataReader["UserName"].ToString();
                    LeaderboardModel.UserEmail = dataReader["UserEmail"].ToString();
                    LeaderboardModel.Score = Convert.ToInt32(dataReader["Score"]);
                    LeaderboardModel.UserImage = dataReader["UserImage"].ToString();
                    LeaderboardModel.Created = Convert.ToDateTime(dataReader["Created"].ToString());
                    LeaderboardModel.Modified = Convert.ToDateTime(dataReader["Modified"].ToString());
                }
                return LeaderboardModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method : dbo.API_Leaderboard_deleteByID
        public bool dbo_API_LeaderboardID_delete(int LeaderboardID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(Constr);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("Pro_DeleteLeaderboard");
                sqlDatabase.AddInParameter(dbCommand, "@LeaderboardID", DbType.Int32, LeaderboardID);
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
                {
                    return true;
                }
                else { return false; }

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Method : dbo.API_Leaderboard_insert
        public bool dbo_API_Leaderboard_insert(Leaderboard leaderboard)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(Constr);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("Pro_InsertLeaderboard");
                sqlDatabase.AddInParameter(dbCommand, "@Rank", SqlDbType.Int, leaderboard.Rank);
                sqlDatabase.AddInParameter(dbCommand, "@UserName", SqlDbType.VarChar, leaderboard.UserName);
                sqlDatabase.AddInParameter(dbCommand, "@UserEmail", SqlDbType.VarChar, leaderboard.UserEmail);
                sqlDatabase.AddInParameter(dbCommand, "@Score", SqlDbType.Int, leaderboard.Score);
                sqlDatabase.AddInParameter(dbCommand, "@UserImage", SqlDbType.VarChar, leaderboard.UserImage);
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Method : dbo.API_Leaderboard_Update
        public bool dbo_API_Leaderboard_update(int LeaderboardID,Leaderboard leaderboard)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(Constr);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("Pro_UpdateLeaderboard");
                sqlDatabase.AddInParameter(dbCommand, "@LeaderboardID", SqlDbType.Int, leaderboard.LeaderboardID);
                sqlDatabase.AddInParameter(dbCommand, "@Rank", SqlDbType.Int, leaderboard.Rank);
                sqlDatabase.AddInParameter(dbCommand, "@UserName", SqlDbType.VarChar, leaderboard.UserName);
                sqlDatabase.AddInParameter(dbCommand, "@UserEmail", SqlDbType.VarChar, leaderboard.UserEmail);
                sqlDatabase.AddInParameter(dbCommand, "@Score", SqlDbType.Int, leaderboard.Score);
                sqlDatabase.AddInParameter(dbCommand, "@UserImage", SqlDbType.VarChar, leaderboard.UserImage);
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
        #endregion
    }
}
