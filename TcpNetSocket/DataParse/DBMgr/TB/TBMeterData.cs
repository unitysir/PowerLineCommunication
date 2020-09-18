using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

public class TBMeterData : TBOperaBase<TBMeterData> {

    /// <summary>
    /// 保存时间
    /// </summary>
    protected string SaveTime { get; set; }
    /// <summary>
    /// 表字段
    /// </summary>
    protected string Field { get; set; }
    /// <summary>
    /// 表数据
    /// </summary>
    protected string Data { get; set; }

    private int id = 0;

    public TBMeterData() {
        Field = $@"
                                { DBC.MeterData.meter_sn},
                                { DBC.MeterData.save_time},
                                { DBC.MeterData.voltage_a},
                                { DBC.MeterData.voltage_b},
                                { DBC.MeterData.voltage_c},      
                                { DBC.MeterData.current_a},
                                { DBC.MeterData.current_b},
                                { DBC.MeterData.current_c},
                                { DBC.MeterData.current_zero_line},
                                { DBC.MeterData.current_remain},
                                { DBC.MeterData.active_power_a},
                                { DBC.MeterData.active_power_b},
                                { DBC.MeterData.active_power_c},
                                { DBC.MeterData.active_power_total},
                                { DBC.MeterData.reactive_power_a},
                                { DBC.MeterData.reactive_power_b},
                                { DBC.MeterData.reactive_power_c},
                                { DBC.MeterData.reactive_power_total},
                                { DBC.MeterData.power_factor_a},
                                { DBC.MeterData.power_factor_b},
                                { DBC.MeterData.power_factor_c},
                                { DBC.MeterData.temperature},
                                { DBC.MeterData.humidity},
                                { DBC.MeterData.acquisition_time},
                                { DBC.MeterData.phase_fault_a},
                                { DBC.MeterData.phase_fault_b},
                                { DBC.MeterData.phase_fault_c},
                                { DBC.MeterData.combined_phase_fault}
                                ";
        Data = $@"
                                @{ DBC.MeterData.meter_sn},
                                @{ DBC.MeterData.save_time},
                                @{ DBC.MeterData.voltage_a},
                                @{ DBC.MeterData.voltage_b},
                                @{ DBC.MeterData.voltage_c},
                                @{ DBC.MeterData.current_a},
                                @{ DBC.MeterData.current_b},
                                @{ DBC.MeterData.current_c},
                                @{ DBC.MeterData.current_zero_line},
                                @{ DBC.MeterData.current_remain},
                                @{ DBC.MeterData.active_power_a},
                                @{ DBC.MeterData.active_power_b},
                                @{ DBC.MeterData.active_power_c},
                                @{ DBC.MeterData.active_power_total},
                                @{ DBC.MeterData.reactive_power_a},
                                @{ DBC.MeterData.reactive_power_b},
                                @{ DBC.MeterData.reactive_power_c},
                                @{ DBC.MeterData.reactive_power_total},
                                @{ DBC.MeterData.power_factor_a},
                                @{ DBC.MeterData.power_factor_b},
                                @{ DBC.MeterData.power_factor_c},
                                @{ DBC.MeterData.temperature},
                                @{ DBC.MeterData.humidity},
                                @{ DBC.MeterData.acquisition_time},
                                @{ DBC.MeterData.phase_fault_a},
                                @{ DBC.MeterData.phase_fault_b},
                                @{ DBC.MeterData.phase_fault_c},
                                @{ DBC.MeterData.combined_phase_fault}
                                ";
    }

    /// <summary>
    /// 电压
    /// </summary>
    private List<string> voltage;
    /// <summary>
    /// 电流
    /// </summary>
    private List<string> current;
    /// <summary>
    /// 有功功率
    /// </summary>
    private List<string> active_power;

    private List<string> reactive_power;

    private List<string> power_factor;

    private List<string> temp;

    private List<string> humi;

