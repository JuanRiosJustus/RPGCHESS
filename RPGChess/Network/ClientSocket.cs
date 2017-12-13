using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class ClientSocket
{
    private byte[] Buffer;
    private byte[] Rebuff;
    private Socket Connection;
    private IPEndPoint EndAddress;
    private string message;


    public ClientSocket(string ip, int port)
    {
        Connection = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        EndAddress = new IPEndPoint(IPAddress.Parse(ip), port);
        Connection.Connect(EndAddress);
        Rebuff = new byte[5000];
        message = "";
    }
    public void SendString(string msg)
    {
        Buffer = Encoding.Default.GetBytes(msg);
        Connection.Send(Buffer, 0, Buffer.Length, 0);
        Array.Resize(ref Buffer, Connection.Receive(Buffer, 0, Buffer.Length, 0));
        Console.WriteLine("[SENT] >> " + msg);
        Connection.Receive(Rebuff, 0, Rebuff.Length, 0);
        Console.WriteLine("[RECIEVED]: " + Encoding.Default.GetString(Rebuff));
        message = Encoding.Default.GetString(Rebuff);

    }
    ~ClientSocket()
    {
        Connection.Close();
    }
}