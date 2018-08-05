using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Security.Cryptography;
using eKing.CmdReadFileAndSendEmailOper.Classes.Items;

namespace eKing.CmdReadFileAndSendEmailOper.Classes.Utils
{
    public partial class Util
    {

        #region CmdStrToStr|控制台的转义字符串转成内容中的字符串|如: look\"dai\\ma (输出) look"dai\ma

        /// <summary>
        /// <para>控制台的转义字符串转成内容中的字符串|如: look\"dai\\ma (输出) look"dai\ma</para>
        /// <para>1.如果前后没有"，按原先的字符串返回，不做转义处理</para>
        /// <para>2.如果前后有"，做几个转义：</para>
        /// <para>(1)\\转成\</para>
        /// <para>(2)\"转成"</para>
        /// <para>(3)\t转成 制表符('\t')</para>
        /// <para>(4)\r转成 (\r)</para>
        /// <para>(5)\n转成 (\n)</para>
        /// </summary>
        /// <param name="str">传入的字符串</param>
        /// <returns></returns> 
        public string CmdStrToStr(string str)
        {
            if (str == null)
            {
                return "";
            }

            if (str.Length == 0)
            {
                return "";
            }

            str = str.Trim();

            if (str.Length == 0)
            {
                return "";
            }

            // 控制台自动帮我们过滤的前后的" //
            //if (!(str.StartsWith("\"") && str.EndsWith("\"")))
            //{
            //    return str;
            //}

            //// 移除前后" //
            //str = str.Substring(1);

            //if (str.Length == 0)
            //    return "";

            //str = str.Substring(0, str.Length - 1);

            return ConvertStrToStr(str);
        }

        #endregion CmdStrToStr|控制台的转义字符串转成内容中的字符串|如: look\"dai\\ma (输出) look"dai\ma

        #region ConvertStrToStr|控制台的转义字符串转成内容中的字符串|如: look\"dai\\ma (输出) look"dai\ma

        /// <summary>
        /// <para>控制台的转义字符串转成内容中的字符串|如: look\"dai\\ma (输出) look"dai\ma</para>
        /// <para>(1)\\转成\</para>
        /// <para>(2)\"转成"</para>
        /// <para>(3)\t转成 制表符('\t')</para>
        /// <para>(4)\r转成 (\r)</para>
        /// <para>(5)\n转成 (\n)</para>
        /// </summary>
        /// <param name="str">传入的字符串</param>
        /// <returns></returns> 
        public string ConvertStrToStr(string str)
        {
            if (str == null)
            {
                return "";
            }

            int iLen = str.Length;

            if (iLen == 0)
            {
                return "";
            }

            StringBuilder theResult = new StringBuilder();
            char cV = '0';
            char nextChar = '0';

            int i = 0;

            while (i < iLen)
            {
                cV = str[i];

                if (cV != '\\')
                {
                    theResult.Append(cV);
                    ++i;
                    continue;
                }

                if (i == iLen - 1)
                {
                    theResult.Append(cV);
                    break;
                }

                nextChar = str[i + 1];

                switch (nextChar)
                {
                    case '\\':
                        ++i;
                        theResult.Append('\\');
                        break;
                    case '\"':
                        ++i;
                        theResult.Append('\"');
                        break;
                    case 'n':
                        ++i;
                        theResult.Append('\n');
                        break;
                    case 't':
                        ++i;
                        theResult.Append('\t');
                        break;
                    case 'r':
                        ++i;
                        theResult.Append('\r');
                        break;
                    default:
                        theResult.Append('\\');
                        break;
                }


                ++i;
            }

            return theResult.ToString();
        }

        #endregion ConvertStrToStr|控制台的转义字符串转成内容中的字符串|如: look\"dai\\ma (输出) look"dai\ma

        #region StrToConvertStr|字符串转义成控制台可输入的字符串|如: look"dai\ma (输出) look\"dai\\ma

        /// <summary>
        /// <para>字符串转义成控制台可输入的字符串|如: look"dai\ma (输出) look\"dai\\ma</para>
        /// <para>(1)\转成\\</para>
        /// <para>(2)"转成\"</para>
        /// <para>(3)(\t)转成\t </para>
        /// <para>(4)(\r)转成\r</para>
        /// <para>(5)(\n)转成\n</para>
        /// </summary>
        /// <param name="str">传入的字符串</param>
        /// <returns></returns> 
        public string StrToConvertStr(string str)
        {
            if (str == null)
            {
                return "";
            }


            int iLen = str.Length;

            if (iLen == 0)
            {
                return "";
            }

            StringBuilder theResult = new StringBuilder();
            char cV = '0';

            for (int i = 0; i < iLen; ++i)
            {
                cV = str[i];

                switch (cV)
                {
                    case '\r':
                        theResult.Append("\\r");
                        break;
                    case '\n':
                        theResult.Append("\\n");
                        break;
                    case '\t':
                        theResult.Append("\\t");
                        break;
                    case '\\':
                        theResult.Append("\\\\");
                        break;
                    case '"':
                        theResult.Append("\\\"");
                        break;
                    default:
                        theResult.Append(cV);
                        break;
                }
            }

            return theResult.ToString();
        }

        #endregion StrToConvertStr|字符串转义成控制台可输入的字符串|如: look"dai\ma (输出) look\"dai\\ma

        #region KeyValueItem|通过str构建KeyValueItem项

        /// <summary>
        /// 通过str构建KeyValueItem项
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public KeyValueItem KeyValueItemCreate(string str)
        {
            if (str == null)
                return null;

            if (str.Length == 0)
                return null;

            str = str.Trim();

            if (str.Length == 0)
                return null;

            KeyValueItem theResult = new KeyValueItem();

            int idx = str.IndexOf('=');

            if (idx == -1)
            {
                theResult.ID = str;
                theResult.TheName = "";
                return theResult;
            }

            theResult.ID = str.Substring(0, idx);

            str = str.Substring(idx + 1);

            if (str.Length == 0)
            {
                theResult.TheName = str;
            }

            theResult.TheName = CmdStrToStr(str);

            return theResult;
        }

        #endregion KeyValueItem|通过str构建KeyValueItem项

        #region ArgsToKeyValue|string[] args转成KeyValueItem的列表

        /// <summary>
        /// string[] args转成KeyValueItem的列表
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public List<KeyValueItem> ArgsToKeyValue(string[] args)
        {
            if (args == null)
                return null;

            int iLen = args.Length;

            if (iLen == 0)
                return null;

            List<KeyValueItem> theResult = new List<KeyValueItem>();

            string strTmp = null;
            KeyValueItem kv = null;

            foreach (string s in args)
            {
                if (s == null)
                    continue;

                strTmp = s.Trim();

                if (strTmp.Length == 0)
                    continue;

                kv = KeyValueItemCreate(strTmp);

                if (kv == null)
                    continue;

                theResult.Add(kv);
            }

            return theResult;


        }

        #endregion ArgsToKeyValue|string[] args转成KeyValueItem的列表


    }
}
