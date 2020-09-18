using System;
using System.Collections.Generic;
using System.Text;


/// <summary>
/// 数据库
/// </summary>
public class DBC {

    /// <summary>
    /// MeterData表
    /// </summary>
    public class MeterData {

        #region 字段

        /// <summary>
        /// 电表编号；台变编号
        /// </summary>
        public const string meter_sn = "meter_sn";
        /// <summary>
        /// 保存时间
        /// </summary>
        public const string save_time = "save_time";
        /// <summary>
        /// A相电压
        /// </summary>
        public const string voltage_a = "voltage_a";
        /// <summary>
        /// B相电压
        /// </summary>
        public const string voltage_b = "voltage_b";
        /// <summary>
        /// C相电压
        /// </summary>
        public const string voltage_c = "voltage_c";
        /// <summary>
        /// A相电流
        /// </summary>
        public const string current_a = "current_a";
        /// <summary>
        /// B相电流
        /// </summary>
        public const string current_b = "current_b";
        /// <summary>
        /// C相电流
        /// </summary>
        public const string current_c = "current_c";
        /// <summary>
        /// 零线电流
        /// </summary>
        public const string current_zero_line = "current_zero_line";
        /// <summary>
        /// 剩余电流
        /// </summary>
        public const string current_remain = "current_remain";
        /// <summary>
        /// A相有功功率
        /// </summary>
        public const string active_power_a = "active_power_a";
        /// <summary>
        /// B相有功功率
        /// </summary>
        public const string active_power_b = "active_power_b";
        /// <summary>
        /// C相有功功率
        /// </summary>
        public const string active_power_c = "active_power_c";
        /// <summary>
        /// 总有功功率
        /// </summary>
        public const string active_power_total = "active_power_total";
        /// <summary>
        /// A相无功功率
        /// </summary>
        public const string reactive_power_a = "reactive_power_a";
        /// <summary>
        /// B相无功功率
        /// </summary>
        public const string reactive_power_b = "reactive_power_b";
        /// <summary>
        /// C相无功功率
        /// </summary>
        public const string reactive_power_c = "reactive_power_c";
        /// <summary>
        /// 总无功功率
        /// </summary>
        public const string reactive_power_total = "reactive_power_total";
        /// <summary>
        /// A相功率因素
        /// </summary>
        public const string power_factor_a = "power_factor_a";
        /// <summary>
        /// B相功率因素
        /// </summary>
        public const string power_factor_b = "power_factor_b";
        /// <summary>
        /// C相功率因素
        /// </summary>
        public const string power_factor_c = "power_factor_c";
        /// <summary>
        /// 变压器温度（前端）/表箱内温度（后端），注意：前端不是总表
        /// </summary>
        public const string temperature = "temperature";
        /// <summary>
        /// 湿度
        /// </summary>
        public const string humidity = "humidity";
        /// <summary>
        /// 采集时间
        /// </summary>
        public const string acquisition_time = "acquisition_time";
        /// <summary>
        /// 运行状态字4（总表才有）
        /// </summary>
        public const string phase_fault_a = "phase_fault_a";
        /// <summary>
        /// 运行状态字5（总表才有）
        /// </summary>
        public const string phase_fault_b = "phase_fault_b";
        /// <summary>
        /// 运行状态字6（总表才有）
        /// </summary>
        public const string phase_fault_c = "phase_fault_c";
        /// <summary>
        /// 运行状态字7（总表才有）
        /// </summary>
        public const string combined_phase_fault = "combined_phase_fault";

        #endregion

    }

}
