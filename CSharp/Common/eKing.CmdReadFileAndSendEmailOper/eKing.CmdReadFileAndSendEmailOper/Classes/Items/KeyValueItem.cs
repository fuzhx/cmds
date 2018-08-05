using System;
using System.Collections.Generic;
using System.Text;

namespace eKing.CmdReadFileAndSendEmailOper.Classes.Items
{
    /// <summary>
    /// 控制台的每个参数的值
    /// </summary>
    [Serializable]
    public class KeyValueItem
    {
        /// <summary>
        /// 控制台的每个参数的值
        /// </summary>
        public KeyValueItem()
        {

        }

        #region ID ~ ID

        /// <summary>
        /// ID ~ ID|如:EmailName
        /// </summary>
        protected string m_ID = null;

        /// <summary>
        /// ID ~ ID|如:EmailName
        /// </summary>
        public string ID
        {
            get
            {
                return m_ID;
            }
            set
            {
                m_ID = value;
            }
        }

        #endregion ID ~ ID

        #region TheName ~ 值

        /// <summary>
        /// TheName ~ 值|如:zhx-fu
        /// </summary>
        protected string m_TheName = null;

        /// <summary>
        /// TheName ~ 值|如:zhx-fu
        /// </summary>
        public string TheName
        {
            get
            {
                return m_TheName;
            }
            set
            {
                m_TheName = value;
            }
        }

        #endregion TheName ~ 值

    }
}
