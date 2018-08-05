
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace eKing.CmdReadFileAndSendEmailOper.Classes.Infos
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class IntInfo
        :
        BaseInfo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_TheName"></param>
        public IntInfo(string p_TheName)
            :
            base(p_TheName)
        {

        }

        #region InfoValue ~ 值

        /// <summary>
        /// InfoValue ~ 值
        /// </summary>
        protected int m_InfoValue = 0;

        /// <summary>
        /// InfoValue ~ 值
        /// </summary>
        public int InfoValue
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
        public override void InfoValueSet(string theValue, bool throwException)
        {
            if (theValue == null || theValue.Length == 0)
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
            int theResult = 0;

            if (int.TryParse(str, out theResult))
            {
                InfoValue = theResult;
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
                        + "theValue(" + theValue + ")"
                        + "为无效的类型值。"
                    );
            }
        }
    }
}
