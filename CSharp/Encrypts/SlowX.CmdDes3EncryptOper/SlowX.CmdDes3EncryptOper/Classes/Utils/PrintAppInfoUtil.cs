using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Security.Cryptography;
using System.IO;

namespace SlowX.CmdDes3EncryptOper.Classes.Utils
{
    public partial class Util
    { 

        #region StrGetLength|获得字符串长度[中文长度]

        /// <summary>
        /// 获得字符串长度[中文长度]|中文长度占用2位,英文占用1位 
        /// </summary>
        /// <param name="str">字符串|如:看代码网www.lookdaima.com</param>
        /// <returns>如:25</returns>
        public  int StrGetLength(string str)
        {
            if (str == null || str.Length == 0)
                return 0;

            ASCIIEncoding ascii = new ASCIIEncoding();

            int tempLen = 0;

            byte[] s = ascii.GetBytes(str);

            int iLen = s.Length;

            for (int i = 0; i < iLen; i++)
            {
                if ((int)s[i] == 63)
                {
                    tempLen += 2;
                }
                else
                {
                    tempLen += 1;
                }
            }

            return tempLen;
        }

        #endregion 获得字符串长度[中文长度]


        /// <summary>
        /// 控制台输出版权信息相关的内容
        /// </summary>
        public void PrintAppInfo()
        {
            string printText = @"
欢迎使用Des3自定义算法加密操作小工具
该小工具提供内置算法的des3加密
主要用于一些控制台程序的内置密码加密操作
";
            ConsoleWriteAppInfo(printText);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="printText"></param>
        public void ConsoleWriteAppInfo(string printText)
        {
            string[] textList = printText.Split('\n');

            int textLen = textList.Length;

            // 过滤可能存在的\r //
            for (int i = 0; i < textLen; ++i)
            {
                string str = textList[i];

                if (str == null)
                    str = "";
                else
                    str = str.TrimEnd();

                textList[i] = str;
            }


            // 获得最大长度 //
            int maxLen = 0;
            int iStrLen = 0;

            foreach (string s in textList)
            {
                if (s == null)
                    continue;

                iStrLen = StrGetLength(s);

                if (iStrLen > maxLen)
                {
                    maxLen = iStrLen;
                }
            }

            string linkChar = "+";

            // 输出 +++++++++++++++++ //
            Console.Write(linkChar);
            Console.Write(linkChar);

            for (int i = 0; i < maxLen; ++i)
            {
                Console.Write(linkChar);
            }

            Console.Write(linkChar);
            Console.WriteLine(linkChar);


            // 输出 //
            // + 内容 + //
            foreach (string s in textList)
            {

                Console.Write(linkChar);
                Console.Write(" ");


                if (s == null || s.Length == 0)
                {
                    for (int i = 0; i < maxLen; ++i)
                    {
                        Console.Write(" ");
                    }
                }
                else
                {

                    iStrLen = StrGetLength(s);
                    Console.Write(s);

                    for (int i = iStrLen; i < maxLen; ++i)
                    {
                        Console.Write(" ");
                    }
                }

                Console.Write(" ");
                Console.WriteLine(linkChar);

            }

            // 输出 +++++++++++++++++ //
            Console.Write(linkChar);
            Console.Write(linkChar);

            for (int i = 0; i < maxLen; ++i)
            {
                Console.Write(linkChar);
            }

            Console.Write(linkChar);
            Console.WriteLine(linkChar);
        }


    }
}
