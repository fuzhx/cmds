using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Security.Cryptography;

namespace SlowX.CmdDes3EncryptOper.Classes.Utils
{
    public partial class Util
    {
        /// <summary>
        /// 加密密钥
        /// </summary>
        private const string Des3Key = "ekinglbs2018tool";

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


        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string DES3En
            (string str)
        {
            System.Text.Encoding en
                =
                System.Text.Encoding.GetEncoding("gb2312");

            return DES3Encrypt(Des3Key, str, en);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string DES3De
            (string str)
        {
            System.Text.Encoding en
                =
                System.Text.Encoding.GetEncoding("gb2312");

            return DES3Decrypt(Des3Key, str, en);
        }

        #region DES 加密

        /// <summary>
        /// DES 加密
        /// </summary>
        /// <param name="EncryptKey"></param>
        /// <param name="str">明文</param>
        /// <param name="_encoding"></param>
        /// <returns></returns>
        public string DES3Encrypt
            (
                string EncryptKey,
                string str,
                System.Text.Encoding _encoding
            )
        {
            string theResult = "";

            TripleDESCryptoServiceProvider DES = null;
            ICryptoTransform desEncryptValue = null;
            try
            {
                DES = new TripleDESCryptoServiceProvider();


                DES.Key = _encoding.GetBytes(EncryptKey);
                DES.Mode = CipherMode.ECB;

                desEncryptValue = DES.CreateEncryptor();

                byte[] Buffer = _encoding.GetBytes(str);

                theResult = Convert.ToBase64String(desEncryptValue.TransformFinalBlock(Buffer, 0, Buffer.Length));
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                if (desEncryptValue != null)
                {
                    desEncryptValue.Dispose();
                    desEncryptValue = null;
                }

                if (DES != null)
                {
                    DES = null;
                }
            }

            return theResult;

        }

        #endregion DES 加密

        #region DES 解密

        /// <summary>
        /// DES 解密 
        /// </summary>
        /// <param name="EncryptKey"></param>
        /// <param name="str"></param>
        /// <param name="_encoding"></param>
        /// <returns></returns>
        public string DES3Decrypt
            (
                string EncryptKey,
                string str,
                System.Text.Encoding _encoding
            )
        {
            string theResult = "";

            TripleDESCryptoServiceProvider DES = null;
            ICryptoTransform desDecryptValue = null;
            try
            {
                DES = new TripleDESCryptoServiceProvider();


                DES.Key = _encoding.GetBytes(EncryptKey);


                DES.Mode = CipherMode.ECB;

                desDecryptValue = DES.CreateDecryptor();

                byte[] Buffer = Convert.FromBase64String(str);

                theResult = _encoding.GetString(desDecryptValue.TransformFinalBlock(Buffer, 0, Buffer.Length));

            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                if (desDecryptValue != null)
                {
                    desDecryptValue.Dispose();
                    desDecryptValue = null;
                }

                if (DES != null)
                {
                    DES = null;
                }
            }

            return theResult;
        }

        #endregion DES 解密



       


    }
}
