﻿
using System.Net;
using System.Net.Sockets;

public class NetworkManager
{

    /// <summary>
    /// Helper method that gets the users local IPv4 connection.
    /// </summary>
    /// <returns></returns>
    public static string GetLocalIPAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return "Local IP: " + ip.ToString();
            }
        }
        return "No network adapters with an IPv4 address found in the system!";
    }
}