using System;
using System.Collections.Generic;
using System.Text;

public class SocketData {

    /// <summary>
    /// 接受消息
    /// </summary>
    private static Action<byte[]> recvMsgAc;
    /// <summary>
    /// 发送消息
    /// </summary>
    private static Action<byte[]> sendMsgAc;

    /// <summary>
    /// 接受消息
    /// </summary>
    /// <param name="msg"></param>
    public static void RecvMsgF(Action<byte[]> msg) {
        recvMsgAc = msg;
    }
    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="msg"></param>
    public static void SendMsgF(Action<byte[]> msg) {
        sendMsgAc = msg;
    }

    public static void Start(string ip,int port) {
        PgDBHelper.Instance.DBOpen();
        PgDBHelper.Instance.DBInsert();

        //StrOperBase strOperBase = new StrOperBase();

        //FrameLine frameLine = strOperBase as FrameLine;


        SocketClient client = new SocketClient(ip,port);//127.0.0.1 192.168.137.1 10.13.19.81

        //绑定当收到服务器发送的消息后的处理事件
        client.HandleRecMsg = new Action<byte[], SocketClient>((bytes, theClient) => {

            recvMsgAc?.Invoke(bytes);//接受的消息

            //string recvMsg = Encoding.UTF8.GetString(bytes);

            //Console.WriteLine("电压：");
            //foreach (var item in frameLine.GetVoltage(recvMsg)) {
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("电流：");
            //foreach (var item in frameLine.GetCurrent(recvMsg)) {
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("有功：");
            //foreach (var item in frameLine.GetActivePower(recvMsg)) {
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("无功：");
            //foreach (var item in frameLine.GetReactivePower(recvMsg)) {
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("功率因数：");
            //foreach (var item in frameLine.GetPowerFactor(recvMsg)) {
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("温度：");
            //foreach (var item in frameLine.GetTransTemp(recvMsg)) {
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("湿度：");
            //foreach (var item in frameLine.GetHumidity(recvMsg)) {
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("时间：");
            //foreach (var item in frameLine.GetHeartTime(recvMsg)) {
            //    Console.WriteLine(item);
            //}

        });

        //绑定向服务器发送消息后的处理事件
        client.HandleSendMsg = new Action<byte[], SocketClient>((bytes, theClient) => {
            sendMsgAc?.Invoke(bytes);//发送的消息
            string msg = Encoding.UTF8.GetString(bytes);
        });

        //开始运行客户端
        client.StartClient();

        while (true) {
            Console.WriteLine("输入:quit关闭客户端，输入其它消息发送到服务器");
            string str = Console.ReadLine();
            if (str == "quit") {
                client.Close();
                break;
            } else {
                client.Send(str);
            }
        }
    }

}

