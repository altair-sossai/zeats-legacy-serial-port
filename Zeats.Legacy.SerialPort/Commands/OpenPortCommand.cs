using System.IO.Ports;

namespace Zeats.Legacy.SerialPort.Commands
{
    public class OpenPortCommand
    {
        public string PortName { get; protected set; }
        public Parity Parity { get; protected set; }
        public int BaudRate { get; protected set; }
        public int DataBits { get; protected set; }
        public StopBits StopBits { get; protected set; }
    }
}