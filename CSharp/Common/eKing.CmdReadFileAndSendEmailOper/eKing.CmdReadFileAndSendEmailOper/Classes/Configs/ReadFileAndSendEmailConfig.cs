using System;
using System.Collections.Generic;
using System.Text;
using eKing.CmdReadFileAndSendEmailOper.Classes.Infos;

namespace eKing.CmdReadFileAndSendEmailOper.Classes.Configs
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class ReadFileAndSendEmailConfig
        :
        EmailConfig
    {

        /// <summary>
        /// 
        /// </summary>
        public ReadFileAndSendEmailConfig()
        {

        }


        /// <summary>
        /// 初始化逻辑类
        /// </summary>
        protected override void InitClass()
        {
            base.InitClass();


            ConfigNames.ReadFileAndSendEmailConfigName
                ni 
                = new ConfigNames.ReadFileAndSendEmailConfigName();

            #region 构造

            #region EmailTextType ~ 邮件内容类型|text:纯文字；file:文件|如:text

            m_EmailTextType = new StringInfo(ni.EmailTextType);
            InfoList.Add(m_EmailTextType);

            #endregion EmailTextType ~ 邮件内容类型|text:纯文字；file:文件|如:text


            #region DirFullName ~ 完整的Dir名称|如：D:\one（无后缀）|或：~/执行程序所在的目录|如:~/

            m_DirFullName = new StringInfo(ni.DirFullName);
            InfoList.Add(m_DirFullName);

            #endregion DirFullName ~ 完整的Dir名称|如：D:\one（无后缀）|或：~/执行程序所在的目录|如:~/


            #region FileNameExpress ~ 文件名表达式|如:*_bak.log

            m_FileNameExpress = new StringInfo(ni.FileNameExpress);
            InfoList.Add(m_FileNameExpress);

            #endregion FileNameExpress ~ 文件名表达式|如:*_bak.log


            #region ReadFileEncoding ~ 读取文件编码|gb2312/utf8|如:gb2312

            m_ReadFileEncoding = new StringInfo(ni.ReadFileEncoding);
            InfoList.Add(m_ReadFileEncoding);

            #endregion ReadFileEncoding ~ 读取文件编码|gb2312/utf8|如:gb2312


            #region EmailTextFileMaxLength ~ 读取的文件允许最大值|如果是0，则不限，否则超过最大值就不需要读|B为单位|如:0

            m_EmailTextFileMaxLength = new LongInfo(ni.EmailTextFileMaxLength);
            InfoList.Add(m_EmailTextFileMaxLength);

            #endregion EmailTextFileMaxLength ~ 读取的文件允许最大值|如果是0，则不限，否则超过最大值就不需要读|B为单位|如:0

            #region FileNameToLower ~ 文件是否小写比较|如:true

            m_FileNameToLower = new BoolInfo(ni.FileNameToLower);
            InfoList.Add(m_FileNameToLower);

            #endregion FileNameToLower ~ 文件是否小写比较|如:true



            #endregion 构造
        }


        #region EmailTextType ~ 邮件内容类型|text:纯文字；file:文件|如:text

        /// <summary>
        /// EmailTextType ~ 邮件内容类型|text:纯文字；file:文件|如:text
        /// </summary>
        protected StringInfo m_EmailTextType = null;

        /// <summary>
        /// EmailTextType ~ 邮件内容类型|text:纯文字；file:文件|如:text
        /// </summary>
        public StringInfo EmailTextType
        {
            get
            {
                return m_EmailTextType;
            }
        }

        #endregion EmailTextType ~ 邮件内容类型|text:纯文字；file:文件|如:text


        #region DirFullName ~ 完整的Dir名称|如：D:\one（无后缀）|或：~/执行程序所在的目录|如:~/

        /// <summary>
        /// DirFullName ~ 完整的Dir名称|如：D:\one（无后缀）|或：~/执行程序所在的目录|如:~/
        /// </summary>
        protected StringInfo m_DirFullName = null;

        /// <summary>
        /// DirFullName ~ 完整的Dir名称|如：D:\one（无后缀）|或：~/执行程序所在的目录|如:~/
        /// </summary>
        public StringInfo DirFullName
        {
            get
            {
                return m_DirFullName;
            }
        }

        #endregion DirFullName ~ 完整的Dir名称|如：D:\one（无后缀）|或：~/执行程序所在的目录|如:~/


        #region FileNameExpress ~ 文件名表达式|如:*_bak.log

        /// <summary>
        /// FileNameExpress ~ 文件名表达式|如:*_bak.log
        /// </summary>
        protected StringInfo m_FileNameExpress = null;

        /// <summary>
        /// FileNameExpress ~ 文件名表达式|如:*_bak.log
        /// </summary>
        public StringInfo FileNameExpress
        {
            get
            {
                return m_FileNameExpress;
            }
        }

        #endregion FileNameExpress ~ 文件名表达式|如:*_bak.log


        #region ReadFileEncoding ~ 读取文件编码|gb2312/utf8|如:gb2312

        /// <summary>
        /// ReadFileEncoding ~ 读取文件编码|gb2312/utf8|如:gb2312
        /// </summary>
        protected StringInfo m_ReadFileEncoding = null;

        /// <summary>
        /// ReadFileEncoding ~ 读取文件编码|gb2312/utf8|如:gb2312
        /// </summary>
        public StringInfo ReadFileEncoding
        {
            get
            {
                return m_ReadFileEncoding;
            }
        }

        #endregion ReadFileEncoding ~ 读取文件编码|gb2312/utf8|如:gb2312


        #region EmailTextFileMaxLength ~ 读取的文件允许最大值|如果是0，则不限，否则超过最大值就不需要读|B为单位|如:0

        /// <summary>
        /// EmailTextFileMaxLength ~ 读取的文件允许最大值|如果是0，则不限，否则超过最大值就不需要读|B为单位|如:0
        /// </summary>
        protected LongInfo m_EmailTextFileMaxLength = null;

        /// <summary>
        /// EmailTextFileMaxLength ~ 读取的文件允许最大值|如果是0，则不限，否则超过最大值就不需要读|B为单位|如:0
        /// </summary>
        public LongInfo EmailTextFileMaxLength
        {
            get
            {
                return m_EmailTextFileMaxLength;
            }
        }

        #endregion EmailTextFileMaxLength ~ 读取的文件允许最大值|如果是0，则不限，否则超过最大值就不需要读|B为单位|如:0

        #region FileNameToLower ~ 文件是否小写比较|如:true

        /// <summary>
        /// FileNameToLower ~ 文件是否小写比较|如:true
        /// </summary>
        protected BoolInfo m_FileNameToLower = null;

        /// <summary>
        /// FileNameToLower ~ 文件是否小写比较|如:true
        /// </summary>
        public BoolInfo FileNameToLower
        {
            get
            {
                return m_FileNameToLower;
            }
        }

        #endregion FileNameToLower ~ 文件是否小写比较|如:true


    }
}
