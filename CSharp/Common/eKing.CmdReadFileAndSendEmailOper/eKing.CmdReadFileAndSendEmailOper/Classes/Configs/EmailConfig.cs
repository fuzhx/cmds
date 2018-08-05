using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using eKing.CmdReadFileAndSendEmailOper.Classes.Infos;

namespace eKing.CmdReadFileAndSendEmailOper.Classes.Configs
{
    /// <summary>
    /// Email的配置
    /// </summary>
    [Serializable]
    public class EmailConfig
        :
        BaseConfig
    {

        /// <summary>
        /// Email的配置
        /// </summary>
        public EmailConfig()
        {

        }

        /// <summary>
        /// 初始化逻辑类
        /// </summary>
        protected override void InitClass()
        {
            base.InitClass();

            InfoList = new List<BaseInfo>();
            ConfigNames.EmailConfigName ni = new ConfigNames.EmailConfigName();

            #region 构造


            #region EmailName ~ 发送人的邮箱帐号|如:zhx-fu

            m_EmailName = new StringInfo(ni.EmailName);
            InfoList.Add(m_EmailName);

            #endregion EmailName ~ 发送人的邮箱帐号|如:zhx-fu


            #region EmailSmtpServer ~ SMTP服务|如:10.2.1.78

            m_EmailSmtpServer = new StringInfo(ni.EmailSmtpServer);
            InfoList.Add(m_EmailSmtpServer);

            #endregion EmailSmtpServer ~ SMTP服务|如:10.2.1.78


            #region EmailSend ~ 发送人的邮箱帐号|如:zhx-fu@haihangyun.com

            m_EmailSend = new StringInfo(ni.EmailSend);
            InfoList.Add(m_EmailSend);

            #endregion EmailSend ~ 发送人的邮箱帐号|如:zhx-fu@haihangyun.com


            #region EmailPwd ~ 邮箱密码|如:abc123

            m_EmailPwd = new StringInfo(ni.EmailPwd);
            InfoList.Add(m_EmailPwd);

            #endregion EmailPwd ~ 邮箱密码|如:abc123


            #region EnableSsl ~ 使用Ssl模式|如:false

            m_EnableSsl = new BoolInfo(ni.EnableSsl);
            m_EnableSsl.InfoValue = false;
            InfoList.Add(m_EnableSsl);

            #endregion EnableSsl ~ 使用Ssl模式|如:false


            #region EmailRecv ~ 接收人邮箱帐号|如:89616537@qq.com;zhx-fu@haihangyun.com;

            m_EmailRecv = new StringInfo(ni.EmailRecv);
            InfoList.Add(m_EmailRecv);

            #endregion EmailRecv ~ 接收人邮箱帐号|如:89616537@qq.com;zhx-fu@haihangyun.com;


            #region EmailTitle ~ 邮件标题|如:{DateTime.Date}-发送邮件测试

            m_EmailTitle = new StringInfo(ni.EmailTitle);
            InfoList.Add(m_EmailTitle);

            #endregion EmailTitle ~ 邮件标题|如:{DateTime.Date}-发送邮件测试


            #region EmailText ~ 邮件内容|如:发送邮件测试成功

            m_EmailText = new StringInfo(ni.EmailText);
            InfoList.Add(m_EmailText);

            #endregion EmailText ~ 邮件内容|如:发送邮件测试成功


            #region EmailEncoding ~ 邮件编码|如:gb2312

            m_EmailEncoding = new StringInfo(ni.EmailEncoding);
            InfoList.Add(m_EmailEncoding);

            #endregion EmailEncoding ~ 邮件编码|如:gb2312


            #region HtmlFlag ~ 内容为Html模式|如:false

            m_HtmlFlag = new BoolInfo(ni.HtmlFlag);
            m_HtmlFlag.InfoValue = false;
            InfoList.Add(m_HtmlFlag);

            #endregion HtmlFlag ~ 内容为Html模式|如:false


            #region PwdTextType ~ 密码内容类型|text:明文;des3:des3加密|如:des3

            m_PwdTextType = new StringInfo(ni.PwdTextType);
            InfoList.Add(m_PwdTextType);

            #endregion PwdTextType ~ 密码内容类型|text:明文;des3:des3加密|如:des3



            #endregion 构造
        }


        #region 

        
        #region EmailName ~ 发送人的邮箱帐号|如:zhx-fu

        /// <summary>
        /// EmailName ~ 发送人的邮箱帐号|如:zhx-fu
        /// </summary>
        protected StringInfo m_EmailName = null;

        /// <summary>
        /// EmailName ~ 发送人的邮箱帐号|如:zhx-fu
        /// </summary>
        public StringInfo EmailName
        {
            get
            {
                return m_EmailName;
            }
        }

        #endregion EmailName ~ 发送人的邮箱帐号|如:zhx-fu


        #region EmailSmtpServer ~ SMTP服务|如:10.2.1.78

        /// <summary>
        /// EmailSmtpServer ~ SMTP服务|如:10.2.1.78
        /// </summary>
        protected StringInfo m_EmailSmtpServer = null;

        /// <summary>
        /// EmailSmtpServer ~ SMTP服务|如:10.2.1.78
        /// </summary>
        public StringInfo EmailSmtpServer
        {
            get
            {
                return m_EmailSmtpServer;
            }
        }

        #endregion EmailSmtpServer ~ SMTP服务|如:10.2.1.78


        #region EmailSend ~ 发送人的邮箱帐号|如:zhx-fu@haihangyun.com

        /// <summary>
        /// EmailSend ~ 发送人的邮箱帐号|如:zhx-fu@haihangyun.com
        /// </summary>
        protected StringInfo m_EmailSend = null;

        /// <summary>
        /// EmailSend ~ 发送人的邮箱帐号|如:zhx-fu@haihangyun.com
        /// </summary>
        public StringInfo EmailSend
        {
            get
            {
                return m_EmailSend;
            }
        }

        #endregion EmailSend ~ 发送人的邮箱帐号|如:zhx-fu@haihangyun.com


        #region EmailPwd ~ 邮箱密码|如:abc123

        /// <summary>
        /// EmailPwd ~ 邮箱密码|如:abc123
        /// </summary>
        protected StringInfo m_EmailPwd = null;

        /// <summary>
        /// EmailPwd ~ 邮箱密码|如:abc123
        /// </summary>
        public StringInfo EmailPwd
        {
            get
            {
                return m_EmailPwd;
            }
        }

        #endregion EmailPwd ~ 邮箱密码|如:abc123


        #region EnableSsl ~ 使用Ssl模式|如:false

        /// <summary>
        /// EnableSsl ~ 使用Ssl模式|如:false
        /// </summary>
        protected BoolInfo m_EnableSsl = null;

        /// <summary>
        /// EnableSsl ~ 使用Ssl模式|如:false
        /// </summary>
        public BoolInfo EnableSsl
        {
            get
            {
                return m_EnableSsl;
            }
        }

        #endregion EnableSsl ~ 使用Ssl模式|如:false


        #region EmailRecv ~ 接收人邮箱帐号|如:89616537@qq.com;zhx-fu@haihangyun.com;

        /// <summary>
        /// EmailRecv ~ 接收人邮箱帐号|如:89616537@qq.com;zhx-fu@haihangyun.com;
        /// </summary>
        protected StringInfo m_EmailRecv = null;

        /// <summary>
        /// EmailRecv ~ 接收人邮箱帐号|如:89616537@qq.com;zhx-fu@haihangyun.com;
        /// </summary>
        public StringInfo EmailRecv
        {
            get
            {
                return m_EmailRecv;
            }
        }

        #endregion EmailRecv ~ 接收人邮箱帐号|如:89616537@qq.com;zhx-fu@haihangyun.com;


        #region EmailTitle ~ 邮件标题|如:{DateTime.Date}-发送邮件测试

        /// <summary>
        /// EmailTitle ~ 邮件标题|如:{DateTime.Date}-发送邮件测试
        /// </summary>
        protected StringInfo m_EmailTitle = null;

        /// <summary>
        /// EmailTitle ~ 邮件标题|如:{DateTime.Date}-发送邮件测试
        /// </summary>
        public StringInfo EmailTitle
        {
            get
            {
                return m_EmailTitle;
            }
        }

        #endregion EmailTitle ~ 邮件标题|如:{DateTime.Date}-发送邮件测试


        #region EmailText ~ 邮件内容|如:发送邮件测试成功

        /// <summary>
        /// EmailText ~ 邮件内容|如:发送邮件测试成功
        /// </summary>
        protected StringInfo m_EmailText = null;

        /// <summary>
        /// EmailText ~ 邮件内容|如:发送邮件测试成功
        /// </summary>
        public StringInfo EmailText
        {
            get
            {
                return m_EmailText;
            }
        }

        #endregion EmailText ~ 邮件内容|如:发送邮件测试成功


        #region EmailEncoding ~ 邮件编码|如:gb2312

        /// <summary>
        /// EmailEncoding ~ 邮件编码|如:gb2312
        /// </summary>
        protected StringInfo m_EmailEncoding = null;

        /// <summary>
        /// EmailEncoding ~ 邮件编码|如:gb2312
        /// </summary>
        public StringInfo EmailEncoding
        {
            get
            {
                return m_EmailEncoding;
            }
        }

        #endregion EmailEncoding ~ 邮件编码|如:gb2312


        #region HtmlFlag ~ 内容为Html模式|如:false

        /// <summary>
        /// HtmlFlag ~ 内容为Html模式|如:false
        /// </summary>
        protected BoolInfo m_HtmlFlag = null;

        /// <summary>
        /// HtmlFlag ~ 内容为Html模式|如:false
        /// </summary>
        public BoolInfo HtmlFlag
        {
            get
            {
                return m_HtmlFlag;
            }
        }

        #endregion HtmlFlag ~ 内容为Html模式|如:false


        #region PwdTextType ~ 密码内容类型|text:明文;des3:des3加密|如:des3

        /// <summary>
        /// PwdTextType ~ 密码内容类型|text:明文;des3:des3加密|如:des3
        /// </summary>
        protected StringInfo m_PwdTextType = null;

        /// <summary>
        /// PwdTextType ~ 密码内容类型|text:明文;des3:des3加密|如:des3
        /// </summary>
        public StringInfo PwdTextType
        {
            get
            {
                return m_PwdTextType;
            }
        }

        #endregion PwdTextType ~ 密码内容类型|text:明文;des3:des3加密|如:des3



        #endregion 
    }
}
