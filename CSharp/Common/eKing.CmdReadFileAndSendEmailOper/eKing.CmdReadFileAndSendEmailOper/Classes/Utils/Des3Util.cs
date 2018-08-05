using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Security.Cryptography;

namespace eKing.CmdReadFileAndSendEmailOper.Classes.Utils
{
    public partial class Util
    {
        /// <summary>
        /// 加密密钥
        /// </summary>
        private const string Des3Key = "ekinglbs2018tool";

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



        /// <summary>
        /// 字符串转成byte[]数组的String
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string StringToByteArrayString(string str)
        {
            if (str == null || str.Length == 0)
                return "";

            byte[] byteArray = Encoding.Default.GetBytes(str);

            return ByteArrayToString(byteArray);
        }

        /// <summary>
        /// 字符串转成byte[]数组的String
        /// </summary>
        /// <param name="str"></param>
        /// <param name="_encoding"></param>
        /// <returns></returns>
        public string StringToByteArrayString(string str, System.Text.Encoding _encoding)
        {
            if (str == null || str.Length == 0)
                return "";

            if (_encoding == null)
            {
                throw new Exception
                   (
                       "方法："
                       + MethodBase.GetCurrentMethod().ReflectedType.FullName
                       + " "
                       + MethodBase.GetCurrentMethod().ToString()
                       + " 发生异常："
                       + "传入参数：System.Text.Encoding _encoding 为null。"
                   );
            }

            byte[] byteArray = _encoding.GetBytes(str);

            return ByteArrayToString(byteArray);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="byteArray"></param>
        /// <returns></returns>
        public string ByteArrayToString(byte[] byteArray)
        {
            if (byteArray == null)
            {
                throw new Exception
                   (
                       "方法："
                       + MethodBase.GetCurrentMethod().ReflectedType.FullName
                       + " "
                       + MethodBase.GetCurrentMethod().ToString()
                       + " 发生异常："
                       + "传入参数：byte[] byteArray 为null。"
                   );
            }

            StringBuilder theResult = new StringBuilder();

            foreach (byte b in byteArray)
            {
                theResult.Append(b.ToString().PadLeft(3, '0'));
            }

            return theResult.ToString();
        }

        /// <summary>
        /// 字符串转成byte[]数组
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public byte[] StringToByteArray(string str)
        {
            if (str == null || str.Length == 0)
                return null;

            int iLen = str.Length;

            if (iLen % 3 != 0)
            {
                throw new Exception
                   (
                       "方法："
                       + MethodBase.GetCurrentMethod().ReflectedType.FullName
                       + " "
                       + MethodBase.GetCurrentMethod().ToString()
                       + " 发生异常："
                       + "iLen % 3 != 0，传入的字符串不是合理的byte[]值。"
                   );
            }

            int iArrayLen = iLen / 3;
            byte[] theResult = new byte[iArrayLen];

            string strItem = string.Empty;
            byte bItem = 1;

            for (int i = 0; i < iArrayLen; ++i)
            {
                strItem = str.Substring(i * 3, 3);

                bItem = byte.Parse(strItem);

                theResult[i] = bItem;

            }

            return theResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string ByteArrayStringToString(string str)
        {
            byte[] bArray = StringToByteArray(str);

            return Encoding.Default.GetString(bArray);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="_encoding"></param>
        /// <returns></returns>
        public string ByteArrayStringToString(string str, System.Text.Encoding _encoding)
        {
            if (_encoding == null)
            {
                throw new Exception
                   (
                       "方法："
                       + MethodBase.GetCurrentMethod().ReflectedType.FullName
                       + " "
                       + MethodBase.GetCurrentMethod().ToString()
                       + " 发生异常："
                       + "传入参数：System.Text.Encoding _encoding 为null。"
                   );
            }

            byte[] bArray = StringToByteArray(str);

            return _encoding.GetString(bArray);
        }



    }
}
