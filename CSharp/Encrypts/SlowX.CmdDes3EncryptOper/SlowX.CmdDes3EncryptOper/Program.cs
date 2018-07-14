using System;
using System.Collections.Generic;
using System.Text; 
using SlowX.CmdDes3EncryptOper.Classes.Utils; 

namespace SlowX.CmdDes3EncryptOper
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Util ut = new Util();

            ut.PrintAppInfo();
            Console.WriteLine();
            string str = "";
            string strResult = "";

            while (true)
            {
                Console.WriteLine("请输入要des3加密的字符串|输入exit退出：");
                str = Console.ReadLine();

                if (str == "exit")
                {
                    strResult = ut.DES3En(str);
                    Console.WriteLine("exit的加密结果为：" + strResult);
                    Console.WriteLine("程序退出");
                    break;
                }

                  strResult = ut.DES3En(str);

                Console.WriteLine("加密结果：" + strResult);
                Console.WriteLine();
            }

            
            
        }
    }
}
