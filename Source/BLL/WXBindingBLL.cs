using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HH.TiYu.Cloud.Model;
using LJH.GeneralLibrary.Core.DAL;
using HH.TiYu.Cloud.DAL;

namespace HH.TiYu.Cloud.BLL
{
    public class WXBindingBLL : BLLBase<string, WXBinding>
    {
        #region 构造函数
        public WXBindingBLL(string repUri)
            : base(repUri)
        {

        }
        #endregion

        #region 重写基类方法
        public override CommandResult Delete(WXBinding info)
        {
            return base.Delete(info);
        }
        #endregion

        #region 公共方法 
        public CommandResult Register(string userWX, string publicWX, string studentID)
        {
            if (new StudentIDValidator().IsValid(studentID) == false) return new CommandResult(ResultCode.Fail, "学号格式不正确，只能包函字母或数字");
            var id = WXBinding.CreateBindingID(userWX, publicWX);
            var original = GetByID(id).QueryObject;
            if (original == null)
            {
                WXBinding b = new WXBinding() { ID = id, UserWX = userWX, PublicWX = publicWX, StudentID = studentID };
                return ProviderFactory.Create<IProvider<WXBinding, string>>(RepoUri).Insert(b);
            }
            else
            {
                WXBinding b = new WXBinding() { ID = id, UserWX = userWX, PublicWX = publicWX, StudentID = studentID };
                return ProviderFactory.Create<IProvider<WXBinding, string>>(RepoUri).Update(b, original);
            }
        }

        public CommandResult UnRegister(string userWX, string publicWX)
        {
            var id = WXBinding.CreateBindingID(userWX, publicWX);
            var original = GetByID(id).QueryObject;
            if (original != null) return ProviderFactory.Create<IProvider<WXBinding, string>>(RepoUri).Delete(original);
            return new CommandResult(ResultCode.Successful, string.Empty);
        }

        public string GetBindingStudentID(string userWX, string publicWX)
        {
            var id = WXBinding.CreateBindingID(userWX, publicWX);
            var original = GetByID(id).QueryObject;
            if (original != null) return original.StudentID;
            return null;
        }
        #endregion
    }
}
