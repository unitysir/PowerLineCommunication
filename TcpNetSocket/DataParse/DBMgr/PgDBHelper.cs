using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

public class PgDBHelper : Single<PgDBHelper> {

    private static string conStr = "Host=localhost;Port=5432;Username=postgres;Password=admin;Database=postgres";

    private static NpgsqlConnection conn;

    private string recvStr = "";



    /// <summary>
    /// 连接并打开数据库
    /// </summary>
    public void DBOpen() {

        try {
            conn = new NpgsqlConnection(conStr);
            conn.Open();

            SocketData.RecvMsgF(bytes => {
                recvStr = Encoding.UTF8.GetString(bytes);
            });

            Console.WriteLine("数据库连接并打开");
        } catch (Exception) {
            conn.Close();
            Console.WriteLine("数据库关闭");
            throw;
        }
    }

    public void DBInsert() {

        try {
            StrOperBase strOperBase = new StrOperBase();

            FrameLine frameLine = strOperBase as FrameLine;

            List<string> voltage = frameLine.GetVoltage(recvStr);


            string insertStr = $@"INSERT INTO meter_data(
                {DBC.MeterData.meter_sn},
                {DBC.MeterData.save_time},
                {DBC.MeterData.voltage_a},
                {DBC.MeterData.voltage_b},
                {DBC.MeterData.voltage_c},      
                {DBC.MeterData.current_a},
                {DBC.MeterData.current_b},
                {DBC.MeterData.current_c},
                {DBC.MeterData.current_zero_line},
                {DBC.MeterData.current_remain},
                {DBC.MeterData.active_power_a},
                {DBC.MeterData.active_power_b},
                {DBC.MeterData.active_power_c},
                {DBC.MeterData.active_power_total},
                {DBC.MeterData.reactive_power_a},
                {DBC.MeterData.reactive_power_b},
                {DBC.MeterData.reactive_power_c},
                {DBC.MeterData.reactive_power_total},
                {DBC.MeterData.power_factor_a},
                {DBC.MeterData.power_factor_b},
                {DBC.MeterData.power_factor_c},
                {DBC.MeterData.temperature},
                {DBC.MeterData.humidity},
                {DBC.MeterData.acquisition_time},
                {DBC.MeterData.phase_fault_a},
                {DBC.MeterData.phase_fault_b},
                {DBC.MeterData.phase_fault_c},
                {DBC.MeterData.combined_phase_fault}) 
                VALUES(
                @{DBC.MeterData.meter_sn},
                @{DBC.MeterData.save_time},
                @{DBC.MeterData.voltage_a},
                @{DBC.MeterData.voltage_b},
                @{DBC.MeterData.voltage_c},
                @{DBC.MeterData.current_a},
                @{DBC.MeterData.current_b},
                @{DBC.MeterData.current_c},
                @{DBC.MeterData.current_zero_line},
                @{DBC.MeterData.current_remain},
                @{DBC.MeterData.active_power_a},
                @{DBC.MeterData.active_power_b},
                @{DBC.MeterData.active_power_c},
                @{DBC.MeterData.active_power_total},
                @{DBC.MeterData.reactive_power_a},
                @{DBC.MeterData.reactive_power_b},
                @{DBC.MeterData.reactive_power_c},
                @{DBC.MeterData.reactive_power_total},
                @{DBC.MeterData.power_factor_a},
                @{DBC.MeterData.power_factor_b},
                @{DBC.MeterData.power_factor_c},
                @{DBC.MeterData.temperature},
                @{DBC.MeterData.humidity},
                @{DBC.MeterData.acquisition_time},
                @{DBC.MeterData.phase_fault_a},
                @{DBC.MeterData.phase_fault_b},
                @{DBC.MeterData.phase_fault_c},
                @{DBC.MeterData.combined_phase_fault})";

            NpgsqlCommand cmd = new NpgsqlCommand(insertStr, conn);


            #region test
            cmd.Parameters.AddWithValue($"@{DBC.MeterData.meter_sn}", "123");
            cmd.Parameters.AddWithValue($"@{DBC.MeterData.save_time}", "");

            cmd.Parameters.AddWithValue($"@{DBC.MeterData.voltage_a}", voltage[0]);
            cmd.Parameters.AddWithValue($"@{DBC.MeterData.voltage_b}", voltage[1]);
            cmd.Parameters.AddWithValue($"@{DBC.MeterData.voltage_c}", voltage[2]);

            cmd.Parameters.AddWithValue($"@{DBC.MeterData.current_a}", 1.9);
            cmd.Parameters.AddWithValue($"@{DBC.MeterData.current_b}", 1.9);
            cmd.Parameters.AddWithValue($"@{DBC.MeterData.current_c}", 1.9);
            cmd.Parameters.AddWithValue($"@{DBC.MeterData.current_zero_line}", 1.9);
            cmd.Parameters.AddWithValue($"@{DBC.MeterData.current_remain}", 1.9);

            cmd.Parameters.AddWithValue($"@{DBC.MeterData.active_power_a}", 1.9);
            cmd.Parameters.AddWithValue($"@{DBC.MeterData.active_power_b}", 1.9);
            cmd.Parameters.AddWithValue($"@{DBC.MeterData.active_power_c}", 1.9);
            cmd.Parameters.AddWithValue($"@{DBC.MeterData.active_power_total}", 1.9);

            cmd.Parameters.AddWithValue($"@{DBC.MeterData.reactive_power_a}", 1.9);
            cmd.Parameters.AddWithValue($"@{DBC.MeterData.reactive_power_b}", 1.9);
            cmd.Parameters.AddWithValue($"@{DBC.MeterData.reactive_power_c}", 1.9);
            cmd.Parameters.AddWithValue($"@{DBC.MeterData.reactive_power_total}", 1.9);

            cmd.Parameters.AddWithValue($"@{DBC.MeterData.power_factor_a}", 1.9);
            cmd.Parameters.AddWithValue($"@{DBC.MeterData.power_factor_b}", 1.9);
            cmd.Parameters.AddWithValue($"@{DBC.MeterData.power_factor_c}", 1.9);
            cmd.Parameters.AddWithValue($"@{DBC.MeterData.temperature}", 1);
            cmd.Parameters.AddWithValue($"@{DBC.MeterData.humidity}", 1);
            cmd.Parameters.AddWithValue($"@{DBC.MeterData.acquisition_time}", "");

            cmd.Parameters.AddWithValue($"@{DBC.MeterData.phase_fault_a}", "");
            cmd.Parameters.AddWithValue($"@{DBC.MeterData.phase_fault_b}", "");
            cmd.Parameters.AddWithValue($"@{DBC.MeterData.phase_fault_c}", "");
            cmd.Parameters.AddWithValue($"@{DBC.MeterData.combined_phase_fault}", "");
            #endregion


            cmd.ExecuteNonQuery();

            Console.WriteLine("数据插入成功!");

        } catch (Exception) {
            Console.WriteLine("数据库插入失败！");
            conn.Close();
            throw;
        }
    }
}
