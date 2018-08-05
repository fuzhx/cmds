using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Security.Cryptography;

namespace eKing.CmdReadFileAndSendEmailOper.Classes.Utils
{
    public partial class Util
    {
        #region SendByNetMail|发送邮件

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="emailName">发送人的邮箱帐号|如:zhx-fu</param>
        /// <param name="emailSmtpServer">SMTP服务|如:10.2.1.78</param>
        /// <param name="emailSend">验证用户名(发送人的邮箱帐号：比如gzyy@gzycit.com)|如:zhx-fu@eking-tech.com</param>
        /// <param name="emailPwd">邮箱密码|如:xxxx</param>
        /// <param name="enableSsl">使用Ssl模式|默认:false</param>
        /// <param name="emailTitle">邮件标题|如:邮件标题</param>
        /// <param name="emailText">邮件内容|如:邮件内容</param>
        /// <param name="emailRecv">接收人邮箱帐号|如:89616537@qq.com</param>
        /// <param name="emailEncoding">邮件编码|如:Default</param>
        /// <param name="htmlFlag">是否Html模式</param> 
        /// <returns>字符串null或空代表成功；非空代表错误或异常（值为错误或异常的内容）</returns>
        public string SendByNetMail
            (
                string emailName,
                string emailSmtpServer,
                string emailSend,
                string emailPwd,
                bool enableSsl,
                string emailTitle,
                string emailText,
                string emailRecv,
                System.Text.Encoding emailEncoding,
                bool htmlFlag
            )
        {
            if (emailRecv == null || emailRecv.Length == 0)
            {
                return "接收地址为空。";
            }

            string theResult = string.Empty;

            // smtp验证类
            System.Net.Mail.SmtpClient _smtpClient = null;

            // Email消息
            System.Net.Mail.MailMessage _mailMessage = null;

            try
            {
                // smtp验证类
                _smtpClient = new System.Net.Mail.SmtpClient();

                _smtpClient.EnableSsl = enableSsl;

                // 指定电子邮件发送方式
                _smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;

                // 指定SMTP服务器
                _smtpClient.Host = emailSmtpServer;


                _smtpClient.Credentials = new System.Net.NetworkCredential
                    (emailSend, emailPwd);

                // Email消息 //
                _mailMessage = new System.Net.Mail.MailMessage();

                string[] toEmailArray = emailRecv.Split(';');

                if (emailRecv != null)
                {
                    string strTmp = "";

                    foreach (string s in toEmailArray)
                    {
                        if (s == null)
                            continue;

                        strTmp = s.Trim();

                        if (strTmp.Length == 0)
                            continue;

                        // 接收Email
                        _mailMessage.To.Add(strTmp);
                    }
                }

                _mailMessage.From = new System.Net.Mail.MailAddress
                    (
                        emailSend,
                        emailName
                    );

                //主题
                _mailMessage.Subject = emailTitle;

                //内容
                _mailMessage.Body = emailText;

                //正文编码
                _mailMessage.BodyEncoding = emailEncoding;
                _mailMessage.SubjectEncoding = emailEncoding;


                //设置为HTML格式
                _mailMessage.IsBodyHtml = htmlFlag;

                //优先级
                _mailMessage.Priority = System.Net.Mail.MailPriority.Normal;

                _smtpClient.Send(_mailMessage); //发送邮件 
            }
            catch (Exception err)
            {
                theResult = "发送异常：" + err.Message;
            }
            finally
            {
                if (_mailMessage != null)
                    _mailMessage = null;

                if (_smtpClient != null)
                    _smtpClient = null;
            }

            return theResult;
        }

        #endregion SendByNetMail|发送邮件



    }
}
