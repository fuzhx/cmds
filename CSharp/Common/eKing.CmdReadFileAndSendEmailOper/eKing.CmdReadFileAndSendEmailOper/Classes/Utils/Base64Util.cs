using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Security.Cryptography;

namespace eKing.CmdReadFileAndSendEmailOper.Classes.Utils
{
    public partial class Util
    {
        #region EncodingGet|获得编码

        /// <summary>
        /// 获得编码
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        public System.Text.Encoding EncodingGet(string strName)
        {
            if (strName == null || strName.Length == 0)
            {
                return System.Text.Encoding.Default;
            }

            strName = strName.Trim();

            if (strName.Length == 0)
            {
                return System.Text.Encoding.Default;
            }

            string lowerName = strName.Trim().ToLower();

            switch (lowerName)
            {
                case "gb2312":
                    // 中文编码 //
                    return System.Text.Encoding.GetEncoding("gb2312");
                case "utf8":
                    return System.Text.Encoding.UTF8;
                case "utf7":
                    return System.Text.Encoding.UTF7;
                case "ascii":
                    return System.Text.Encoding.ASCII;
                case "bigendianunicode":
                    return System.Text.Encoding.BigEndianUnicode;
                case "default":
                    return System.Text.Encoding.Default;
                case "unicode":
                    return System.Text.Encoding.Unicode;
                case "utf32":
                    return System.Text.Encoding.UTF32;
                default:
                    return System.Text.Encoding.GetEncoding(strName);
            }
        }

        #endregion EncodingGet|获得编码

        #region Base64编码|Base64En

        /// <summary>
        /// Base64编码|Base64En
        /// </summary>
        /// <param name="str"></param>
        /// <param name="en"></param>
        /// <returns></returns>
        public string Base64En(string str, System.Text.Encoding en)
        {
            if (str == null || str.Length == 0)
                return "";

            try
            {
                byte[] bytes = en.GetBytes(str);
                return Convert.ToBase64String(bytes);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        #endregion Base64编码|Base64En

        #region Base64Encode|Base64编码

        /// <summary>
        /// Base64编码
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encodingName"></param>
        /// <returns></returns>
        public string Base64Encode(string str, string encodingName)
        {
            if (str == null || str.Length == 0)
                return "";


            try
            {
                System.Text.Encoding en = EncodingGet(encodingName);

                byte[] bytes = en.GetBytes(str);
                return Convert.ToBase64String(bytes);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        #endregion Base64Encode|Base64编码

        #region Base64Decode|Base64解码

        /// <summary>
        /// Base64解码
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encodingName"></param>
        /// <returns></returns>
        public string Base64Decode(string str, string encodingName)
        {
            if (str == null || str.Length == 0)
                return "";

            try
            {
                System.Text.Encoding en = EncodingGet(encodingName);


                byte[] outputb = Convert.FromBase64String(str);

                return en.GetString(outputb);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        #endregion Base64Decode|Base64解码

        #region Base64De|Base64解码

        /// <summary>
        /// Base64解码
        /// </summary>
        /// <param name="str"></param>
        /// <param name="en"></param>
        /// <returns></returns>
        public string Base64De(string str, System.Text.Encoding en)
        {
            if (str == null || str.Length == 0)
                return "";

            try
            {
                byte[] outputb = Convert.FromBase64String(str);

                return en.GetString(outputb);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        #endregion Base64De|Base64解码



    }
}
