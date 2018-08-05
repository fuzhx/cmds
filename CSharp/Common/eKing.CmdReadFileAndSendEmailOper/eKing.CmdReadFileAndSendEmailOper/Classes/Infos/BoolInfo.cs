
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace eKing.CmdReadFileAndSendEmailOper.Classes.Infos
{
    /// <summary>
    /// Boolean类型配置项
    /// </summary>
    [Serializable]
    public class BoolInfo
        :
        BaseInfo
    {
        /// <summary>
        /// Boolean类型配置项
        /// </summary>
        /// <param name="p_TheName">配置名</param>
        public BoolInfo(string p_TheName)
            :
            base(p_TheName)
        {

        }

        #region InfoValue ~ 值

        /// <summary>
        /// InfoValue ~ 值
        /// </summary>
        protected bool m_InfoValue = false;

        /// <summary>
        /// InfoValue ~ 值
        /// </summary>
        public bool InfoValue
        {
            get
            {
                return m_InfoValue;
            }
            set
            {
                m_InfoValue = value;
            }
        }

        #endregion InfoValue ~ 值


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string InfoValueToString()
        {
            return InfoValue.ToString();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="theValue"></param>
        /// <param name="throwException"></param>
        public override void InfoValueSet(string theValue,bool throwException)
        {
            if (theValue == null||theValue.Length == 0)
            {
                if (throwException)
                {
                    throw new Exception
                        (
                            "方法："
                            + MethodBase.GetCurrentMethod().ReflectedType.FullName
                            + " "
                            + MethodBase.GetCurrentMethod().ToString()
                            + " 发生异常："
                            + "传入的字符串参数："
                            + "theValue"
                            + "为null或为空。"
                        );
                }
            }

            string str = theValue.Trim().ToLower();

            if (str == "1" || str == true.ToString().ToLower())
            {
                InfoValue = true;
                return;
            }

            if (str == "0" || str == false.ToString().ToLower())
            {
                InfoValue = false;
                return;
            }

            if (throwException)
            {
                throw new Exception
                    (
                        "方法："
                        + MethodBase.GetCurrentMethod().ReflectedType.FullName
                        + " "
                        + MethodBase.GetCurrentMethod().ToString()
                        + " 发生异常："
                        + "传入的字符串参数："
                        + "theValue("+theValue+")"
                        + "为无效的类型值。"
                    );
            }
        }
    }
}
