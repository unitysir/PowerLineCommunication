/****************************************************
--------------------------------
    ----------------------------
    文件名称：
    作者：邹建
    创建日期：2020年09月15日 10:51:52
    ----------------------------
    ----------------------------
    修改次数：0
    修改人员：
    修改日期：
    ----------------------------
    ----------------------------
    功能描述：传入数据操作基类
    ----------------------------
--------------------------------
*****************************************************/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

/// <summary>
/// 数据操作基类
/// </summary>
public class DataParseBase : StrOperBase {

    /// <summary>
    /// 获取所有传入的数据(大量43-16数据入口)
    /// </summary>
    /// <param name="allData">移除了开始和结束标志的数据</param>
    /// <returns></returns>
    public static List<string> GetAllData(string allData) {
        List<string> dataLst = new List<string>();//存储发送过来的以"43-16"分割的数据数据

        string startStr = "43";//开始字符
        string endStr = "16";//结束字符

        try {
            //存储分割的完整数据
            string[] allDataLst = Regex.Split(allData, "16", RegexOptions.IgnoreCase);

            // TODO 获取到所有在 起始字符串以内的数据，并保存在数组中
            foreach (var data in allDataLst) {
                string str = startStr + GetMidStrEx(data + "16", startStr, endStr) + endStr;// 获取已经分割的数据(只有信息)
                if (!str.Equals("")) dataLst.Add(str.Trim());//存储分割数据
            }
        } catch (Exception) {

            throw;
        }

        dataLst.RemoveAt(dataLst.Count - 1);

        return dataLst;
    }

    #region 通用格式
    /// <summary>
    /// 获取帧长度(默认10进制)
    /// </summary>
    /// <param name="data"></param>
    /// <param name="isHex">默认16进制串(16或10)</param>
    /// <returns></returns>
    public static string GetFrameLength(string data, bool isHex = false) {
        try {
            if (data.Length > 0) {
                string[] splits = data.Split(' ');
                if (isHex) {
                    return splits[1];
                } else {
                    return HexToDec(splits[1]);
                }
            }
        } catch (Exception) {

            throw;
        }
        return "-1";
    }

    /// <summary>
    /// 获取控制指令(默认十进制)
    /// </summary>
    /// <param name="data"></param>
    /// <param name="isHex">默认false</param>
    /// <returns></returns>
    public static string GetCtl(string data, bool isHex = false) {
        try {
            string[] splits = data.Split(' ');
            if (isHex) {
                return splits[2];
            } else {
                return HexToDec(splits[2]);
            }
        } catch (Exception) {

            throw;
        }
    }

    /// <summary>
    /// 获取终端地址(3到9位)
    /// </summary>
    /// <param name="data">通过GetAllData解析出的数据</param>
    /// <returns></returns>
    public static string[] GetTerminalAddress(string data) {
        string[] teradd = new string[6];
        try {
            string[] splits = data.Split(' ');
            if (data.Length > 0) {
                for (int i = 3; i < 9; i++) {
                    teradd[i - 3] = splits[i];
                }
            }
        } catch (Exception) {

            throw;
        }
        return teradd;
    }

    /// <summary>
    /// 获取时间戳
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static string[] GetHeartTime(string data) {
        string[] time = new string[6];
        try {
            string[] splits = data.Split(' ');
            for (int i = 1; i < 7; i++) {
                time[i - 1] = splits[splits.Length - (i + 2)];
            }
            Array.Reverse(time);
        } catch (Exception) {

            throw;
        }

        return time;
    }

    /// <summary>
    /// 获取校验和(默认转为10进制)
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static string GetCheckSum(string data, bool isHex = false) {
        try {
            string[] splits = data.Split(' ');
            string checkSum = splits[splits.Length - 2];
            if (isHex) {
                return checkSum;
            } else {
                return HexToDec(checkSum);
            }
        } catch (Exception) {

            throw;
        }
    }

    /// <summary>
    /// 校检和是否正确(未完)
    /// </summary>
    /// <param name="checkSum">传入校验和</param>
    /// <param name="data">传入需要校验的数据</param>
    /// <returns></returns>
    public static bool IsCheckSum(string checkSum, string data) {

        return false;
    }

    /// <summary>
    /// 判断正负
    /// </summary>
    /// <param name="data"></param>
    /// <param name="isPnStr">需要写入判断的字符串(isPnStr默认未负)</param>
    /// <param name="indexStr">插入字符串</param>
    /// <param name="index">插入位置</param>
    /// <returns></returns>
    protected static string IsPosNeg(string data, string isPnStr, string indexStr, int index) {
        string Str = data;
        string retStr = "";
        try {
            if (IsCurSubEqIpt(data, isPnStr)) { //如果是负数，则加负号
                Str = Str.Remove(0, 1);
                string str = SubHighZero(InsertStr(Str, indexStr, index));
                if (IsCurSubEqIpt(str, ".")) {
                    retStr = "-0" + str;
                } else {
                    retStr = "-" + str;
                }
            } else {
                if (IsCurSubEqIpt(Str, "0") || IsCurSubEqIpt(Str, "8"))
                    Str = Str.Remove(0, 1);
                string str = SubHighZero(InsertStr(Str, indexStr, index));
                if (IsCurSubEqIpt(str, ".")) {
                    retStr = "0" + str;
                } else {
                    retStr = str;
                }
            }
        } catch (Exception) {

            throw;
        }
        return retStr;
    }

    #endregion

}
