using System.Collections.Generic;
using Zeats.Legacy.SerialPort.Commands;

namespace Zeats.Legacy.SerialPort
{
    public static class SerialPortManager
    {
        private static readonly object Lock = new object();
        private static readonly Dictionary<string, System.IO.Ports.SerialPort> SerialPorts = new Dictionary<string, System.IO.Ports.SerialPort>();

        public static System.IO.Ports.SerialPort Get(string portName)
        {
            lock (Lock)
            {
                if (SerialPorts.ContainsKey(portName))
                    return SerialPorts[portName];

                var serialPort = new System.IO.Ports.SerialPort
                {
                    PortName = portName
                };

                SerialPorts.Add(portName, serialPort);

                return SerialPorts[portName];
            }
        }

        public static System.IO.Ports.SerialPort Open(OpenPortCommand command)
        {
            lock (Lock)
            {
                var serialPort = Get(command.PortName);

                if (serialPort.IsOpen)
                    return serialPort;

                serialPort.Parity = command.Parity;
                serialPort.BaudRate = command.BaudRate;
                serialPort.DataBits = command.DataBits;
                serialPort.StopBits = command.StopBits;

                serialPort.Open();

                return serialPort;
            }
        }

        public static void Close(string portName)
        {
            lock (Lock)
            {
                var serialPort = Get(portName);

                if (serialPort.IsOpen)
                    serialPort.Close();
            }
        }

        public static void Write(string portName, string message)
        {
            lock (Lock)
            {
                var serialPort = Get(portName);

                if (!serialPort.IsOpen)
                    serialPort.Open();

                serialPort.Write(message);
            }
        }

        public static string ReadExisting(string portName)
        {
            lock (Lock)
            {
                var serialPort = Get(portName);

                if (!serialPort.IsOpen)
                    serialPort.Open();

                return serialPort.ReadExisting();
            }
        }
    }
}