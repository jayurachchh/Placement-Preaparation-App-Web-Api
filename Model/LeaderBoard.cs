namespace Placement_Preparation.Model
{
    #region Model : Leaderboard
    public class Leaderboard
    {
        public int LeaderboardID { get; set; }
        public int Rank { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public int Score { get; set; }
        public string UserImage { get; set; }
        public DateTime? Created { get; set; } = null;
        public DateTime? Modified { get; set; } = null;
    }
    #endregion
}
