using System;
using System.Collections.Generic;
using System.Text;
using eKing.CmdReadFileAndSendEmailOper.Classes.Items;
using eKing.CmdReadFileAndSendEmailOper.Classes.Utils;
using eKing.CmdReadFileAndSendEmailOper.Classes.Configs;

namespace eKing.CmdReadFileAndSendEmailOper
{
    /// <summary>
    /// 读取文件并发送邮件的代码
    /// </summary>
    class Program
    {
        /// <summary>
        /// 读取文件并发送邮件的代码
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // EmailName=qq89616537 EmailSmtpServer=smtp.163.com EmailSend=qq89616537@163.com EmailPwd=123 EnableSsl=false EmailRecv=89616537@qq.com;qq89616537@163.com; EmailTitle={DateTime.Now}-远程访问服务器 EmailText=远程访问服务器提示 EmailEncoding=gb2312 HtmlFlag=false PwdTextType=des3 EmailTextType=file DirFullName=~/ FileNameExpress=loginip.log ReadFileEncoding=gb2312 EmailTextFileMaxLength=0 FileNameToLower=true 
            Util ut = new Util();

            try
            {
                ReadFileAndSendEmailConfig ec = ut.Config_Create(args);

                string theResult = ut.DoOper(ec);

                if (theResult == null || theResult.Length == 0)
                {
                    Console.WriteLine("操作成功");
                }
                else
                {
                    Console.WriteLine(theResult);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

            
        }
    }
}
