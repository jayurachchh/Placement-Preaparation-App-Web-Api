using Microsoft.AspNetCore.Mvc;
using Placement_Preparation.BAL;
using Placement_Preparation.Model;

namespace Placement_Preparation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaderboardController : ControllerBase
    {
        #region Model : LeaderboardController
        Leaderboard_BALBase leaderboard_BALBase =new Leaderboard_BALBase();

        #region GetAll
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            List<Leaderboard> LeaderboarddataList = leaderboard_BALBase.dbo_API_StatusGetAll();
            // Make the Response in Key Value Pair
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (LeaderboarddataList.Count > 0 && LeaderboarddataList != null)
            {
                response.Add("status", true);
                response.Add("message", "Data Found");
                response.Add("data", LeaderboarddataList);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found");
                response.Add("data", null);
                return NotFound(response);
            }
        }
        #endregion

        #region GetByID
        [HttpGet("Get{LeaderboardID}")]
        public IActionResult Get(int LeaderboardID)
        {
            Leaderboard leaderboard= leaderboard_BALBase.dbo_API_Leaderboard_SelectByID(LeaderboardID);
            // Make the Response in Key Value Pair
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (leaderboard.LeaderboardID != 0)
            {
                response.Add("status", true);
                response.Add("message", "Data Found");
                response.Add("data", leaderboard);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found");
                response.Add("data", null);
                return NotFound(response);
            }
        }
        #endregion

        #region Delete
        [HttpDelete("Delete{LeaderboardID}")]

        public ActionResult Delete(int LeaderboardID)
        {
            bool issuccess = leaderboard_BALBase.dbo_API_Leaderboard_DeleteByID(LeaderboardID);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (issuccess)
            {
                response.Add("status", true);
                response.Add("message", "Data Deleted");
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Deleted");
                return NotFound(response);
            }

        }
        #endregion

        #region Insert
        [HttpPost("Insert")]

        public ActionResult Insert([FromBody] Leaderboard leaderboard)
        {
            bool IsSuccess = leaderboard_BALBase.dbo_API_Leaderboard_Insert(leaderboard);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("status", true);
                response.Add("message", "Data Inserted");
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Inserted");
                return NotFound(response);
            }

        }
        #endregion

        #region Update
        [HttpPut("Update")]

        public ActionResult Update(int LeaderboardID, Leaderboard leaderboard)
        {
            bool IsSuccess = leaderboard_BALBase.dbo_API_Leaderboard_Update(LeaderboardID, leaderboard);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("status", true);
                response.Add("message", "Data Updated");
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Updated");
                return NotFound(response);
            }

        }
        #endregion
        #endregion
    }
}
