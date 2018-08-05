using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Security.Cryptography;
using eKing.CmdReadFileAndSendEmailOper.Classes.Configs;
using eKing.CmdReadFileAndSendEmailOper.Classes.Items;

namespace eKing.CmdReadFileAndSendEmailOper.Classes.Utils
{
    public partial class Util
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public ReadFileAndSendEmailConfig Config_Create(string[] args)
        {
            ReadFileAndSendEmailConfig theResult = new ReadFileAndSendEmailConfig();

            List<KeyValueItem> kvList = ArgsToKeyValue(args);

            if (kvList == null||kvList.Count == 0)
            {
                return theResult;
            }

            foreach (KeyValueItem kv in kvList)
            {
                if (kv == null)
                    continue;

                theResult.BaseInfoSetValue(kv.ID, kv.TheName, false);
            }

            return theResult;
        }

    }
}
