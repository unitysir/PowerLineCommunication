/****************************************************
--------------------------------
    ----------------------------
    文件名称：
    作者：邹建
    创建日期：2020年09月17日 14:53:57
    ----------------------------
    ----------------------------
    修改次数：0
    修改人员：
    修改日期：
    ----------------------------
    ----------------------------
    功能描述：字符串操作基类
    ----------------------------
--------------------------------
*****************************************************/
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

/// <summary>
/// 字符串操作基类
/// </summary>
public class StrOperBase{

    #region Tool

    /// <summary>
    /// 在index处插入字符串
    /// </summary>
    /// <param name="str"></param>
    /// <param name="insertStr"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public string InsertStr(string str, string insertStr, int index) {
        return str.Insert(index, insertStr);
    }

    /// <summary>
    /// 等距截取字符串 
    /// </summary>
    /// <param name="str"></param>
    /// <param name="len">截取长度</param>
    /// <returns></returns>
    public string[] GetEqLenSubStr(string str, int len) {

        List<string> eqLenLst = new List<string>();
        string addStr = "";
        char[] chars = str.ToCharArray();
        int charLen = chars.Length;

        for (int i = 1; i < charLen + 1; i++) {
            addStr += chars[i - 1];
            if (i % len == 0) {
                eqLenLst.Add(addStr);
                addStr = "";
            }
        }

        return eqLenLst.ToArray();
    }

    /// <summary>
    /// 截取两个字符串之间的内容
    /// </summary>
    /// <param name="sourse">需要截取的字符串</param>
    /// <param name="startstr">开始</param>
    /// <param name="endstr">结束</param>
    /// <returns></returns>
    public string GetMidStrEx(string sourse, string startstr, string endstr) {
        string result = string.Empty;
        int startindex, endindex;
        try {
            startindex = sourse.IndexOf(startstr);
            if (startindex == -1)
                return result;
            string tmpstr = sourse.Substring(startindex + startstr.Length);
            endindex = tmpstr.IndexOf(endstr);
            if (endindex == -1)
                return result;
            result = tmpstr.Remove(endindex);
        } catch (Exception ex) {
            Console.WriteLine("MidStrEx Err:" + ex.Message);
        }
        return result;
    }

    /// <summary>
    /// 16进制转10进制
    /// </summary>
    /// <param name="hex"></param>
    /// <returns></returns>
    public string HexToDec(string hex) {
        return int.Parse(hex, NumberStyles.HexNumber).ToString();
    }

    /// <summary>
    /// 判断当前值的前几位是否与ipt相等
    /// </summary>
    /// <param name="cur"></param>
    /// <param name="ipt"></param>
    /// <returns></returns>
    public bool IsCurSubEqIpt(string cur, string ipt) {
        if (ipt.Length > cur.Length) return false;

        string str = cur;
        str = str.Substring(0, ipt.Length);

        if (str.Equals(ipt)) {
            return true;
        }
        return false;
    }

    /// <summary>
    /// 判断当前值的前几位是否与ipt相等,并返回已经截取的字符串
    /// </summary>
    /// <param name="cur"></param>
    /// <param name="ipt"></param>
    /// <param name="s">返回已经截取的字符串</param>
    /// <returns></returns>
    public bool IsCurSubEqIpt(string cur, string ipt,out string s) {
        if (ipt.Length > cur.Length) {
            s = cur;
            return false;
        }

        string str = cur;
        str = str.Substring(0, ipt.Length);

        if (str.Equals(ipt)) {
            s = cur.Substring(ipt.Length);
            return true;
        }
        s = cur;
        return false;
    }

    /// <summary>
    /// 去掉前面所有为 "0" 的部分
    /// </summary>
    /// <param name="data"></param>
    /// <param name="len"></param>
    /// <returns></returns>
    public string SubHighZero(string data) {
        if (!data.Remove(1).Equals("0")) return data;
        string str = data.Remove(0, 1);

        for (int i = 0; i < str.Length; i++) {
            string s = str.Substring(0, 1);
            if (s.Equals("0")) {
                str = str.Remove(0, 1);
            } else {
                break;
            }
        }

        return str;
    }

    /// <summary>
    /// 获取当前时间
    /// </summary>
    /// <returns></returns>
    public string GetCurTime() {
        return DateTime.Now.ToString("yyyy-MM-dd__HH_mm_ss");
    }

    #endregion

}

