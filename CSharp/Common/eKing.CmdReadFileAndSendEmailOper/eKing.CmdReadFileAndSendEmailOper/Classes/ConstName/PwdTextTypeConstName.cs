using System;
using System.Collections.Generic;
using System.Text;

namespace eKing.CmdReadFileAndSendEmailOper.Classes.ConstName
{
    /// <summary>
    /// 邮箱帐号密码的加密模式|明文/des3加密
    /// </summary>
    public class PwdTextTypeConstName
    {
        /// <summary>
        /// des3|des3加密
        /// </summary>
        public const string DES3 = "des3";

        /// <summary>
        /// text|明文
        /// </summary>
        public const string TEXT = "text";
    }
}
