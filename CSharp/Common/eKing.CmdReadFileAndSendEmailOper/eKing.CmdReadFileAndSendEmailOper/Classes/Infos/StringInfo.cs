using System;
using System.Collections.Generic;
using System.Text;

namespace eKing.CmdReadFileAndSendEmailOper.Classes.Infos
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class StringInfo
        :
        BaseInfo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_TheName"></param>
        public StringInfo(string p_TheName)
            :
            base(p_TheName)
        {

        }

        #region InfoValue ~ 值

        /// <summary>
        /// InfoValue ~ 值
        /// </summary>
        protected string m_InfoValue = null;

        /// <summary>
        /// InfoValue ~ 值
        /// </summary>
        public string InfoValue
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
            string str = InfoValue;

            if (str == null)
                return "";

            return str;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="theValue"></param>
        /// <param name="throwException"></param>
        public override void InfoValueSet(string theValue, bool throwException)
        {
            InfoValue = theValue;
        }
    }
}

