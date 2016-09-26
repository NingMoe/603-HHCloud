//using System;
//using System.Web.Http;
//using System.Threading.Tasks;
//using NLog;
//using HH.TiYu.Model;
//using HH.WebAPI.Model.Extension;
//using LJH.GeneralLibrary.Core.DAL;

//namespace HH.TiYu.Cloud.WebApi.Controller
//{
//    public class StudentsController : ApiController
//    {
//        #region 构造函数

//        #endregion

//        #region 公共方法
//        public async Task<IHttpActionResult> GetByID(string id)
//        {
//            var ret = await new StudentDAL(AppSetting.Current.ConnectStr).GetByIDAsync(id);
//            if (ret.Result == ResultCode.Successful)
//            {
//                if (ret.QueryObject != null) return Ok(ret.QueryObject);
//                return NotFound();
//            }
//            return InternalServerError(new Exception(ret.Message));
//        }

//        [Filter.HuihaiAuthenticationFilter]
//        [Authorize]
//        public async Task<IHttpActionResult> Post(Student s)
//        {
//            if (string.IsNullOrEmpty(s.ID)) return BadRequest("没有提供学号");
//            CommandResult ret = await new StudentDAL(AppSetting.Current.ConnectStr).SaveAsync(s);
//            if (ret.Result == ResultCode.Successful) return Created<Student>(string.Format("api/students/{0}/", s.ID), null);
//            return BadRequest(ret.Message);
//        }
//        #endregion
//    }
//}
