using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
class GameServer
{
    private int Port;
    private string PORT { get { return "[" + Port + "]"; } }
    private int RecievedArgs;
    private string RARGUMENT { get { RecievedArgs++; return "[" + RecievedArgs + "]"; } }
    private int SentArgs;
    private string SARGUMENT { get { SentArgs++; return "[" + SentArgs + "]"; } }

    public GameServer(int port) { Port = port; RecievedArgs = 0; }

    /// <summary>
    /// Begins the server loop.
    /// </summary>
    public void Start()
    {
        TcpListener listener = null;
        try
        {
            ShowServerNetworkConfig();
            listener = new TcpListener(IPAddress.Any, Port);
            listener.Start();
            Console.WriteLine("Server has started.");
            while (true)
            {
                Console.WriteLine("Awaiting client connection(s)...");
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Client connection found...");
                Thread t = new Thread(ProcessClientRequests);
                t.Start(client);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            if (listener != null)
            {
                listener.Stop();
            }
        }
    }
    /// <summary>
    /// Processes user input.
    /// </summary>
    /// <param name="obj"></param>
    private void ProcessClientRequests(object obj)
    {
        TcpClient client = (TcpClient)obj;
        try
        {
            StreamReader reader = new StreamReader(client.GetStream());
            StreamWriter writer = new StreamWriter(client.GetStream());
            string input = string.Empty;

            // Input loop.
            while (!((input = reader.ReadLine()).Equals("Exit") || input == null))
            {
                // commands
                switch (input)
                {
                    case "getc person":
                        {
                            Console.WriteLine(RARGUMENT + "[Client]: " + input);
                            Serialize(client.GetStream(), new Person.Person("Serverman", 19, "male"));
                            client.GetStream().Flush();
                            Console.WriteLine("[Server][" + input + "] command executed.");
                        }
                        break;
                        case ""
                    default:
                        {
                            Console.WriteLine(RARGUMENT + "[Client]: " + input);
                            writer.WriteLine(SARGUMENT + "[Server]: Msg recieved");
                            writer.Flush();
                        }
                        break;
                }
            }
            reader.Close();
            writer.Close();
            client.Close();
        }
        catch (IOException)
        {
            Console.WriteLine("Client connection closed<?>.");
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("Incoming string is null, premature exiting from client.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Unkown exception");
            Console.WriteLine(e);
        }
        finally
        {
            client.Close();
        }
    }
    /// <summary>
    /// Derializes the given object into a given stream.
    /// </summary>
    /// <typeparam name="T">type of object to deerialize.</typeparam>
    /// <param name="stream">stream to get object from</param>
    private static object Deserializer<T>(NetworkStream stream)
    {
        BinaryFormatter bf = new BinaryFormatter();
        return (T)bf.Deserialize(stream);
    }
    /// <summary>
    /// Serializes the given object into a given stream.
    /// </summary>
    /// <typeparam name="T">type of object to serialize.</typeparam>
    /// <param name="stream">stream to send object into.</param>
    /// <param name="obj">object to be sent.</param>
    private void Serialize<T>(NetworkStream stream, T obj)
    {
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(stream, obj);
    }
    /// <summary>
    /// Shows network configuration.
    /// </summary>
    public void ShowServerNetworkConfig()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
        foreach (NetworkInterface a in adapters)
        {
            Console.WriteLine(a.Description);
            Console.WriteLine("\tAdapter Name: " + a.Name);
            Console.WriteLine("\tMAC Address: " + a.GetPhysicalAddress());

            IPInterfaceProperties addresses = a.GetIPProperties();
            UnicastIPAddressInformationCollection col = addresses.UnicastAddresses;
            foreach (UnicastIPAddressInformation uac in col)
            {
                Console.WriteLine("\tIP address: " + uac.Address);
            }
        }
        Console.ForegroundColor = ConsoleColor.White;
    }
}*/