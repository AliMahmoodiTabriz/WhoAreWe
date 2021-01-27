using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Core.Utilities.DateTimes
{
    public static class OnlineDataTime
    {
        public static DateTime? GetOnlineTime()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                {
                    var result = DateTime.Now;

                    // Initialize the list of NIST time servers
                    // http://tf.nist.gov/tf-cgi/servers.cgi
                    string[] servers = new string[] {

                "time-c.nist.gov",
                "time-d.nist.gov",
                "nist1-macon.macon.ga.us",
                "wolfnisttime.com",
                "nist.netservicesgroup.com",
                "nisttime.carsoncity.k12.mi.us",
                "nist1-lnk.binary.net",
                "wwv.nist.gov",
                "time.nist.gov",
                "utcnist.colorado.edu",
                "utcnist2.colorado.edu",
                "nist-time-server.eoni.com",
                "nist-time-server.eoni.com"
            };
                    Random rnd = new Random();

                    foreach (string server in servers.OrderBy(x => rnd.NextDouble()).Take(9))
                    {
                        try
                        {
                            // Connect to the server (at port 13) and get the response. Timeout max 1second
                            string serverResponse = string.Empty;
                            var tcpClient = new TcpClient();
                            if (tcpClient.ConnectAsync(server, 13).Wait(1000))
                            {
                                using (var reader = new StreamReader(tcpClient.GetStream()))
                                {
                                    serverResponse = reader.ReadToEnd();
                                }
                            }
                            // If a response was received
                            if (!string.IsNullOrEmpty(serverResponse))
                            {
                                // Split the response string ("55596 11-02-14 13:54:11 00 0 0 478.1 UTC(NIST) *")
                                string[] tokens = serverResponse.Split(' ');

                                // Check the number of tokens
                                if (tokens.Length >= 6)
                                {
                                    // Check the health status
                                    string health = tokens[5];
                                    if (health == "0")
                                    {
                                        // Get date and time parts from the server response
                                        string[] dateParts = tokens[1].Split('-');
                                        string[] timeParts = tokens[2].Split(':');

                                        // Create a DateTime instance
                                        DateTime utcDateTime = new DateTime(
                                        Convert.ToInt32(dateParts[0]) + 2000,
                                        Convert.ToInt32(dateParts[1]), Convert.ToInt32(dateParts[2]),
                                        Convert.ToInt32(timeParts[0]), Convert.ToInt32(timeParts[1]),
                                        Convert.ToInt32(timeParts[2]));

                                        // Convert received (UTC) DateTime value to the local timezone
                                        result = utcDateTime.ToLocalTime();

                                        return result;
                                        // Response successfully received; exit the loop

                                    }
                                }

                            }
                        }
                        catch
                        {
                        }
                    }
                }
                return null;
            }
            catch
            {

                return null;
            }
        }
    }
}
