using System;
using System.Collections.Generic;
using System.Text;

namespace eKing.CmdReadFileAndSendEmailOper.Classes.ConfigNames
{
    
    /// <summary>
    /// 
    /// </summary>
    public class ReadFileAndSendEmailConfigName
        :
        EmailConfigName
    {
        /// <summary>
        /// 
        /// </summary>
        public ReadFileAndSendEmailConfigName()
        {

        }

        #region

        #region EmailTextType ~ 邮件内容类型|text:纯文字；file:文件|如:text

        /// <summary>
        /// EmailTextType ~ 邮件内容类型|text:纯文字；file:文件|如:text
        /// </summary>
        public string EmailTextType
        {
            get
            {
                return "EmailTextType";
            }
        }

        #endregion EmailTextType ~ 邮件内容类型|text:纯文字；file:文件|如:text


        #region DirFullName ~ 完整的Dir名称|如：D:\one（无后缀）|或：~/执行程序所在的目录|如:~/

        /// <summary>
        /// DirFullName ~ 完整的Dir名称|如：D:\one（无后缀）|或：~/执行程序所在的目录|如:~/
        /// </summary>
        public string DirFullName
        {
            get
            {
                return "DirFullName";
            }
        }

        #endregion DirFullName ~ 完整的Dir名称|如：D:\one（无后缀）|或：~/执行程序所在的目录|如:~/


        #region FileNameExpress ~ 文件名表达式|如:*_bak.log

        /// <summary>
        /// FileNameExpress ~ 文件名表达式|如:*_bak.log
        /// </summary>
        public string FileNameExpress
        {
            get
            {
                return "FileNameExpress";
            }
        }

        #endregion FileNameExpress ~ 文件名表达式|如:*_bak.log


        #region ReadFileEncoding ~ 读取文件编码|gb2312/utf8|如:gb2312

        /// <summary>
        /// ReadFileEncoding ~ 读取文件编码|gb2312/utf8|如:gb2312
        /// </summary>
        public string ReadFileEncoding
        {
            get
            {
                return "ReadFileEncoding";
            }
        }

        #endregion ReadFileEncoding ~ 读取文件编码|gb2312/utf8|如:gb2312


        #region EmailTextFileMaxLength ~ 读取的文件允许最大值|如果是0，则不限，否则超过最大值就不需要读|B为单位|如:0

        /// <summary>
        /// EmailTextFileMaxLength ~ 读取的文件允许最大值|如果是0，则不限，否则超过最大值就不需要读|B为单位|如:0
        /// </summary>
        public string EmailTextFileMaxLength
        {
            get
            {
                return "EmailTextFileMaxLength";
            }
        }

        #endregion EmailTextFileMaxLength ~ 读取的文件允许最大值|如果是0，则不限，否则超过最大值就不需要读|B为单位|如:0

        #region FileNameToLower ~ 文件是否小写比较|如:true

        /// <summary>
        /// FileNameToLower ~ 文件是否小写比较|如:true
        /// </summary>
        public string FileNameToLower
        {
            get
            {
                return "FileNameToLower";
            }
        }

        #endregion FileNameToLower ~ 文件是否小写比较|如:true



        #endregion 
    }
}
