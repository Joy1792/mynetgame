using UnityEngine;
using System;
using System.IO;
//using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;

//using System.Collections.Generic;
using System.Net.Sockets;

public class NetWorkScript
{

	private static NetWorkScript instance;
	private static Socket socket;
	private static string ip = "127.0.0.1";
	private static int port = 10100;
	private static byte[] buff = new byte[1024];
	private static List<SocketModel> messageList = new List<SocketModel>();
	public static NetWorkScript getInstance()
	{
		if (instance == null)
		{
			instance = new NetWorkScript();
			init();
		}
		return instance;
	}

	public static void init()
	{
		try
		{
			socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			socket.Connect(ip, port);
			Debug.Log("connect success");
			socket.BeginReceive(buff, 0, 1024, SocketFlags.None, ReceiveCallBack, buff);
		} catch
		{
			Debug.Log("connect failed");
		}
	}
	private static void sendMessage(int type,int area,int command,string message)
	{
		ByteArray ba = new ByteArray();
		ba.WriteInt(type);
		ba.WriteInt(area);
		ba.WriteInt(command);
		if (message != null && message != string.Empty)
		{
			ba.WriteInt(message.Length);
			ba.WriteUTFBytes(message);
		} else
		{
			ba.WriteInt(0);
		}
		try
		{
			socket.Send(ba.Buffer);
		}
		catch
		{
			Debug.Log("net error,send failed");
		}
	}

	private static void ReceiveCallBack(IAsyncResult ar)
	{
		try
		{
			//get message length
			int readCount = 0;
			readCount = socket.EndReceive(ar);
			byte[] temp = new byte[readCount];
			Buffer.BlockCopy(buff, 0, temp, 0, readCount);
		} catch
		{
			socket.Close();
			Debug.Log("net error");

		}
		socket.BeginReceive(buff, 0, 1024, SocketFlags.None, ReceiveCallBack, buff);
	}


	private void readMesage(byte[] message)
	{
		MemoryStream ms = new MemoryStream(message, 0, message.Length);
		ByteArray ba = new ByteArray(ms);
		SocketModel model = new SocketModel();
		model.type = ba.ReadInt();
		model.area = ba.ReadInt();
		model.command = ba.ReadInt();
		int length = ba.ReadInt();
		if (length > 0)
		{
			model.message = ba.ReadUTFBytes((uint)length);
		}
		messageList.Add(model);
	}

}