    public override void Insert() {
        base.Insert();
        SaveTime = StrOperBase.GetCurTime();

        SocketData.RecvMsgF(bytes => {

            string recvStr = Encoding.UTF8.GetString(bytes);

            voltage = FrameLine.GetVoltage(recvStr);
            current = FrameLine.GetCurrent(recvStr);
            active_power = FrameLine.GetActivePower(recvStr);
            reactive_power = FrameLine.GetReactivePower(recvStr);
            power_factor = FrameLine.GetPowerFactor(recvStr);
            temp = FrameLine.GetTransTemp(recvStr);
            humi = FrameLine.GetHumidity(recvStr);


            PgDBHelper.DBInsert("meter_data", Field, Data, (cmd) => {

                PgDBHelper.AddData(cmd, DBC.MeterData.meter_sn, $"{id++}");
                PgDBHelper.AddData(cmd, DBC.MeterData.save_time, SaveTime);

                PgDBHelper.AddData(cmd, DBC.MeterData.voltage_a, float.Parse(voltage[0]));
                PgDBHelper.AddData(cmd, DBC.MeterData.voltage_b, float.Parse(voltage[1]));
                PgDBHelper.AddData(cmd, DBC.MeterData.voltage_c, float.Parse(voltage[2]));

                //PgDBHelper.AddData(cmd, DBC.MeterData.current_a, 1);
                //PgDBHelper.AddData(cmd, DBC.MeterData.current_b, 1);
                //PgDBHelper.AddData(cmd, DBC.MeterData.current_c, 1);
                //PgDBHelper.AddData(cmd, DBC.MeterData.current_zero_line, 1);
                //PgDBHelper.AddData(cmd, DBC.MeterData.current_remain, 1);

                PgDBHelper.AddData(cmd, DBC.MeterData.current_a, float.Parse(current[0]));
                PgDBHelper.AddData(cmd, DBC.MeterData.current_b, float.Parse(current[1]));
                PgDBHelper.AddData(cmd, DBC.MeterData.current_c, float.Parse(current[2]));
                PgDBHelper.AddData(cmd, DBC.MeterData.current_zero_line, float.Parse(current[3]));
                PgDBHelper.AddData(cmd, DBC.MeterData.current_remain, float.Parse(current[4]));

                //PgDBHelper.AddData(cmd, DBC.MeterData.active_power_a, 1);
                //PgDBHelper.AddData(cmd, DBC.MeterData.active_power_b, 1);
                //PgDBHelper.AddData(cmd, DBC.MeterData.active_power_c, 1);
                //PgDBHelper.AddData(cmd, DBC.MeterData.active_power_total, 1);

                PgDBHelper.AddData(cmd, DBC.MeterData.active_power_a, float.Parse(active_power[0]));
                PgDBHelper.AddData(cmd, DBC.MeterData.active_power_b, float.Parse(active_power[1]));
                PgDBHelper.AddData(cmd, DBC.MeterData.active_power_c, float.Parse(active_power[2]));
                PgDBHelper.AddData(cmd, DBC.MeterData.active_power_total, float.Parse(active_power[3]));

                //PgDBHelper.AddData(cmd, DBC.MeterData.reactive_power_a, 1);
                //PgDBHelper.AddData(cmd, DBC.MeterData.reactive_power_b, 1);
                //PgDBHelper.AddData(cmd, DBC.MeterData.reactive_power_c, 1);
                //PgDBHelper.AddData(cmd, DBC.MeterData.reactive_power_total, 1);

                PgDBHelper.AddData(cmd, DBC.MeterData.reactive_power_a, float.Parse(reactive_power[0]));
                PgDBHelper.AddData(cmd, DBC.MeterData.reactive_power_b, float.Parse(reactive_power[1]));
                PgDBHelper.AddData(cmd, DBC.MeterData.reactive_power_c, float.Parse(reactive_power[2]));
                PgDBHelper.AddData(cmd, DBC.MeterData.reactive_power_total, float.Parse(reactive_power[2]));

                //PgDBHelper.AddData(cmd, DBC.MeterData.power_factor_a, 1);
                //PgDBHelper.AddData(cmd, DBC.MeterData.power_factor_b, 1);
                //PgDBHelper.AddData(cmd, DBC.MeterData.power_factor_c, 1);
                //PgDBHelper.AddData(cmd, DBC.MeterData.temperature, 1);
                //PgDBHelper.AddData(cmd, DBC.MeterData.humidity, 1);
                //PgDBHelper.AddData(cmd, DBC.MeterData.acquisition_time, 1);

                PgDBHelper.AddData(cmd, DBC.MeterData.power_factor_a, float.Parse(power_factor[0]));
                PgDBHelper.AddData(cmd, DBC.MeterData.power_factor_b, float.Parse(power_factor[1]));
                PgDBHelper.AddData(cmd, DBC.MeterData.power_factor_c, float.Parse(power_factor[2]));
                PgDBHelper.AddData(cmd, DBC.MeterData.temperature, int.Parse(temp[0]));
                PgDBHelper.AddData(cmd, DBC.MeterData.humidity, int.Parse(humi[0]));
                PgDBHelper.AddData(cmd, DBC.MeterData.acquisition_time, 1);

                PgDBHelper.AddData(cmd, DBC.MeterData.phase_fault_a, 1);
                PgDBHelper.AddData(cmd, DBC.MeterData.phase_fault_b, 1);
                PgDBHelper.AddData(cmd, DBC.MeterData.phase_fault_c, 1);
                PgDBHelper.AddData(cmd, DBC.MeterData.combined_phase_fault, 1);

            });

        });


    }


}

