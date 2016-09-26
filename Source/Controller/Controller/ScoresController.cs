//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web.Http;
//using System.Threading.Tasks; 
//using LJH.GeneralLibrary.Core.DAL;
//using LJH.GeneralLibrary;

//namespace HH.TiYu.Cloud.WebApi.Controller
//{
//    public class ScoresController : ApiController
//    {
//        private static List<PhysicalItem> _AllPhysicalItems = null;

//        #region 构造函数
//        public ScoresController()
//        {
//            if (_AllPhysicalItems == null)
//            {
//                _AllPhysicalItems = new PhysicalItemDAL(AppSetting.Current.ConnectStr).GetItemsAsync().Result.QueryObjects;
//            }
//        }
//        #endregion

//        private StudentScore ConvertToDTO(PhysicalScore score)
//        {
//            PhysicalItem pi = null;
//            if (_AllPhysicalItems != null && _AllPhysicalItems.Count > 0)
//            {
//                pi = _AllPhysicalItems.SingleOrDefault(it => it.ID == score.PhysicalItem);
//            }
//            return new StudentScore()
//            {
//                StudentID = score.StudentID,
//                Grade = score.Grade != null ? GradeHelper.Instance.GetName(score.Grade.Value) : null,
//                PhysicalItem = pi != null ? pi.Name : score.PhysicalItem.ToString(),
//                Unit = pi != null ? pi.Unit : null,
//                Score = pi != null ? pi.ConvertToStr(score.Score) : score.Score.ToString(),
//                Result = score.Result != null ? score.Result.Value.Trim().ToString() : null,
//                Rank = score.Rank,
//                Jiafen = score.Jiafen != null && score.Jiafen.Value != 0 ? score.Jiafen.Value.Trim().ToString() : null,
//            };
//        }

//        #region 公共方法
//        public async Task<IHttpActionResult> Get(Guid id)
//        {
//            QueryResult<PhysicalScore> ret = await new PhysicalScoreDAL(AppSetting.Current.ConnectStr).GetByIDAsync(id);
//            PhysicalScore score = ret.QueryObject;
//            if (score != null) return Ok(ConvertToDTO(score));
//            return NotFound();
//        }

//        [Route("api/scores/{sid}/")]
//        public async Task<IHttpActionResult> Get(string sid, int pid = 0, int grade = 0)
//        {
//            PhysicalScoreSearchCondition con = new PhysicalScoreSearchCondition();
//            con.StudentID = sid;
//            if (pid > 0) con.PhysicalItem = pid; //等于0表示不指定测试项目
//            if (grade > 0) con.Grade = grade; //等于0表示不指定年级

//            var ret = await new PhysicalScoreDAL(AppSetting.Current.ConnectStr).GetItemsAsync(con);
//            if (ret.Result == ResultCode.Successful)
//            {
//                if (ret.QueryObjects != null && ret.QueryObjects.Count > 0) return Ok(
//                    from it in ret.QueryObjects
//                    orderby it.Grade descending, it.PhysicalItem ascending
//                    select ConvertToDTO(it)
//                    );
//                return NotFound();
//            }
//            return InternalServerError(new Exception(ret.Message));
//        }

//        [Filter.HuihaiAuthenticationFilter]
//        [Authorize]
//        public async Task<IHttpActionResult> Post(PhysicalScore score)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }
//            var bll = new PhysicalScoreDAL(AppSetting.Current.ConnectStr);
//            CommandResult ret = await bll.SaveAsync(score);
//            if (ret != null && ret.Result == ResultCode.Successful) return Created<PhysicalScore>(string.Empty, null);
//            return BadRequest(ret.Message);
//        }
//        #endregion
//    }
//}
