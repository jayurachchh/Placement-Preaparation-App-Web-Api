using Placement_Preparation.DAL;
using Placement_Preparation.Model;

namespace Placement_Preparation.BAL
{
    public class Leaderboard_BALBase
    {
        #region Model : Leaderboard_Balbase
        LeaderBoard_DALBase leaderBoard_DALBase = new LeaderBoard_DALBase();

        #region Method : dbo.API_Leaderboard_SelectAll
        public List<Leaderboard> dbo_API_StatusGetAll()
        {
            try
            {
                List<Leaderboard> LeaderboardModels = leaderBoard_DALBase.dbo_API_LeaderboardGetAll();
                return LeaderboardModels;
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
                Leaderboard leaderboard = leaderBoard_DALBase.dbo_API_Leaderboard_SelectByID(LeaderboardID);
                return leaderboard;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region Method : dbo.API_Leaderboard_DeleteByID
        public bool dbo_API_Leaderboard_DeleteByID(int LeaderboardID)
        {
            try
            {
                if (leaderBoard_DALBase.dbo_API_LeaderboardID_delete(LeaderboardID))
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

        #region Method : dbo.API_Leaderboard_Insert
        public bool dbo_API_Leaderboard_Insert(Leaderboard leaderboard)
        {
            try
            {
                if (leaderBoard_DALBase.dbo_API_Leaderboard_insert(leaderboard))
                {
                    return true;
                }
                else
                { return false; }

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Method : dbo.API_Leaderboard_Updateedbyid
        public bool dbo_API_Leaderboard_Update(int LeaderboardID, Leaderboard leaderboard)
        {
            try
            {
                if (leaderBoard_DALBase.dbo_API_Leaderboard_update(LeaderboardID,leaderboard))
                {
                    return true;
                }
                else
                { return false; }

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
