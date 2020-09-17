/****************************************************
--------------------------------
    ----------------------------
    文件名称：
    作者：邹建
    创建日期：2020年09月15日 19:26:15
    ----------------------------
    ----------------------------
    修改次数：0
    修改人员：
    修改日期：
    ----------------------------
    ----------------------------
    功能描述：本地测量数据帧
    ----------------------------
--------------------------------
*****************************************************/

using System.Collections.Generic;

/// <summary>
/// 本地测量数据帧
/// </summary>
public class FrameLine : DataParseBase {

    #region 对外接口

    /// <summary>
    /// 获取三相电压数据(保留一位小数,顺序为ABC)
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public List<string> GetVoltage(string data) {

        List<string> voltageLst = new List<string>();

        string voltage = GetVoltageStr(data);
        string[] volStrs = GetEqLenSubStr(voltage, 4);


        for (int i = 0; i < volStrs.Length; i++) {
            voltageLst.Add(InsertStr(volStrs[i], ".", 3));
        }



        return voltageLst;
    }

    /// <summary>
    /// 获取电流数据(三相,零线,剩余)
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public List<string> GetCurrent(string data) {
        List<string> currentLst = new List<string>();
        string current = GetCurrentStr(data);
        string[] curStrs = GetEqLenSubStr(current, 8);
        for (int i = 0; i < curStrs.Length; i++) {
            currentLst.Add(IsPosNeg(curStrs[i], "8", ".", 4));
        }
        return currentLst;
    }

    /// <summary>
    /// 获取有功功率
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public List<string> GetActivePower(string data) {

        List<string> activePowerLst = new List<string>();
        string activePowerStr = GetActivePowerStr(data);
        string[] activePowers = GetEqLenSubStr(activePowerStr, 8);

        for (int i = 0; i < activePowers.Length; i++) {
            activePowerLst.Add(IsPosNeg(activePowers[i], "8", ".", 4));
        }


        return activePowerLst;
    }

    /// <summary>
    /// 获取无功功率
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public List<string> GetReactivePower(string data) {

        List<string> reactivePowerLst = new List<string>();
        string reactivePowerStr = GetReactivePowerStr(data);
        string[] reactivePowers = GetEqLenSubStr(reactivePowerStr, 8);

        for (int i = 0; i < reactivePowers.Length; i++) {
            reactivePowerLst.Add(IsPosNeg(reactivePowers[i], "80", ".", 4));
        }

        return reactivePowerLst;
    }

    /// <summary>
    /// 获取功率因素
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public List<string> GetPowerFactor(string data) {
        List<string> powerFactorLst = new List<string>();
        string powerFactorStr = GetPowerFactorStr(data);
        string[] powerFactors = GetEqLenSubStr(powerFactorStr, 4);

        foreach (var item in powerFactors) {
            string str = InsertStr(item, ".", 1);
            string s;
            if (IsCurSubEqIpt(str, "8", out s)) {
                powerFactorLst.Add("-0" + s);
            } else {
                powerFactorLst.Add(s);
            }
        }
        return powerFactorLst;
    }

    /// <summary>
    /// 获取变压器温度
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public List<string> GetTransTemp(string data) {

        List<string> transTempsLst = new List<string>();
        string transTempStr = GetTransTempStr(data);
        string[] transTemps = GetEqLenSubStr(transTempStr, 4);

        for (int i = 0; i < transTemps.Length; i++) {
            transTempsLst.Add(IsPosNeg(transTemps[i], "8", "", 0));
        }

        return transTempsLst;
    }

    /// <summary>
    /// 获取环境湿度(百分比)
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public List<string> GetHumidity(string data) {

        List<string> humidityLst = new List<string>();
        string humidityStr = GetHumidityStr(data);
        string[] humiditys = GetEqLenSubStr(humidityStr, 4);

        for (int i = 0; i < humiditys.Length; i++) {
            humidityLst.Add(IsPosNeg(humiditys[i], "8", "", 0));
        }

        return humidityLst;
    }

    #endregion

    #region Private

    /// <summary>
    /// 获取需要的数据(电压到湿度)
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    private string GetShowStr(string data) {
        // 27 正向字符串的长度，-25 反向字符串长度
        return data.Trim().Substring(27).Substring(0, data.Length - 27 - 24).Replace(" ", "");
    }

    /// <summary>
    /// 截取某一部分数据
    /// </summary>
    /// <param name="data">数据</param>
    /// <param name="startIndex">开始位置</param>
    /// <param name="count">截取长度</param>
    /// <returns></returns>
    private string GetSubPartStr(string data, int startIndex, int count) {
        return GetShowStr(data).Substring(startIndex, count);
    }

    /// <summary>
    /// 获取三相电压字符串
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    private string GetVoltageStr(string data) {
        return GetSubPartStr(data, 0, 12);
    }

    /// <summary>
    /// 获取三相电流字符串
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    private string GetCurrentStr(string data) {
        return GetSubPartStr(data, 12, 40);
    }

    /// <summary>
    /// 获取有功功率字符串
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    private string GetActivePowerStr(string data) {
        return GetSubPartStr(data, 52, 32);
    }

    /// <summary>
    /// 获取无功功率字符串
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    private string GetReactivePowerStr(string data) {

        return GetSubPartStr(data, 84, 32);
    }

    /// <summary>
    /// 获取功率因素字符串
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    private string GetPowerFactorStr(string data) {

        return GetSubPartStr(data, 116, 12);
    }

    /// <summary>
    /// 获取变压器温度字符串
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    private string GetTransTempStr(string data) {

        return GetSubPartStr(data, 128, 4);
    }

    /// <summary>
    /// 获取环境湿度字符串
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    private string GetHumidityStr(string data) {

        return GetSubPartStr(data, 132, 4);
    }

    #endregion

}