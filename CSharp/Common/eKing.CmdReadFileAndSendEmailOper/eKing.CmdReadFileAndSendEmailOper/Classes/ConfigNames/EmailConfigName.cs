using System;
using System.Collections.Generic;
using System.Text;

namespace eKing.CmdReadFileAndSendEmailOper.Classes.ConfigNames
{
    /// <summary>
    /// 邮件配置的名称
    /// </summary>
    public class EmailConfigName
        :
        BaseConfigName
    {
        /// <summary>
        /// 邮件配置的名称
        /// </summary>
        public EmailConfigName()
        {

        }

        #region 属性


        #region EmailName ~ 发送人的邮箱帐号|如:zhx-fu

        /// <summary>
        /// EmailName ~ 发送人的邮箱帐号|如:zhx-fu
        /// </summary>
        public string EmailName
        {
            get
            {
                return "EmailName";
            }
        }

        #endregion EmailName ~ 发送人的邮箱帐号|如:zhx-fu


        #region EmailSmtpServer ~ SMTP服务|如:10.2.1.78

        /// <summary>
        /// EmailSmtpServer ~ SMTP服务|如:10.2.1.78
        /// </summary>
        public string EmailSmtpServer
        {
            get
            {
                return "EmailSmtpServer";
            }
        }

        #endregion EmailSmtpServer ~ SMTP服务|如:10.2.1.78


        #region EmailSend ~ 发送人的邮箱帐号|如:zhx-fu@haihangyun.com

        /// <summary>
        /// EmailSend ~ 发送人的邮箱帐号|如:zhx-fu@haihangyun.com
        /// </summary>
        public string EmailSend
        {
            get
            {
                return "EmailSend";
            }
        }

        #endregion EmailSend ~ 发送人的邮箱帐号|如:zhx-fu@haihangyun.com


        #region EmailPwd ~ 邮箱密码|如:abc123

        /// <summary>
        /// EmailPwd ~ 邮箱密码|如:abc123
        /// </summary>
        public string EmailPwd
        {
            get
            {
                return "EmailPwd";
            }
        }

        #endregion EmailPwd ~ 邮箱密码|如:abc123


        #region EnableSsl ~ 使用Ssl模式|如:false

        /// <summary>
        /// EnableSsl ~ 使用Ssl模式|如:false
        /// </summary>
        public string EnableSsl
        {
            get
            {
                return "EnableSsl";
            }
        }

        #endregion EnableSsl ~ 使用Ssl模式|如:false


        #region EmailRecv ~ 接收人邮箱帐号|如:89616537@qq.com;zhx-fu@haihangyun.com;

        /// <summary>
        /// EmailRecv ~ 接收人邮箱帐号|如:89616537@qq.com;zhx-fu@haihangyun.com;
        /// </summary>
        public string EmailRecv
        {
            get
            {
                return "EmailRecv";
            }
        }

        #endregion EmailRecv ~ 接收人邮箱帐号|如:89616537@qq.com;zhx-fu@haihangyun.com;


        #region EmailTitle ~ 邮件标题|如:{DateTime.Date}-发送邮件测试

        /// <summary>
        /// EmailTitle ~ 邮件标题|如:{DateTime.Date}-发送邮件测试
        /// </summary>
        public string EmailTitle
        {
            get
            {
                return "EmailTitle";
            }
        }

        #endregion EmailTitle ~ 邮件标题|如:{DateTime.Date}-发送邮件测试


        #region EmailText ~ 邮件内容|如:发送邮件测试成功

        /// <summary>
        /// EmailText ~ 邮件内容|如:发送邮件测试成功
        /// </summary>
        public string EmailText
        {
            get
            {
                return "EmailText";
            }
        }

        #endregion EmailText ~ 邮件内容|如:发送邮件测试成功


        #region EmailEncoding ~ 邮件编码|如:gb2312

        /// <summary>
        /// EmailEncoding ~ 邮件编码|如:gb2312
        /// </summary>
        public string EmailEncoding
        {
            get
            {
                return "EmailEncoding";
            }
        }

        #endregion EmailEncoding ~ 邮件编码|如:gb2312


        #region HtmlFlag ~ 内容为Html模式|如:false

        /// <summary>
        /// HtmlFlag ~ 内容为Html模式|如:false
        /// </summary>
        public string HtmlFlag
        {
            get
            {
                return "HtmlFlag";
            }
        }

        #endregion HtmlFlag ~ 内容为Html模式|如:false


        #region PwdTextType ~ 密码内容类型|text:明文;des3:des3加密|如:des3

        /// <summary>
        /// PwdTextType ~ 密码内容类型|text:明文;des3:des3加密|如:des3
        /// </summary>
        public string PwdTextType
        {
            get
            {
                return "PwdTextType";
            }
        }

        #endregion PwdTextType ~ 密码内容类型|text:明文;des3:des3加密|如:des3



        #endregion 属性
    }
}
