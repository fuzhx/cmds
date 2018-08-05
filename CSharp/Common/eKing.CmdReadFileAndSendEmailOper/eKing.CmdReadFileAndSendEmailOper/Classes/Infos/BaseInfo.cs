using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace eKing.CmdReadFileAndSendEmailOper.Classes.Infos
{
    /// <summary>
    /// 配置项
    /// </summary>
    [Serializable]
    public class BaseInfo
    {
      
        /// <summary>
        /// 配置项
        /// </summary>
        /// <param name="p_TheName"></param>
        public BaseInfo(string p_TheName)
        {
            m_TheName = p_TheName;
        }

        #region TheName ~ 名称

        /// <summary>
        /// TheName ~ 名称
        /// </summary>
        protected string m_TheName = null;

        /// <summary>
        /// TheName ~ 名称
        /// </summary>
        public string TheName
        {
            get
            {
                return m_TheName;
            } 
        }

        #endregion TheName ~ 名称

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual string InfoValueToString()
        {
            return "";
        }

       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="theValue"></param>
        /// <param name="throwException"></param>
        public virtual void InfoValueSet(string theValue, bool throwException)
        {

            throw new Exception
                (
                    "方法："
                    + MethodBase.GetCurrentMethod().ReflectedType.FullName
                    + " "
                    + MethodBase.GetCurrentMethod().ToString()
                    + " 发生异常："
                    + "该方法需要重载实现。"
                );
        }
    }
}
