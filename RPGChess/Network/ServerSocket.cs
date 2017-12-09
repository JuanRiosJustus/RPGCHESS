using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class ServerSocket
{
    private byte[] Buffer;
    private Socket Connection;
    private Socket Sock;
    private Thread Worker;
    private string Message;
    private string MsgBufr; 

    public ServerSocket(string initMsg)
    {
        MsgBufr = "....................";
        Connection = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Buffer = Encoding.Default.GetBytes(MsgBufr + initMsg);
        Connection.Bind(new IPEndPoint(0, 1994));
        Connection.Listen(0);
        Worker = new Thread(Run);
        Worker.Start();
    }
    public void Run()
    {
        while(true)
        {
            Sock = Connection.Accept();
            Sock.Send(Buffer, 0, Buffer.Length, 0);
            Console.WriteLine("[SENT]: " + Encoding.Default.GetString(Buffer));
            Buffer = new byte[2555];
            Sock.Receive(Buffer, 0, Buffer.Length, 0);
            Console.WriteLine("[RECIEVED]: " + Encoding.Default.GetString(Buffer));
            Message = Encoding.Default.GetString(Buffer);
        }
    }
    public void SentMessage(string msg)
    {
        Buffer = Encoding.Default.GetBytes(MsgBufr + msg);
    }
    public String GetMessage()
    {
        String temp = Message;
        Message = "";
        return temp;
    }
    ~ServerSocket()
    {
        Connection.Close();
        Sock.Close();
    }
}