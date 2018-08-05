using System;
using System.Collections.Generic;
using System.Text;
using eKing.CmdReadFileAndSendEmailOper.Classes.Infos;
using System.Reflection;

namespace eKing.CmdReadFileAndSendEmailOper.Classes.Configs
{
    /// <summary>
    /// 基础配置
    /// </summary>
    [Serializable]
    public class BaseConfig
    {

        /// <summary>
        /// 基础配置
        /// </summary>
        public BaseConfig()
        {
            InitClass();
        }

        /// <summary>
        /// 初始化逻辑类
        /// </summary>
        protected virtual void InitClass()
        {

        }

        /// <summary>
        /// 配置信息
        /// </summary>
        protected List<BaseInfo> InfoList = null;

        /// <summary>
        /// 配置信息
        /// </summary>
        /// <returns></returns>
        public List<BaseInfo> InfoListGet()
        {
            return InfoList;
        }

       
       
        /// <summary>
        /// 对配置项做赋值
        /// </summary>
        /// <param name="p_ID"></param>
        /// <param name="p_TheName"></param>
        /// <param name="throwException"></param>
        /// <returns></returns>
        public virtual string BaseInfoSetValue
            (
                string p_ID,
                string p_TheName,
                bool throwException
            )
        {
            List<BaseInfo> theList = InfoList;

            if (theList == null || theList.Count == 0)
            {
                if (throwException)
                {

                    throw new Exception
                        (
                            "方法："
                            + MethodBase.GetCurrentMethod().ReflectedType.FullName
                            + " "
                            + MethodBase.GetCurrentMethod().ToString()
                            + " 发生异常："
                            + "没有配置项"
                        );
                }
                return "没有配置项";
            }

            if (p_ID == null || p_ID.Length == 0)
            {
                if (throwException)
                {

                    throw new Exception
                        (
                            "方法："
                            + MethodBase.GetCurrentMethod().ReflectedType.FullName
                            + " "
                            + MethodBase.GetCurrentMethod().ToString()
                            + " 发生异常："
                            + "传入的字符串参数："
                            + "p_ID"
                            + "为null或为空。"
                        );
                }

                return "p_ID为null或为空。";
            }

            string strKey = p_ID.Trim().ToLower();

            if (strKey.Length == 0)
            {
                if (throwException)
                {

                    throw new Exception
                        (
                            "方法："
                            + MethodBase.GetCurrentMethod().ReflectedType.FullName
                            + " "
                            + MethodBase.GetCurrentMethod().ToString()
                            + " 发生异常："
                            + "传入的字符串参数："
                            + "key"
                            + "为null或为空。"
                        );
                }

                return "p_ID为null或为空。";
            }

            foreach (BaseInfo bi in theList)
            {
                if (bi == null)
                {
                    continue;
                }

                if (bi.TheName == null)
                {
                    continue;
                }

                if (bi.TheName.Trim().ToLower() == strKey)
                {
                    bi.InfoValueSet(p_TheName, throwException);
                    return "";
                }
            }

            if (throwException)
            {

                throw new Exception
                    (
                        "方法："
                        + MethodBase.GetCurrentMethod().ReflectedType.FullName
                        + " "
                        + MethodBase.GetCurrentMethod().ToString()
                        + " 发生异常："
                        + "传入的字符串参数："
                        + p_ID
                        + "没有找到配置项。"
                    );
            }

            return p_ID + "没有找到配置项";
        }

        

        /// <summary>
        /// 校验配置
        /// </summary>
        /// <returns></returns>
        public virtual string ValidConfig()
        {
            List<BaseInfo> theList = InfoList;

            if (theList == null || theList.Count == 0)
            {
                return "没有配置项";
            }

            StringBuilder theResult = new StringBuilder();
            bool isError = false;

            string str = null;

            foreach (BaseInfo bi in theList)
            {
                if (bi == null)
                {
                    isError = true;
                    theResult.AppendLine("有为null的配置项");
                    continue;
                }

                str = bi.InfoValueToString();

                if (str == null || str.Length == 0)
                {
                    isError = true;
                    theResult.AppendLine("配置项(" + bi.TheName + ")为空");
                }
            }

            if (!isError)
            {
                return "";
            }

            return "配置错误：" + System.Environment.NewLine + theResult.ToString();
        }
    }
}
