using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

/*
public class GameClient
{
    private readonly IPAddress Hostname;
    private readonly int Port;
    private Person.Person _person;
    public Person.Person PRSN { get { return _person; } }

    public GameClient(string endpoint, int port)
    {
        Hostname = IPAddress.Parse(endpoint);
        Port = port;
    }

    /// <summary>
    /// Serializes the given object into a given stream.
    /// </summary>
    /// <typeparam name="T">type of object to serialize.</typeparam>
    /// <param name="stream">stream to send object into.</param>
    /// <param name="obj">object to be sent.</param>
    private static void Serialize<T>(NetworkStream stream, T obj)
    {
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(stream, obj);
    }
    /// <summary>
    /// Derializes the given object into a given stream.
    /// </summary>
    /// <typeparam name="T">type of object to deerialize.</typeparam>
    /// <param name="stream">stream to get object from</param>
    private static T Deserialize<T>(NetworkStream stream)
    {
        BinaryFormatter bf = new BinaryFormatter();
        return (T)bf.Deserialize(stream);
    }

    /// <summary>
    /// Sends objects.
    /// </summary>
    /// <typeparam name="T">type of objec tot be sent.</typeparam>
    /// <param name="obj">Object to be sent(Ensure dll's)</param>
    public void SendObject<T>(T obj)
    {
        try
        {
            TcpClient client = new TcpClient(Hostname.ToString(), Port);
            Console.WriteLine("Connected to server.");
            StreamReader reader = new StreamReader(client.GetStream());
            StreamWriter writer = new StreamWriter(client.GetStream());

            // make sure no nulls.
            if (obj != null)
            {
                if (typeof(T) == typeof(string))
                {
                    // commands
                    writer.WriteLine(obj);
                    writer.Flush();
                    string serverString = reader.ReadLine();
                    Console.WriteLine(serverString);
                }
                else if (typeof(T) == typeof(Person.Person))
                {
                    writer.WriteLine("getc person");
                    writer.Flush();
                    Person.Person p = Deserialize<Person.Person>(client.GetStream());
                    _person = p;
                    Console.WriteLine(p.Name);
                }
            }
            reader.Close();
            writer.Close();
            client.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

}*/