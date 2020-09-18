using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

public class PgDBHelper : Single<PgDBHelper> {

    private static NpgsqlConnection conn;
   

    /// <summary>
    /// 连接并打开数据库
    /// </summary>
    public void DBOpen(string conStr) {

        try {
            conn = new NpgsqlConnection(conStr);
            conn.Open();

            Console.WriteLine("数据库已打开");
        } catch (Exception) {
            conn.Close();
            Console.WriteLine("数据库已关闭");
            throw;
        }
    }

    /// <summary>
    /// 数据库添加值
    /// </summary>
    /// <param name="cmd"></param>
    /// <param name="param"></param>
    /// <param name="obj"></param>
    public static void AddData(NpgsqlCommand cmd, string param, object obj) {
        cmd.Parameters.AddWithValue($"@{param}", obj);
    }
    /// <summary>
    /// 插入数据库
    /// </summary>
    /// <param name="tbName">表名</param>
    /// <param name="field">字段名</param>
    /// <param name="data">数据名</param>
    /// <param name="insertF">操作操作</param>
    public static void DBInsert(string tbName, string field, string data, Action<NpgsqlCommand> insertF) {//meter_data

        try {
            var insertStr = $@"INSERT INTO {tbName}({field}) VALUES({data})";

            NpgsqlCommand cmd = new NpgsqlCommand(insertStr, conn);

            insertF?.Invoke(cmd);

            cmd.ExecuteNonQuery();

            Console.WriteLine("数据插入成功");

        } catch (Exception) {
            Console.WriteLine("数据库插入失败！");
            conn.Close();
            throw;
        }
    }
}
