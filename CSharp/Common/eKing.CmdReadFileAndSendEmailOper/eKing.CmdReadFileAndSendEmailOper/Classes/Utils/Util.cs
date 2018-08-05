using System;
using System.Collections.Generic;
using System.Text;
using eKing.CmdReadFileAndSendEmailOper.Classes.Items;
using eKing.CmdReadFileAndSendEmailOper.Classes.Configs;
using eKing.CmdReadFileAndSendEmailOper.Classes.ConstName;
using System.IO;

namespace eKing.CmdReadFileAndSendEmailOper.Classes.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Util
    {
        /// <summary>
        /// 
        /// </summary>
        public Util()
        {

        }
 
        /// <summary>
        /// 解密密码
        /// </summary>
        /// <param name="emailPwd"></param>
        /// <param name="pwdTextType"></param>
        /// <returns></returns>
        protected string PwdConvertTo(string emailPwd,string pwdTextType)
        {
            if(emailPwd==null||emailPwd.Length ==0)
                return "";

            if(pwdTextType==null)
                return "";

            pwdTextType = pwdTextType.Trim().ToLower();

            if(pwdTextType==PwdTextTypeConstName.DES3)
                return DES3De(emailPwd);

            return emailPwd;
        }

       
        /// <summary>
        /// 转义文本
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        protected string TextConvertTo(string str)
        {
            if (str == null)
            {
                return "";
            }

            str = str.Replace(TextConvertConstName.DATETIME_DATE,DateTime.Now.ToString("yyyy-MM-dd"));
            str = str.Replace(TextConvertConstName.DATETIME_TIME,DateTime.Now.ToString("HH:mm:ss"));
            str = str.Replace(TextConvertConstName.DATETIME_NOW,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            return str;
        }

        #region ExceptionGetInfo|打印和输出异常明细

        /// <summary>
        /// 打印和输出异常明细
        /// </summary>
        /// <param name="err"></param>
        /// <returns></returns>
        protected string ExceptionGetInfo(Exception err)
        {
            if (err == null)
            {
                return "Exception";
            }

            StringBuilder theResult = new StringBuilder();

            theResult.AppendLine("err.Message：" + err.Message);
            theResult.AppendLine("err.Source：" + err.Source);
            theResult.AppendLine("err.TargetSite：" + err.TargetSite.ReflectedType.FullName + " " + err.TargetSite.Name);
            theResult.AppendLine("err.StackTrace：" + err.StackTrace);

            return theResult.ToString();
        }

        #endregion ExceptionGetInfo|打印和输出异常明细


        /// <summary>
        /// 是否读取文件
        /// </summary>
        /// <param name="emailTextType"></param>
        /// <returns></returns>
        public bool IsReadFileOper(string emailTextType)
        {
            switch (emailTextType)
            {
                case "file":
                    return true;
                default:
                    return false;
            }
        }


        #region StrCharCount|字符串中含有strChar的字符串的个数统计

        /// <summary>
        /// 字符串中含有strChar的字符串的个数统计
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strChar"></param>
        /// <returns></returns>
        public int StrCharCount(string str, string strChar)
        {
            int theResult = 0;
            int idx = -1;

            string strItem = str;
            int charLen = strChar.Length;
            while (true)
            {
                idx = strItem.IndexOf(strChar);
                if (idx == -1)
                    return theResult;

                strItem = strItem.Substring(idx + charLen);
                ++theResult;

                if (strItem.Length == 0)
                    return theResult;
            }
        }

        #endregion 字符串中含有strChar的字符串的个数统计

        #region FileExpressValid|文件表达式校验|如果错误返回错误提示；正确返回string.Empty

        /// <summary>
        /// 文件表达式校验|如果错误返回错误提示；正确返回string.Empty
        /// </summary>
        /// <param name="fileExpress">文件表达式|如file*.log</param>
        /// <returns></returns>
        protected string FileExpressValid(string fileExpress)
        {

            if (fileExpress == null || fileExpress.Length == 0)
            {
                return "fileExpress为空，表达式错误";
            }

            fileExpress = fileExpress.Trim().ToLower();

            int charCount = StrCharCount(fileExpress, "*");

            if (charCount > 1)
            {
                return "fileExpress表达式错误，不能有多个*";
            }

            return "";
        }

        #endregion FileExpressValid|文件表达式校验|如果错误返回错误提示；正确返回string.Empty

        #region IsExpressFile|是否符合条件的文件名表达式

        /// <summary>
        /// 是否符合条件的文件名表达式
        /// </summary>
        /// <param name="fi">文件在FileInfo</param>
        /// <param name="fileExpress">文件表达式|如:file*.log</param>
        /// <returns></returns>
        protected bool IsExpressFile(FileInfo fi, string fileExpress, bool fileToLower)
        {
            return IsExpressFileByFileName(fi.Name, fileExpress, fileToLower);
        }

        #endregion IsExpressFile|是否符合条件的文件名表达式

        #region IsExpressFileByFileName|是否符合条件的文件名表达式

        /// <summary>
        /// 是否符合条件的文件名表达式
        /// </summary>
        /// <param name="fileName">文件名|如:filetext.log</param>
        /// <param name="fileExpress">文件表达式|如:file*.log</param>
        /// <returns></returns>
        public bool IsExpressFileByFileName(string fileName, string fileExpress, bool fileToLower)
        {
            if (fileName == null)
            {
                return false;
            }

            fileName = fileName.Trim();
            
            if (fileToLower)
            {
                fileName = fileName.ToLower();
            }

            if (fileExpress == null || fileExpress.Length == 0)
            {
                throw new Exception("fileExpress表达式错误");
            }

            // 文件表达式 //
            // gps_auto_backlog_*.log //
            fileExpress = fileExpress.Trim();

            if (fileToLower)
            {
                fileExpress = fileExpress.ToLower();
            }

            int charCount = StrCharCount(fileExpress, "*");

            if (charCount > 1)
            {
                throw new Exception("fileExpress表达式错误，不能有多个*");
            }

            if (charCount == 0)
            {
                if (fileExpress == fileName)
                    return true;

                return false;
            }

            string preChar = fileExpress;
            string endChar = "";



            int idx = fileExpress.IndexOf('*');

            // gps_auto_backlog_
            preChar = fileExpress.Substring(0, idx);

            // .log
            endChar = fileExpress.Substring(idx + 1);


            if (!fileName.EndsWith(endChar))
            {
                return false;
            }

            // gps_auto_backlog_0.log
            // gps_auto_backlog_0 //
            string preFileName = fileName.Substring(0, fileName.Length - endChar.Length);

            int preCharLen = preChar.Length;
            int preFileNameLen = preFileName.Length;

            if (preCharLen > preFileNameLen)
                return false;

            for (int i = 0; i < preCharLen; ++i)
            {
                if (preChar[i] == '?')
                    continue;

                if (preFileName[i] != preChar[i])
                {
                    return false;
                }
            }

            return true;
        }

        #endregion IsExpressFileByFileName|是否符合条件的文件名表达式

        #region FindLastFileName|通过目录名和文件表达式找到最近更新的文件

        /// <summary>
        /// 通过目录名和文件表达式找到最近更新的文件
        /// </summary>
        /// <param name="dirInfo">完整目录名|如:D:\Dbback\lookdaima</param>
        /// <param name="fileExpress">文件表达式|如:db*.log</param>
        /// <returns>完整在文件路径|如:D:\Dbback\lookdaima\db1.log</returns>
        protected string FindLastFileName(DirectoryInfo dirInfo, string fileExpress,bool fileToLower)
        {
            FileInfo[] fA = dirInfo.GetFiles();

            FileInfo curFile = null;

            foreach (FileInfo fi in fA)
            {
                if (!IsExpressFile(fi, fileExpress, fileToLower))
                    continue;

                if (curFile == null)
                {
                    curFile = fi;
                    continue;
                }

                if (fi.LastWriteTime > curFile.LastWriteTime)
                    curFile = fi;
            }


            if (curFile == null)
                return "";

            return curFile.FullName;

        }

        #endregion FindLastFileName|通过目录名和文件表达式找到最近更新的文件

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ec"></param>
        /// <returns></returns>
        protected string ToEmailText(ReadFileAndSendEmailConfig ec)
        {
            string dirName = ec.DirFullName.InfoValue;

            if (dirName == null || dirName.Length == 0)
            {
                return "[配置异常]:没有指定目录名";
            }

            dirName = dirName.Trim();

            if (dirName.Length == 0)
            {
                return "[配置异常]:没有指定目录名";
            }

            if (dirName == "~/")
            {
                // 如： D:\Projects\eKing.CmdCodeOper\eKing.CmdCodeOper\bin\Debug\
                dirName = System.AppDomain.CurrentDomain.BaseDirectory;
            }

            DirectoryInfo dirInfo = new DirectoryInfo(dirName);

            if (!dirInfo.Exists)
            {
                return "[配置异常]:"+dirInfo.FullName+"不存在";
            }

            string fileFullName = FindLastFileName(dirInfo, ec.FileNameExpress.InfoValue, ec.FileNameToLower.InfoValue);

            if (fileFullName == null || fileFullName.Length == 0)
            {
                return "[配置异常]:" + dirInfo.FullName + "下没有找到符合条件的文件";
            }

            FileInfo fi = new FileInfo(fileFullName);

            if (!fi.Exists)
            {
                return "[配置异常]:文件：" + fi.FullName + "不存在";
            }

            if (ec.EmailTextFileMaxLength.InfoValue > 0)
            {
                if (fi.Length > ec.EmailTextFileMaxLength.InfoValue)
                {
                    return "文件：" + fi.FullName + "过大，这里仅显示文件名";
                }
            }

            System.Text.Encoding en
                    =
                    EncodingGet(ec.ReadFileEncoding.InfoValue);
            try
            {
                return File.ReadAllText(fi.FullName, en);
            }
            catch (Exception err)
            {
                return "[读取文件异常]:(文件)" + fi.FullName + "(异常内容)" + err.Message;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ec"></param>
        /// <returns></returns>
        public string DoOper(ReadFileAndSendEmailConfig ec)
        {
            if (ec == null)
            {
                return "配置错误：ReadFileAndSendEmailConfig为null";
            }


            string validResult = ec.ValidConfig();

            if (validResult != null && validResult.Length > 0)
            {
                return validResult;
            }

            // 判断 //
            bool readFileFlag = IsReadFileOper(ec.EmailTextType.InfoValue);

            if (!readFileFlag)
            {
                string strEmailText = TextConvertTo(ec.EmailText.InfoValue);
                return SendEmail(ec, strEmailText); 
            }

            string emailText = ToEmailText(ec);


            return SendEmail(ec, emailText); 

        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="ec"></param>
        /// <param name="emailText"></param>
        /// <returns></returns>
        protected string SendEmail(EmailConfig ec,string emailText)
        {
            string theResult = "";

            try
            {

                string strEmailPwd = PwdConvertTo
                    (
                        ec.EmailPwd.InfoValue,
                        ec.PwdTextType.InfoValue
                    );

                string strEmailTitle = TextConvertTo(ec.EmailTitle.InfoValue);
                
                System.Text.Encoding emailEncoding
                    = 
                    EncodingGet(ec.EmailEncoding.InfoValue);

                theResult = SendByNetMail
                    (
                        ec.EmailName.InfoValue,
                        ec.EmailSmtpServer.InfoValue,
                        ec.EmailSend.InfoValue,
                        strEmailPwd,
                        ec.EnableSsl.InfoValue,
                        strEmailTitle,
                        emailText,
                        ec.EmailRecv.InfoValue,
                        emailEncoding,
                        ec.HtmlFlag.InfoValue
                    );
            }
            catch (Exception err)
            {
                string exceptionText = ExceptionGetInfo(err);
                return "系统异常：" + System.Environment.NewLine + exceptionText;
            }

            return theResult;
        }
    }
}
