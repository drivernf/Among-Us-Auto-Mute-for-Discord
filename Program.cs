using System;
using System.Collections.Generic;
using System.Diagnostics;
using SharpPcap;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace AmongUs
{
    class Program
    {
        static void Main(string[] args)
        {
            // Application to capture
            string applicationName = "Among Us";

            // Network devices to monitor
            List<ICaptureDevice> devices = GetDevices();

            // Get all ports this application uses
            List<Port> statPorts = GetNetStatPorts(applicationName);

            // Create capture filter
            string portFilter = "";
            for (int i = 0; i < statPorts.Count; i++)
            {
                Port p = statPorts[i];
                portFilter += p.process_name + " port " + p.port_number;
                if (i < statPorts.Count - 1)
                    portFilter += " or ";
            }

            Console.WriteLine($"Monitoring \"{applicationName}\" with filter: {portFilter}");

            // Capture
            foreach (ICaptureDevice device in devices)
            {
                device.OnPacketArrival += new PacketArrivalEventHandler(Device_OnPacketArrival);

                int readTimeoutMilliseconds = 1000;
                device.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);

                device.StartCapture();

                device.Filter = portFilter;

                while (true)
                {
                    // Get all ports this application uses
                    statPorts = GetNetStatPorts(applicationName);

                    // Create capture filter
                    portFilter = "";
                    for (int i = 0; i < statPorts.Count; i++)
                    {
                        Port p = statPorts[i];
                        portFilter += p.process_name + " port " + p.port_number;
                        if (i < statPorts.Count - 1)
                            portFilter += " or ";
                    }
                    device.Filter = portFilter;

                    Thread.Sleep(100);
                }

                //Console.ReadLine();

                //device.StopCapture();

                //device.Close();
            }
        }

        static List<ICaptureDevice> GetDevices()
        {
            CaptureDeviceList allDevices = CaptureDeviceList.Instance;
            List<ICaptureDevice> validDevices = new List<ICaptureDevice>();
            foreach (ICaptureDevice device in allDevices)
            {
                if (device.ToString().Contains("1) "))
                    validDevices.Add(device);
            }
            return validDevices;
        }

        private static void Device_OnPacketArrival(object sender, CaptureEventArgs packet)
        {
            DateTime time = packet.Packet.Timeval.Date;
            int len = packet.Packet.Data.Length;
            Console.WriteLine("\n{0}:{1}:{2},{3} Len={4}",
                time.Hour, time.Minute, time.Second, time.Millisecond, len);

            var parsedPacket = PacketDotNet.Packet.ParsePacket(packet.Packet.LinkLayerType, packet.Packet.Data);
            Console.WriteLine(parsedPacket.PrintHex());
            //Console.WriteLine(parsedPacket.BytesSegment.BytesSequenceToHexadecimalString());
        }

        public static List<Port> GetNetStatPorts(string searchProcess)
        {
            var Ports = new List<Port>();

            try
            {
                using (Process p = new Process())
                {
                    ProcessStartInfo ps = new ProcessStartInfo();
                    ps.Arguments = "-a -n -o";
                    ps.FileName = "netstat.exe";
                    ps.UseShellExecute = false;
                    ps.WindowStyle = ProcessWindowStyle.Hidden;
                    ps.RedirectStandardInput = true;
                    ps.RedirectStandardOutput = true;
                    ps.RedirectStandardError = true;

                    p.StartInfo = ps;
                    p.Start();

                    StreamReader stdOutput = p.StandardOutput;
                    StreamReader stdError = p.StandardError;

                    string content = stdOutput.ReadToEnd() + stdError.ReadToEnd();
                    string exitStatus = p.ExitCode.ToString();

                    if (exitStatus != "0")
                    {
                        // Command Errored. Handle Here If Need Be
                    }

                    //Get The Rows
                    string[] rows = Regex.Split(content, "\r\n");
                    foreach (string row in rows)
                    {
                        //Split
                        string[] tokens = Regex.Split(row, "\\s+");
                        if (tokens.Length > 4 && (tokens[1].Equals("UDP") || tokens[1].Equals("TCP")))
                        {
                            string localAddress = Regex.Replace(tokens[2], @"\[(.*?)\]", "1.1.1.1");
                            string processName = tokens[1] == "UDP" ? LookupProcess(Convert.ToInt16(tokens[4])) : LookupProcess(Convert.ToInt16(tokens[5]));
                            string transferProtocol = "tcp";
                            if (tokens[1].Equals("UDP"))
                                transferProtocol = "udp";
                            if (processName == searchProcess || searchProcess == "")
                            {
                                Ports.Add(new Port
                                {
                                    protocol = localAddress.Contains("1.1.1.1") ? String.Format("{0}v6", tokens[1]) : String.Format("{0}v4", tokens[1]),
                                    port_number = localAddress.Split(':')[1],
                                    process_name = transferProtocol
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Ports;
        }

        public static string LookupProcess(int pid)
        {
            string procName;
            try { procName = Process.GetProcessById(pid).ProcessName; }
            catch (Exception) { procName = "-"; }
            return procName;
        }

        public class Port
        {
            public string name
            {
                get
                {
                    return string.Format("{0} ({1} port {2})", this.process_name, this.protocol, this.port_number);
                }
                set { }
            }
            public string port_number { get; set; }
            public string process_name { get; set; }
            public string protocol { get; set; }
        }
    }    
}
