using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using HH.TiYu.Cloud.Model;
using HH.TiYu.Cloud.DAL;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.ExceptionHandling;

namespace HH.TiYu.Cloud.BLL
{
    /// <summary>
    ///用于从SysParameter表中保存或获取一些系统设置,这些设置的实例被序列化为XML字串保存在ParameterValue字段中
    /// </summary>
    public class SysParaSettingsBll
    {
        /// <summary>
        ///保存到数据库
        /// </summary>
        /// <param name="info"></param>
        public static CommandResult SaveSetting<T>(T info, string repUri) where T : class
        {
            try
            {
                SystemParameterBLL bll = new SystemParameterBLL(repUri);
                Type t = typeof(T);

                DataContractSerializer ser = new DataContractSerializer(t);
                using (MemoryStream stream = new MemoryStream())
                {
                    ser.WriteObject(stream, info);
                    stream.Position = 0;
                    byte[] data = new byte[stream.Length];
                    stream.Read(data, 0, (int)stream.Length);
                    string value = Encoding.UTF8.GetString(data);
                    SysparameterInfo para = new SysparameterInfo(t.Name, value, string.Empty);
                    return bll.Save(para);
                }
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex);
                return new CommandResult(ResultCode.Fail, ex.Message);
            }
        }

        /// <summary>
        /// 从数据库中获取对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetSetting<T>(string repUri) where T : class
        {
            try
            {
                SystemParameterBLL bll = new SystemParameterBLL(repUri);
                SysparameterInfo para = null;
                QueryResult<SysparameterInfo> result = null;

                Type t = typeof(T);
                result = bll.GetByID(t.Name);

                if (result.Result == ResultCode.Successful)
                {
                    para = result.QueryObject;
                    string value = para.Value;
                    if (!string.IsNullOrEmpty(value))
                    {
                        byte[] data = Encoding.UTF8.GetBytes(value);
                        using (MemoryStream stream = new MemoryStream(data))
                        {
                            stream.Position = 0;
                            DataContractSerializer ser = new DataContractSerializer(t);
                            return ser.ReadObject(stream) as T;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex);
            }
            return null;
        }

        /// <summary>
        /// 从持久层获取设置，如果不存在就创建一个
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetOrCreateSetting<T>(string repUri) where T : class ,new()
        {
            T t = GetSetting<T>(repUri);

            if (t == null)
            {
                t = new T();
            }
            return t;
        }
    }
}
